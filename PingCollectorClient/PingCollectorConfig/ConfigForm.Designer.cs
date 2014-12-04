using System.Drawing;
namespace PingCollectorConfig
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.forgotPassButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.passwordStrengthLabel = new System.Windows.Forms.Label();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalControl = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.aboutLabel = new System.Windows.Forms.LinkLabel();
            this.loginGroupBox.SuspendLayout();
            this.optionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalControl)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.passwordStrengthLabel);
            this.loginGroupBox.Controls.Add(this.progressBar1);
            this.loginGroupBox.Controls.Add(this.forgotPassButton);
            this.loginGroupBox.Controls.Add(this.emailLabel);
            this.loginGroupBox.Controls.Add(this.loginButton);
            this.loginGroupBox.Controls.Add(this.emailBox);
            this.loginGroupBox.Controls.Add(this.passBox);
            this.loginGroupBox.Controls.Add(this.passwordLabel);
            this.loginGroupBox.Location = new System.Drawing.Point(3, 56);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.Size = new System.Drawing.Size(264, 137);
            this.loginGroupBox.TabIndex = 6;
            this.loginGroupBox.TabStop = false;
            this.loginGroupBox.Text = "Account Information";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 48);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Password:";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(68, 45);
            this.passBox.Name = "passBox";
            this.passBox.ShortcutsEnabled = false;
            this.passBox.Size = new System.Drawing.Size(190, 20);
            this.passBox.TabIndex = 3;
            this.passBox.UseSystemPasswordChar = true;
            this.passBox.TextChanged += new System.EventHandler(this.passBox_TextChanged);
            this.passBox.Leave += new System.EventHandler(this.saveSettings);
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(50, 19);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(208, 20);
            this.emailBox.TabIndex = 2;
            this.emailBox.Leave += new System.EventHandler(this.saveSettings);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(6, 100);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(119, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Test Login/Register";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(9, 22);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email:";
            // 
            // forgotPassButton
            // 
            this.forgotPassButton.Location = new System.Drawing.Point(131, 100);
            this.forgotPassButton.Name = "forgotPassButton";
            this.forgotPassButton.Size = new System.Drawing.Size(124, 23);
            this.forgotPassButton.TabIndex = 6;
            this.forgotPassButton.Text = "Forgot Password";
            this.forgotPassButton.UseVisualStyleBackColor = true;
            this.forgotPassButton.Click += new System.EventHandler(this.forgotPassButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Linen;
            this.progressBar1.Location = new System.Drawing.Point(106, 70);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(152, 23);
            this.progressBar1.Step = 20;
            this.progressBar1.TabIndex = 7;
            // 
            // passwordStrengthLabel
            // 
            this.passwordStrengthLabel.AutoSize = true;
            this.passwordStrengthLabel.Location = new System.Drawing.Point(6, 73);
            this.passwordStrengthLabel.Name = "passwordStrengthLabel";
            this.passwordStrengthLabel.Size = new System.Drawing.Size(99, 13);
            this.passwordStrengthLabel.TabIndex = 8;
            this.passwordStrengthLabel.Text = "Password Strength:";
            // 
            // optionsBox
            // 
            this.optionsBox.Controls.Add(this.intervalControl);
            this.optionsBox.Controls.Add(this.intervalLabel);
            this.optionsBox.Location = new System.Drawing.Point(3, 3);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(264, 47);
            this.optionsBox.TabIndex = 7;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(9, 21);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(114, 13);
            this.intervalLabel.TabIndex = 0;
            this.intervalLabel.Text = "Ping Interval: (minutes)";
            // 
            // intervalControl
            // 
            this.intervalControl.Location = new System.Drawing.Point(163, 19);
            this.intervalControl.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.intervalControl.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.intervalControl.Name = "intervalControl";
            this.intervalControl.Size = new System.Drawing.Size(95, 20);
            this.intervalControl.TabIndex = 1;
            this.intervalControl.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.intervalControl.Leave += new System.EventHandler(this.saveSettings);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.optionsBox);
            this.flowLayoutPanel1.Controls.Add(this.loginGroupBox);
            this.flowLayoutPanel1.Controls.Add(this.aboutLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(270, 220);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // aboutLabel
            // 
            this.aboutLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(26, 196);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(218, 13);
            this.aboutLabel.TabIndex = 8;
            this.aboutLabel.TabStop = true;
            this.aboutLabel.Text = "Ping Collector - Version 1.0.0 - ZDWare LLC ";
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutLabel.UseMnemonic = false;
            this.aboutLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            this.aboutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLabel_LinkClicked);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 220);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.Text = "Ping Collector Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.saveSettings);
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.optionsBox.ResumeLayout(false);
            this.optionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalControl)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.Label passwordStrengthLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button forgotPassButton;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.NumericUpDown intervalControl;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel aboutLabel;

    }
}

