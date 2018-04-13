using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ModernUIProject.Class;
using ImportUsersTool.Classes;
using SuperOffice;
using SuperOffice.CRM.Data;
using SuperOffice.Data;
using SuperOffice.Data.SQL;
using MetroFramework;
using SuperOffice.CRM.Administration;
using SuperOffice.License;
using SuperOffice.CRM.Rows;
using SuperOffice.CRM.Cache;
using MetroFramework.Controls;

namespace ImportUsersTool
{
    public partial class MainForm : MetroForm
    {
        LoginForm _login = null;
        SettingsForm _settings = null;
        DataTable dtUsers;
        FileParser p;
        MetroCheckBox headerCheckbox = new MetroCheckBox();
        int selectedBox = 0;
        public MainForm()
        {
            InitializeComponent();

            this.Shown += MainForm_Shown;

            _login = new LoginForm(this);
            _login.LogInSuccess += _login_LogInSuccess;
            _login.swipe();
            mtLoadFile.Enabled = false;
            txtSearch.Visible = false;
            mtProcess.Enabled = false;
        }

        void _login_LogInSuccess(object sender, EventArgs e)
        {
            _login.swipe(false);
        }
        void _settings_SettingSuccess(object sender, EventArgs e)
        {
            _settings.swipe(false);
            mtLoadFile.Enabled = true;
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Point headerCellLocation = dtUsersList.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckbox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);

            headerCheckbox.Size = new Size(15, 15);
            headerCheckbox.Click += new EventHandler(HeaderCheckbox_Clicked);
            dtUsersList.Controls.Add(headerCheckbox);

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = "";
            checkboxColumn.Width = 30;
            checkboxColumn.Name = "selectColumn";
            dtUsersList.Columns.Insert(0, checkboxColumn);

