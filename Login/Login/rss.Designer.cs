namespace Login
{
    partial class Rss
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
            this.refreshButton = new System.Windows.Forms.Button();
            this.titleCombobox = new System.Windows.Forms.ComboBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.channelTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(426, 46);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 60);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // titleCombobox
            // 
            this.titleCombobox.FormattingEnabled = true;
            this.titleCombobox.Location = new System.Drawing.Point(81, 86);
            this.titleCombobox.Name = "titleCombobox";
            this.titleCombobox.Size = new System.Drawing.Size(322, 20);
            this.titleCombobox.TabIndex = 1;
            this.titleCombobox.SelectedIndexChanged += new System.EventHandler(this.titleCombobox_SelectedIndexChanged);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(79, 322);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(36, 12);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "GoTo";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.Location = new System.Drawing.Point(81, 129);
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.Size = new System.Drawing.Size(420, 174);
            this.descriptionTextbox.TabIndex = 3;
            // 
            // channelTextbox
            // 
            this.channelTextbox.Location = new System.Drawing.Point(81, 46);
            this.channelTextbox.Name = "channelTextbox";
            this.channelTextbox.Size = new System.Drawing.Size(322, 21);
            this.channelTextbox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 401);
            this.Controls.Add(this.channelTextbox);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.titleCombobox);
            this.Controls.Add(this.refreshButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ComboBox titleCombobox;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.TextBox channelTextbox;
    }
}