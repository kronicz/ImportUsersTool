namespace ModernUIProject.Class
{
    partial class LoginForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCenter = new MetroFramework.Controls.MetroPanel();
            this.txtDbPwd = new MetroFramework.Controls.MetroTextBox();
            this.txtDbUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtPrefix = new MetroFramework.Controls.MetroTextBox();
            this.txtDatabase = new MetroFramework.Controls.MetroTextBox();
            this.txtServer = new MetroFramework.Controls.MetroTextBox();
            this.btnLogIn = new MetroFramework.Controls.MetroButton();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txUsername = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCenter.Controls.Add(this.btnSave);
            this.pnlCenter.Controls.Add(this.txtDbPwd);
            this.pnlCenter.Controls.Add(this.txtDbUsername);
            this.pnlCenter.Controls.Add(this.txtPrefix);
            this.pnlCenter.Controls.Add(this.txtDatabase);
            this.pnlCenter.Controls.Add(this.txtServer);
            this.pnlCenter.Controls.Add(this.btnLogIn);
            this.pnlCenter.Controls.Add(this.txtPassword);
            this.pnlCenter.Controls.Add(this.txUsername);
            this.pnlCenter.HorizontalScrollbarBarColor = true;
            this.pnlCenter.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCenter.HorizontalScrollbarSize = 10;
            this.pnlCenter.Location = new System.Drawing.Point(0, 47);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(793, 525);
            this.pnlCenter.TabIndex = 0;
            this.pnlCenter.VerticalScrollbarBarColor = true;
            this.pnlCenter.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCenter.VerticalScrollbarSize = 10;
            // 
            // txtDbPwd
            // 
            this.txtDbPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtDbPwd.CustomButton.Image = null;
            this.txtDbPwd.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtDbPwd.CustomButton.Name = "";
            this.txtDbPwd.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtDbPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDbPwd.CustomButton.TabIndex = 1;
            this.txtDbPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDbPwd.CustomButton.UseSelectable = true;
            this.txtDbPwd.CustomButton.Visible = false;
            this.txtDbPwd.DisplayIcon = true;
            this.txtDbPwd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDbPwd.Lines = new string[0];
            this.txtDbPwd.Location = new System.Drawing.Point(257, 170);
            this.txtDbPwd.MaxLength = 32767;
            this.txtDbPwd.Name = "txtDbPwd";
            this.txtDbPwd.PasswordChar = '\0';
            this.txtDbPwd.PromptText = "Db Password";
            this.txtDbPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDbPwd.SelectedText = "";
            this.txtDbPwd.SelectionLength = 0;
            this.txtDbPwd.SelectionStart = 0;
            this.txtDbPwd.ShortcutsEnabled = true;
            this.txtDbPwd.Size = new System.Drawing.Size(279, 28);
            this.txtDbPwd.TabIndex = 14;
            this.txtDbPwd.UseSelectable = true;
            this.txtDbPwd.WaterMark = "Db Password";
            this.txtDbPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDbPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDbUsername
            // 
            this.txtDbUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtDbUsername.CustomButton.Image = null;
            this.txtDbUsername.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtDbUsername.CustomButton.Name = "";
            this.txtDbUsername.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtDbUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDbUsername.CustomButton.TabIndex = 1;
            this.txtDbUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDbUsername.CustomButton.UseSelectable = true;
            this.txtDbUsername.CustomButton.Visible = false;
            this.txtDbUsername.DisplayIcon = true;
            this.txtDbUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDbUsername.Lines = new string[0];
            this.txtDbUsername.Location = new System.Drawing.Point(257, 134);
            this.txtDbUsername.MaxLength = 32767;
            this.txtDbUsername.Name = "txtDbUsername";
            this.txtDbUsername.PasswordChar = '\0';
            this.txtDbUsername.PromptText = "Db Username";
            this.txtDbUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDbUsername.SelectedText = "";
            this.txtDbUsername.SelectionLength = 0;
            this.txtDbUsername.SelectionStart = 0;
            this.txtDbUsername.ShortcutsEnabled = true;
            this.txtDbUsername.Size = new System.Drawing.Size(279, 28);
            this.txtDbUsername.TabIndex = 13;
            this.txtDbUsername.UseSelectable = true;
            this.txtDbUsername.WaterMark = "Db Username";
            this.txtDbUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDbUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPrefix
            // 
            this.txtPrefix.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtPrefix.CustomButton.Image = null;
            this.txtPrefix.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtPrefix.CustomButton.Name = "";
            this.txtPrefix.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPrefix.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrefix.CustomButton.TabIndex = 1;
            this.txtPrefix.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrefix.CustomButton.UseSelectable = true;
            this.txtPrefix.CustomButton.Visible = false;
            this.txtPrefix.DisplayIcon = true;
            this.txtPrefix.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPrefix.Lines = new string[0];
            this.txtPrefix.Location = new System.Drawing.Point(257, 97);
            this.txtPrefix.MaxLength = 32767;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.PasswordChar = '\0';
            this.txtPrefix.PromptText = "TablePrefix";
            this.txtPrefix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrefix.SelectedText = "";
            this.txtPrefix.SelectionLength = 0;
            this.txtPrefix.SelectionStart = 0;
            this.txtPrefix.ShortcutsEnabled = true;
            this.txtPrefix.Size = new System.Drawing.Size(279, 28);
            this.txtPrefix.TabIndex = 12;
            this.txtPrefix.UseSelectable = true;
            this.txtPrefix.WaterMark = "TablePrefix";
            this.txtPrefix.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrefix.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtDatabase.CustomButton.Image = null;
            this.txtDatabase.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtDatabase.CustomButton.Name = "";
            this.txtDatabase.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtDatabase.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDatabase.CustomButton.TabIndex = 1;
            this.txtDatabase.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDatabase.CustomButton.UseSelectable = true;
            this.txtDatabase.CustomButton.Visible = false;
            this.txtDatabase.DisplayIcon = true;
            this.txtDatabase.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDatabase.Lines = new string[0];
            this.txtDatabase.Location = new System.Drawing.Point(257, 60);
            this.txtDatabase.MaxLength = 32767;
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PasswordChar = '\0';
            this.txtDatabase.PromptText = "Database";
            this.txtDatabase.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDatabase.SelectedText = "";
            this.txtDatabase.SelectionLength = 0;
            this.txtDatabase.SelectionStart = 0;
            this.txtDatabase.ShortcutsEnabled = true;
            this.txtDatabase.Size = new System.Drawing.Size(279, 28);
            this.txtDatabase.TabIndex = 11;
            this.txtDatabase.UseSelectable = true;
            this.txtDatabase.WaterMark = "Database";
            this.txtDatabase.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDatabase.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtServer
            // 
            this.txtServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtServer.CustomButton.Image = null;
            this.txtServer.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtServer.CustomButton.Name = "";
            this.txtServer.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtServer.CustomButton.TabIndex = 1;
            this.txtServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtServer.CustomButton.UseSelectable = true;
            this.txtServer.CustomButton.Visible = false;
            this.txtServer.DisplayIcon = true;
            this.txtServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtServer.Lines = new string[0];
            this.txtServer.Location = new System.Drawing.Point(257, 24);
            this.txtServer.MaxLength = 32767;
            this.txtServer.Name = "txtServer";
            this.txtServer.PasswordChar = '\0';
            this.txtServer.PromptText = "SQL Server";
            this.txtServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtServer.SelectedText = "";
            this.txtServer.SelectionLength = 0;
            this.txtServer.SelectionStart = 0;
            this.txtServer.ShortcutsEnabled = true;
            this.txtServer.Size = new System.Drawing.Size(279, 28);
            this.txtServer.TabIndex = 10;
            this.txtServer.UseSelectable = true;
            this.txtServer.WaterMark = "SQL Server";
            this.txtServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogIn.Location = new System.Drawing.Point(439, 312);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(97, 33);
            this.btnLogIn.TabIndex = 8;
            this.btnLogIn.Text = "&Login";
            this.btnLogIn.UseSelectable = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.DisplayIcon = true;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(257, 278);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PromptText = "Password";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(279, 28);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "Password";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txUsername
            // 
            this.txUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.txUsername.CustomButton.Image = null;
            this.txUsername.CustomButton.Location = new System.Drawing.Point(253, 2);
            this.txUsername.CustomButton.Name = "";
            this.txUsername.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txUsername.CustomButton.TabIndex = 1;
            this.txUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txUsername.CustomButton.UseSelectable = true;
            this.txUsername.CustomButton.Visible = false;
            this.txUsername.DisplayIcon = true;
            this.txUsername.Lines = new string[0];
            this.txUsername.Location = new System.Drawing.Point(257, 244);
            this.txUsername.MaxLength = 32767;
            this.txUsername.Name = "txUsername";
            this.txUsername.PasswordChar = '\0';
            this.txUsername.PromptText = "Username";
            this.txUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txUsername.SelectedText = "";
            this.txUsername.SelectionLength = 0;
            this.txUsername.SelectionStart = 0;
            this.txUsername.ShortcutsEnabled = true;
            this.txUsername.Size = new System.Drawing.Size(279, 28);
            this.txUsername.TabIndex = 6;
            this.txUsername.UseSelectable = true;
            this.txUsername.WaterMark = "Username";
            this.txUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Location = new System.Drawing.Point(439, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 33);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "&Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCenter);
            this.Name = "LoginForm";
            this.Size = new System.Drawing.Size(793, 610);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlCenter;
        private MetroFramework.Controls.MetroButton btnLogIn;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTextBox txUsername;
        private MetroFramework.Controls.MetroTextBox txtServer;
        private MetroFramework.Controls.MetroTextBox txtDatabase;
        private MetroFramework.Controls.MetroTextBox txtDbPwd;
        private MetroFramework.Controls.MetroTextBox txtDbUsername;
        private MetroFramework.Controls.MetroTextBox txtPrefix;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}