            dtUsersList.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }
        private void HeaderCheckbox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dtUsersList.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in dtUsersList.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["selectColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckbox.Checked;
                if (headerCheckbox.Checked)
                    selectedBox = dtUsersList.Rows.Count;
                else
                    selectedBox = 0;
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in dtUsersList.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["selectColumn"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        if (selectedBox > 0)
                            selectedBox--;
                        break;
                    }
                }
                headerCheckbox.Checked = isChecked;
                selectedBox++;
            }
        }
        private void mtTileSettings_Click(object sender, EventArgs e)
        {
            _settings = new SettingsForm(this);
            _settings.SettingSuccess += _settings_SettingSuccess;
            _settings.swipe();
        }

        private void txtSearch_KeyUp(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = (DataTable)dtUsersList.DataSource;
            dt.DefaultView.RowFilter = string.Format("FirstName like '%{0}%' or LastName like '%{0}%'", search);
        }
        private void mtLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Importer.Contacts = new Dictionary<string, int>();
                using (var _session = SoSession.Authenticate(Importer.Username, Importer.Password))
                {
                    DataGridViewComboBoxColumn rolesColumn = (DataGridViewComboBoxColumn)dtUsersList.Columns["Role"];
                    rolesColumn.DataSource = Importer.Roles.ToList();
                    rolesColumn.DisplayMember = "Key";

                    DataGridViewComboBoxColumn groupsColumn = (DataGridViewComboBoxColumn)dtUsersList.Columns["UserGroup"];
                    groupsColumn.DataSource = Importer.Groups.ToList();
                    groupsColumn.DisplayMember = "Key";
                    p = new FileParser(openFileDialog.FileName);

                    MetroMessageBox.Show(this, "File parsed, " + p.UserInfos.Count.ToString() + " users read\n", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (ImportUserInfo ui in p.UserInfos)
                    {
                        ContactTableInfo cti = TablesInfo.GetContactTableInfo();
                        OwnerContactLinkTableInfo octi = TablesInfo.GetOwnerContactLinkTableInfo();
                        Select findOc = S.NewSelect("Find OC");

                        findOc.JoinRestriction.InnerJoin(cti.ContactId.Equal(octi.ContactId));

                        // if contact name contains a comma, assume that pre-comma is name and post-comma is department (db & file are set up that way)
                        if (ui.Company.Contains(","))
                            findOc.Restriction = cti.Name.Equal(S.Parameter(ui.Company.Split(',')[0].Trim())).
                                And(cti.Department.Equal(S.Parameter(ui.Company.Split(',')[1].Trim())));
                        else
                            findOc.Restriction = cti.Name.Equal(S.Parameter(ui.Company));

                        findOc.ReturnFields.Add(cti.ContactId);

                        int ocId = QueryExecutionHelper.ExecuteTypedScalar<int>(findOc);

                        if (ocId == 0)
                        {
                            //MessageBox.Show("Owner company " + ui.Company + "(referenced by " + ui.UID + ")  does not exist OR is not an Owner Company - setting to License Owner " + SoSystemInfo.GetCurrent().CompanyName);
                            ui.Company = SoSystemInfo.GetCurrent().CompanyName;
                            if (!Importer.Contacts.ContainsKey(SoSystemInfo.GetCurrent().CompanyName))
                                Importer.Contacts.Add(ui.Company, SoSystemInfo.GetCurrent().CompanyId);
                        }
                        else if (!Importer.Contacts.ContainsKey(ui.Company))
                            Importer.Contacts.Add(ui.Company, ocId);

                        if (!Importer.Roles.ContainsKey(ui.Role))
                            ui.Role = Importer.DefaultRole;
                        if (!Importer.Groups.ContainsKey(ui.Group))
                            ui.Group = Importer.DefaultGroup;
                    }
                    Dictionary<string, int> users = Importer.FindUsers();

                    dtUsersList.AutoGenerateColumns = false;
                    dtUsersList.Columns["FirstName"].DataPropertyName = "FirstName";
                    dtUsersList.Columns["LastName"].DataPropertyName = "LastName";
                    dtUsersList.Columns["FullName"].DataPropertyName = "FullName";
                    dtUsersList.Columns["UserName"].DataPropertyName = "UID";
                    dtUsersList.Columns["Email"].DataPropertyName = "Email";
                    dtUsersList.Columns["Role"].DataPropertyName = "Role";
                    dtUsersList.Columns["UserGroup"].DataPropertyName = "Group";
                    dtUsersList.Columns["Company"].DataPropertyName = "Company";
                    dtUsersList.Columns["AssociateId"].DataPropertyName = "AssociateId";
                    dtUsers = Importer.ConvertToDataTable<ImportUserInfo>(p.UserInfos);
                    dtUsersList.DataSource = dtUsers;
                    //dtUsersList.DataSource = p.UserInfos;
                    //progressBar.Value = 0;
                    foreach (DataGridViewRow item in dtUsersList.Rows)
                    {
                        string username = item.Cells["UserName"].Value.ToString();
                        string role = item.Cells["Role"].Value.ToString();
                        string group = item.Cells["UserGroup"].Value.ToString();
                        if (!Importer.Roles.ContainsKey(role))
                            role = Importer.DefaultRole;
                        if (!Importer.Groups.ContainsKey(group))
                            group = Importer.DefaultGroup;

                        item.Cells["Role"].Value = role;
                        item.Cells["UserGroup"].Value = group;
                        if (users.ContainsKey(username))
                        {
                            item.Cells["Status"].Value = "Exists";
                            item.Cells["AssociateId"].Value = users[username];
                            string license = Importer.GetLicense(users[username], Importer.LookupList);
                            item.Cells["AssignedLicenses"].Value = license;
                        }
                        else
                        {
                            item.Cells["AssociateId"].Value = DBNull.Value;
                            item.Cells["Status"].Value = "New";
                            item.Cells["AssignedLicenses"].Value = "";
                        }
                    }

                }
                txtSearch.Text = "";
                txtSearch.Visible = true;
                mtProcess.Enabled = true;
            }
        }
        private bool createUser(string firstname, string lastname, string fullname, string username, string email, string role, string group, string company, string license, DataGridViewRow item)
        {
            bool result = false;
            try
            {
                // find person by firstname, lastname & owner contact
                SuperOffice.CRM.Entities.Person.CustomSearch pc = new SuperOffice.CRM.Entities.Person.CustomSearch();
                pc.Restriction = pc.TableInfo.Firstname.Equal(S.Parameter(firstname)).
                    And(pc.TableInfo.Lastname.Equal(S.Parameter(lastname))).
                    And(pc.TableInfo.ContactId.Equal(S.Parameter(Importer.Contacts[company])));

                SuperOffice.CRM.Entities.Person p = SuperOffice.CRM.Entities.Person.GetFromCustomSearch(pc);

                // we either found an existing person, or got a blank, ready-to-populate one
                if (p.IsNew)
                {
                    p.SetDefaults(Importer.Contacts[company]);

                    p.Firstname = firstname;
                    p.Lastname = lastname;
                }

                // always set userid into number field, for convenience
                p.PersonNumber = username;

                // find existing email, or create a new one
                EmailRow em = null;
                if (p.Emails.Count == 0)
                {
                    em = p.Emails.AddNew();
                    em.SetDefaults();
                }
                else
                    em = p.Emails[0];

                // always set correct email; we have just the one address
                em.EmailAddress = email;
                em.Protocol = "SMTP";

                // save complete person entity
                p.Save();

                // if person is associate - get him/her; otherwise create a new SoUser
                SoUser user;
                if (AssociateCache.GetCurrent().IsPersonAssociate(p.PersonId))
                {
                    user = SoUser.ManageUserFromPersonId(p.PersonId)[0];
                }
                else
                {
                    user = SoUser.CreateNew(p.PersonId, UserType.InternalAssociate);
                }

                // set our various properties
                user.SetPassword(username);
                user.GroupIdx = Importer.Groups[group];
                user.OtherGroupIds = new int[0];

                user.RoleIdx = Importer.Roles[role];
                user.LogonName = username;
                user.Tooltip = fullname + " (" + company + ")";

                // add licenses
                if (user.GetModuleLicense("SuperOffice", Importer.DefaultLicense).CanAssign)
                {
                    user.GetModuleLicense("SuperOffice", Importer.DefaultLicense).Assigned = true;
                    item.Cells["AssignedLicenses"].Value = "Assigned Default";
                }
                else
                    item.Cells["AssignedLicenses"].Value = "Cannot Assign";
                //user.GetModuleLicense(SoLicenseNames.SuperLicenseServicePro).Assigned = true;
                /*user.GetModuleLicense(SoLicenseNames.User).Assigned = true;
                user.GetModuleLicense(SoLicenseNames.Web).Assigned = true;*/
                user.GetModuleLicense(SoLicenseNames.VisibleFor).Assigned = true;

                // save the user
                user.Save();
                result = true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
        private bool updateUser(string associateId, string firstname, string lastname, string fullname, string username, string email, string role, string group, string license, DataGridViewRow item)
        {
            bool result = false;
            try
            {
                SoUser user = SoUser.ManageUser(Convert.ToInt32(associateId));
                SuperOffice.CRM.Entities.Person p = user.Person;
                p.Firstname = firstname;
                p.Lastname = lastname;
                //p.PersonNumber = username;
                String pwd = username;
                EmailRow em = null;
                if (p.Emails.Count == 0)
                {
                    em = p.Emails.AddNew();
                    em.SetDefaults();
                }
                else
                    em = p.Emails[0];

                // always set correct email; we have just the one address
                em.EmailAddress = email;
                em.Protocol = "SMTP";

                // save complete person entity
                p.Save();
                //Console.WriteLine("\tPerson/email done");

                // set our various properties
                user.SetPassword(pwd);
                user.GroupIdx = Importer.Groups[group];
                user.OtherGroupIds = new int[0];

                user.RoleIdx = Importer.Roles[role];
                user.LogonName = username;
                user.Tooltip = fullname + " (" + SoSystemInfo.GetCurrent().CompanyName + ")";

                // add licenses
                if (user.GetModuleLicense("SuperOffice", Importer.DefaultLicense).CanAssign)
                {
                    user.GetModuleLicense("SuperOffice", Importer.DefaultLicense).Assigned = true;
                    item.Cells["AssignedLicenses"].Value = "Assigned Default";
                }
                else
                    item.Cells["AssignedLicenses"].Value = "Cannot Assign";
                //user.GetModuleLicense(SoLicenseNames.SuperLicenseServicePro).Assigned = true;
                /*user.GetModuleLicense(SoLicenseNames.User).Assigned = true;
                user.GetModuleLicense(SoLicenseNames.Web).Assigned = true;*/
                user.GetModuleLicense(SoLicenseNames.VisibleFor).Assigned = true;

                // save the user
                user.Save();
                //Console.WriteLine("\tUser saved\n");
                result = true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void mtProcess_Click(object sender, EventArgs e)
        {
            using (SoSession.Authenticate(Importer.Username, Importer.Password))
            {
                progressBar.Value = 0;
                progressBar.Maximum = selectedBox;
                progressBar.Step = 1;
                bool noneSelected = true;
                foreach (DataGridViewRow item in dtUsersList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["selectColumn"].Value) == true)
                    {
                        string associateId = item.Cells["AssociateId"].Value.ToString();
                        string firstname = item.Cells["FirstName"].Value.ToString();
                        string lastname = item.Cells["LastName"].Value.ToString();
                        string fullname = item.Cells["FullName"].Value.ToString();
                        string username = item.Cells["UserName"].Value.ToString();
                        string email = item.Cells["Email"].Value.ToString();
                        string role = item.Cells["Role"].Value.ToString();
                        string group = item.Cells["UserGroup"].Value.ToString();
                        string company = item.Cells["Company"].Value.ToString();
                        bool processed = false;
                        if (associateId != "")
                        {
                            processed = updateUser(associateId, firstname, lastname, fullname, username, email, role, group, Importer.DefaultLicense, item);
                        }
                        else
                        {
                            processed = createUser(firstname, lastname, fullname, username, email, role, group, company, Importer.DefaultLicense, item);
                        }
                        if (processed)
                        {
                            progressBar.PerformStep();
                            item.Cells["Status"].Value = "Processed";
                        }
                        noneSelected = false;
                    }
                }
                if (noneSelected)
                    MetroMessageBox.Show(this, "No entries selected", "No Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
