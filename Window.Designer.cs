using System;

namespace FL_Studio_Plugin_Categoriser
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VSTFolderTextBox = new System.Windows.Forms.TextBox();
            this.VSTFolderLabel = new System.Windows.Forms.Label();
            this.VSTFolderButton = new System.Windows.Forms.Button();
            this.FLFolderButton = new System.Windows.Forms.Button();
            this.FLFolderLabel = new System.Windows.Forms.Label();
            this.FLFolderTextBox = new System.Windows.Forms.TextBox();
            this.CopyAll = new System.Windows.Forms.Button();
            this.CopyNew = new System.Windows.Forms.Button();
            this.OutputLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // VSTFolderTextBox
            // 
            this.VSTFolderTextBox.Location = new System.Drawing.Point(11, 64);
            this.VSTFolderTextBox.Name = "VSTFolderTextBox";
            this.VSTFolderTextBox.Size = new System.Drawing.Size(357, 20);
            this.VSTFolderTextBox.TabIndex = 0;
            this.VSTFolderTextBox.Text = Properties.Settings.Default.VSTFolder;
            // 
            // VSTFolderLabel
            // 
            this.VSTFolderLabel.AutoSize = true;
            this.VSTFolderLabel.Location = new System.Drawing.Point(12, 48);
            this.VSTFolderLabel.Name = "VSTFolderLabel";
            this.VSTFolderLabel.Size = new System.Drawing.Size(63, 13);
            this.VSTFolderLabel.TabIndex = 1;
            this.VSTFolderLabel.Text = "VST2 folder (from which subfolders will be replicated)";
            // 
            // VSTFolderButton
            // 
            this.VSTFolderButton.Location = new System.Drawing.Point(374, 64);
            this.VSTFolderButton.Name = "VSTFolderButton";
            this.VSTFolderButton.Size = new System.Drawing.Size(75, 23);
            this.VSTFolderButton.TabIndex = 2;
            this.VSTFolderButton.Text = "Browse...";
            this.VSTFolderButton.UseVisualStyleBackColor = true;
            this.VSTFolderButton.Click += new System.EventHandler(this.VSTFolderButton_Click);
            // 
            // FLFolderButton
            // 
            this.FLFolderButton.Location = new System.Drawing.Point(374, 25);
            this.FLFolderButton.Name = "FLFolderButton";
            this.FLFolderButton.Size = new System.Drawing.Size(75, 23);
            this.FLFolderButton.TabIndex = 5;
            this.FLFolderButton.Text = "Browse...";
            this.FLFolderButton.UseVisualStyleBackColor = true;
            this.FLFolderButton.Click += new System.EventHandler(this.FLFolderButton_Click);
            // 
            // FLFolderLabel
            // 
            this.FLFolderLabel.AutoSize = true;
            this.FLFolderLabel.Location = new System.Drawing.Point(12, 9);
            this.FLFolderLabel.Name = "FLFolderLabel";
            this.FLFolderLabel.Size = new System.Drawing.Size(296, 13);
            this.FLFolderLabel.TabIndex = 4;
            this.FLFolderLabel.Text = "FL Studio user data folder (usually \'Image-Line\' in Documents)";
            // 
            // FLFolderTextBox
            // 
            this.FLFolderTextBox.Location = new System.Drawing.Point(11, 25);
            this.FLFolderTextBox.Name = "FLFolderTextBox";
            this.FLFolderTextBox.Size = new System.Drawing.Size(357, 20);
            this.FLFolderTextBox.TabIndex = 3;
            this.VSTFolderTextBox.Text = Properties.Settings.Default.FLFolder;
            // 
            // CopyAll
            // 
            this.CopyAll.Location = new System.Drawing.Point(11, 90);
            this.CopyAll.Name = "CopyAll";
            this.CopyAll.Size = new System.Drawing.Size(207, 23);
            this.CopyAll.TabIndex = 6;
            this.CopyAll.Text = "Copy all plugins\' folder structure";
            this.CopyAll.UseVisualStyleBackColor = true;
            this.CopyAll.Click += new System.EventHandler(this.CopyAll_Click);
            // 
            // CopyNew
            // 
            this.CopyNew.Location = new System.Drawing.Point(225, 91);
            this.CopyNew.Name = "CopyNew";
            this.CopyNew.Size = new System.Drawing.Size(207, 23);
            this.CopyNew.TabIndex = 7;
            this.CopyNew.Text = "Copy \'New\' plugins\' folder structure";
            this.CopyNew.UseVisualStyleBackColor = true;
            this.CopyNew.Click += new System.EventHandler(this.CopyNew_Click);
            // 
            // OutputLog
            // 
            this.OutputLog.FormattingEnabled = true;
            this.OutputLog.HorizontalScrollbar = true;
            this.OutputLog.Location = new System.Drawing.Point(11, 120);
            this.OutputLog.Name = "OutputLog";
            this.OutputLog.ScrollAlwaysVisible = true;
            this.OutputLog.Size = new System.Drawing.Size(438, 212);
            this.OutputLog.TabIndex = 8;
            this.OutputLog.Visible = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(461, 125);
            this.Controls.Add(this.OutputLog);
            this.Controls.Add(this.CopyNew);
            this.Controls.Add(this.CopyAll);
            this.Controls.Add(this.FLFolderButton);
            this.Controls.Add(this.FLFolderLabel);
            this.Controls.Add(this.FLFolderTextBox);
            this.Controls.Add(this.VSTFolderButton);
            this.Controls.Add(this.VSTFolderLabel);
            this.Controls.Add(this.VSTFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Window";
            this.Text = "FL Studio Plugin Categoriser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VSTFolderTextBox;
        private System.Windows.Forms.Label VSTFolderLabel;
        private System.Windows.Forms.Button VSTFolderButton;
        private System.Windows.Forms.Button FLFolderButton;
        private System.Windows.Forms.Label FLFolderLabel;
        private System.Windows.Forms.TextBox FLFolderTextBox;
        private System.Windows.Forms.Button CopyAll;
        private System.Windows.Forms.Button CopyNew;
        private System.Windows.Forms.ListBox OutputLog;
    }
}

