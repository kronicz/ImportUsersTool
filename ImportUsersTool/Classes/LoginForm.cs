using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using MetroFramework.Forms;
using ImportUsersTool.Classes;
using SuperOffice;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;

namespace ModernUIProject.Class
{

    public partial class LoginForm : pnlSlider
    {
        public event EventHandler LogInSuccess;
        

        public LoginForm(Form owner)
            : base(owner)
        {
            InitializeComponent();

            for (int i = 3; i < 13; i++)
            {
                MetroTile _tile = new MetroTile();
                _tile.Size = new Size(30, 30);
                _tile.Tag = i;
                _tile.Style = (MetroColorStyle)i;
                _tile.Click += _tile_Click;

            }
            var superoffice_db = ConfigurationManager.GetSection("SuperOffice/Data/Database") as NameValueCollection;
            var server = superoffice_db.Get("Server");
            var db = superoffice_db.Get("Database");
            var tblPrefix = superoffice_db.Get("TablePrefix");
            txtDatabase.Text = db;
            txtPrefix.Text = tblPrefix;
            txtServer.Text = server;

            var superoffice_user = ConfigurationManager.GetSection("SuperOffice/Data/Explicit") as NameValueCollection;
            var db_user = superoffice_user.Get("DBUser");
            var db_pwd = superoffice_user.Get("DBPassword");
            txtDbUsername.Text = db_user;
            txtDbPwd.Text = db_pwd;

            if (server == "" && db == "" && tblPrefix == "" && db_user == "" && db_pwd == "")
                btnLogIn.Enabled = false;
        }

        void _tile_Click(object sender, EventArgs e)
        {
            ((MetroForm)this.Parent).StyleManager.Style = (MetroColorStyle)((MetroTile)sender).Tag;
        }

        public void ShowSettings()
        {

            pnlCenter.Enabled = false;
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txUsername.Text == "" || txtPassword.Text == "")
            {
                //MetroMessageBox.Show(this, "Your message here.", "Title Here", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                MetroMessageBox.Show(this, "Please provide Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else
            {
                Importer.Username = txUsername.Text;
                Importer.Password = txtPassword.Text;
                //Sosession
                try
                {
                    using (var _session = SoSession.Authenticate(txUsername.Text, txtPassword.Text))
                    {
                        string sessionString = string.Empty;

                        EventHandler handler = LogInSuccess;
                        if (handler != null) handler(this, e);
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message + " try again", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "" && txtDatabase.Text != "" && txtPrefix.Text != "" && txtDbUsername.Text != "" && txtDbPwd.Text != "")
            {
                MetroMessageBox.Show(this, "You must restart for changes to take effect", "Configuration Updated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                xmlDoc.SelectSingleNode("//SuperOffice/Data/Database/add[@key='Server']").Attributes["value"].Value = txtServer.Text;
                xmlDoc.SelectSingleNode("//SuperOffice/Data/Database/add[@key='Database']").Attributes["value"].Value = txtDatabase.Text;
                xmlDoc.SelectSingleNode("//SuperOffice/Data/Database/add[@key='TablePrefix']").Attributes["value"].Value = txtPrefix.Text;
                xmlDoc.SelectSingleNode("//SuperOffice/Data/Explicit/add[@key='DBUser']").Attributes["value"].Value = txtDbUsername.Text;
                xmlDoc.SelectSingleNode("//SuperOffice/Data/Explicit/add[@key='DBPassword']").Attributes["value"].Value = txtDbPwd.Text;

                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                ConfigurationManager.RefreshSection("SuperOffice/Data/Database");
                ConfigurationManager.RefreshSection("SuperOffice/Data/Explicit");
                btnLogIn.Enabled = false;
            }
            else
            {
                MetroMessageBox.Show(this, "Error: Please input values in Database Connection", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLogIn.Enabled = false;
            }
        }
    }
}
