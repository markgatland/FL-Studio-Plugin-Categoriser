using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FL_Studio_Plugin_Categoriser
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
            if (Properties.Settings.Default.FLFolder == "")
            {
                this.FLFolderTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Image-Line";
                Properties.Settings.Default.FLFolder = this.FLFolderTextBox.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void VSTFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                VSTFolderTextBox.Text = dialog.SelectedPath;
                Properties.Settings.Default.VSTFolder = dialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void FLFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                FLFolderTextBox.Text = dialog.SelectedPath;
                Properties.Settings.Default.FLFolder = dialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void CopyAll_Click(object sender, EventArgs e)
        {
            CopyPluginStructure(new String[4] { "Installed\\Effects\\VST\\", "Installed\\Generators\\VST\\", "Installed\\Effects\\New\\", "Installed\\Generators\\New\\" });
        }

        private void CopyNew_Click(object sender, EventArgs e)
        {
            CopyPluginStructure(new String[2] { "Installed\\Effects\\New\\", "Installed\\Generators\\New\\" });
        }

        private void CopyPluginStructure(string[] folders)
        {
            OutputLog.Show();
            ClientSize = new System.Drawing.Size(461, 343);
            int missing = 0;
            String database;
            if (FLFolderTextBox.Text[FLFolderTextBox.Text.Length - 1].ToString() != "\\")
            {
                database = FLFolderTextBox.Text + "\\FL Studio\\Presets\\Plugin database\\";
            }
            else
            {
                database = FLFolderTextBox.Text + "FL Studio\\Presets\\Plugin database\\";
            }
            foreach (string folder in folders)
            {
                String directory = database + folder;
                if (!Directory.Exists(directory))
                {
                    missing++;
                    continue;
                }
                foreach (string filename in Directory.GetFiles(directory))
                {
                    if (filename.Contains(".nfo"))
                    {
                        if (File.Exists(filename.Substring(0, filename.Length - 4) + ".fst"))
                        {
                            String text;
                            try
                            {
                                StreamReader sr = new StreamReader(filename);
                                text = sr.ReadToEnd();
                                Regex location = new Regex(@"ps_file_filename_0=.*?\.dll"); // Todo: Simplify this - don't need regex anymore
                                Match match = location.Match(text);
                                if (match.Success)
                                {
                                    if (match.Value.Contains(VSTFolderTextBox.Text))
                                    {
                                        text = match.Value;
                                        text = text.Replace("ps_file_filename_0=" + VSTFolderTextBox.Text, ""); // Todo: Worry about double slash
                                        for (int i = 1; i < text.Length; i++)
                                        {
                                            if (text[text.Length-i].ToString() == "\\")
                                            {
                                                text = text.Substring(0, text.Length - i);
                                                break;
                                            }
                                        }
                                        if (!Directory.Exists(database + text))
                                        {
                                            Directory.CreateDirectory(database + text);
                                            
                                        }
                                        File.Copy(filename.Substring(0, filename.Length - 4) + ".fst", database + text + "\\" + Path.GetFileName(filename).Substring(0, Path.GetFileName(filename).Length - 4) + ".fst", true);
                                        OutputLog.Items.Add("Copied folder structure for '" + filename.Substring(0, filename.Length - 4) + "'");
                                    }
                                    else
                                    {
                                        OutputLog.Items.Add("Error copying '" + filename.Substring(directory.Length, filename.Length - directory.Length - 4) + "': VST file located outside of specified folder. (Try re-scanning plugins in FL Studio)");
                                        // Todo: Be more concise with this error as it's an issue with the FL plugin database, not the actual VST file
                                    }
                                }
                                else
                                {
                                    OutputLog.Items.Add("Error copying '" + filename.Substring(directory.Length, filename.Length - directory.Length - 4) + "': No associated VST file could be found.");
                                }
                                sr.Close();
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                OutputLog.Items.Add("Error copying '" + filename.Substring(directory.Length, filename.Length - directory.Length) + "': Unhandled exception");
                                OutputLog.Items.Add(e); // Todo: Maybe move this try catch to just the file open, place rest of code after (*if* open file exists, match contents etc) 
                            }
                        }
                        else
                        {
                            OutputLog.Items.Add("Couldn't find .fst for " + filename.Substring(directory.Length, filename.Length - directory.Length) + " (It's probably part of another VST)");
                        }
                    }
                }
            }
            if (missing == 4)
            {
                OutputLog.Items.Add("Couldn't find any plugins. Try running a plugin scan in FL Studio.");
            }
        }
    }
}