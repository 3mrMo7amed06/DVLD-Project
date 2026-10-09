using DVLD.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrApplicationInfo : UserControl
    {
         
        public int LicenseClassID
        {
            get
            {
                return Convert.ToInt32(cbLicenseClass.SelectedValue);
            }
        }
        public int ApplicationTypeID
        {
            get
            {
                return 1;
            }
        }
        public decimal PaidFees
        {
            get
            {
                return Convert.ToDecimal(lblApplicationFees.Text);
            }
        }
        public void SetApplicationID(int ApplicationID)
        {
            lblLocalDrivingLicenseApplicationID.Text =
                ApplicationID.ToString();
        }
        public ctrApplicationInfo()
        {
            InitializeComponent();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
        private void _LoadLicenseClasses()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            cbLicenseClass.DataSource = dt;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            cbLicenseClass.SelectedIndex = 2;
        }
        private void ctrApplicationInfo_Load(object sender, EventArgs e)
        {
            _LoadLicenseClasses();
             lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }
    }
}
