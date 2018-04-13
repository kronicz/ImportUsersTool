using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework;
using SuperOffice.CRM.Services;
using SuperOffice;
using SuperOffice.License;

namespace ImportUsersTool.Classes
{
    public partial class SettingsForm : pnlSlider
    {
        public event EventHandler SettingSuccess;
        public Dictionary<string, int> _contacts = new Dictionary<string, int>();
        public Dictionary<string, int> _roles = new Dictionary<string, int>();
        public Dictionary<string, int> _groups = new Dictionary<string, int>();
        SelectableMDOListItem[] roles;
        UserGroup[] groups;

        public SettingsForm(Form owner)
            : base(owner)
        {
            InitializeComponent();

            for (int i = 3; i < 13; i++)
            {
                MetroTile _tile = new MetroTile();
                _tile.Size = new Size(30, 30);
                _tile.Tag = i;
                _tile.Style = (MetroColorStyle)i;
                //_tile.Click += _tile_Click;

            }

            using (var session = SoSession.Authenticate(Importer.Username, Importer.Password))
            {
                UserAgent _agent = new UserAgent();
                roles = _agent.GetAllRoles(SuperOffice.Data.RoleType.Employee);
                for (int i = 0; i < roles.Length; i++)
                    _roles.Add(roles[i].Name, roles[i].Id);

                groups = _agent.GetAllUserGroups(false);
                for (int j = 0; j < groups.Length; j++)
                    _groups.Add(groups[j].Value, groups[j].Id);

                cmbRole.DataSource = roles.ToList();
                cmbRole.DisplayMember = "Name";
                cmbGroup.DataSource = groups.ToList();
                cmbGroup.DisplayMember = "Value";

                Importer.Groups = _groups;
                Importer.Roles = _roles;

                LicenseAgent agent = new LicenseAgent();
                ExtendedLicenseInfo extendedLicense = agent.GetLicenseFromDB("SuperOffice");
                ExtendedModuleLicense[] moduleLicense = extendedLicense.ExtendedModuleLicenses;
                ExtendedModuleLicense sales_users;
                ExtendedModuleLicense service_users;
                ExtendedModuleLicense complete_users;
                sales_users = moduleLicense.FirstOrDefault(c => c.Current.ModuleName.Equals(SoLicenseNames.SuperLicenseSalesPro.Substring(SoLicenseNames.SuperLicenseSalesPro.LastIndexOf('.') + 1)));
                service_users = moduleLicense.FirstOrDefault(c => c.Current.ModuleName.Equals(SoLicenseNames.SuperLicenseServicePro.Substring(SoLicenseNames.SuperLicenseServicePro.LastIndexOf('.') + 1)));
                complete_users = moduleLicense.FirstOrDefault(c => c.Current.ModuleName.Equals(SoLicenseNames.SuperLicenseComplete.Substring(SoLicenseNames.SuperLicenseComplete.LastIndexOf('.') + 1)));
                Dictionary<string,string> lic = new Dictionary<string, string>();
                List<string> LookupList = new List<string>();

                if (sales_users != null)
                {
                    lic.Add(sales_users.Current.ModuleDescription + " (" + sales_users.NumberOfLicensesTotal + ")", sales_users.Current.ModuleName);
                    LookupList.Add(sales_users.Current.ModuleName);
                }
                if (service_users != null)
                {
                    lic.Add(service_users.Current.ModuleDescription + " (" + service_users.NumberOfLicensesTotal + ")", service_users.Current.ModuleName);
                    LookupList.Add(service_users.Current.ModuleName);
                }
                if (complete_users != null)
                {
                    lic.Add(complete_users.Current.ModuleDescription + " (" + complete_users.NumberOfLicensesTotal + ")", complete_users.Current.ModuleName);
                    LookupList.Add(complete_users.Current.ModuleName);
                }
                cmbLicense.DisplayMember = "Key";
                cmbLicense.DataSource = lic.ToList();
                Importer.LookupList = LookupList;
            }

            if(Importer.DefaultConfig == true)
            {
                cmbLicense.SelectedIndex = cmbLicense.FindString(Importer.DefaultLicense);
                cmbGroup.SelectedIndex = cmbGroup.FindString(Importer.DefaultGroup);
                cmbRole.SelectedIndex = cmbRole.FindString(Importer.DefaultRole);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Importer.DefaultConfig = true;
            Importer.DefaultGroup = cmbGroup.GetItemText(cmbGroup.SelectedItem);
            Importer.DefaultRole = cmbRole.GetItemText(cmbGroup.SelectedItem);
            Importer.DefaultLicense = ((KeyValuePair<string, string>)cmbLicense.SelectedValue).Value.ToString();//cmbLicense.GetItemText(cmbLicense.SelectedItem);

            EventHandler handler = SettingSuccess;
            if (handler != null) handler(this, e);
        }
    }
}
