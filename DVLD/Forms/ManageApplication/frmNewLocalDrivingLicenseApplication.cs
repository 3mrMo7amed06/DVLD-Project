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
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _LocalDrivingLicenseApplication =
      new clsLocalDrivingLicenseApplication();
        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];

            using (Brush brush = new SolidBrush(Color.FromArgb(80, 160, 240)))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(
                    tabPage.Text,
                    e.Font,
                    brush,
                    e.Bounds,
                    sf);
            }
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void ctrUserAddEdit1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ctrPersonSelect1.SelectedPerson == null)
            {
                MessageBox.Show(
                    "Please select a person.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            tabControl1.SelectedTab = tpApplicationInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ctrPersonSelect1.SelectedPerson == null)
            {
                MessageBox.Show("Please select a person.");
                return;
            }
            if (clsLocalDrivingLicenseApplication.IsApplicationExist(
        ctrPersonSelect1.SelectedPerson.PersonID,
        ctrApplicationInfo1.LicenseClassID))
            {
                MessageBox.Show(
                    "This person already has an active application for this license class.",
                    "Application Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            _LocalDrivingLicenseApplication.ApplicantPersonID =
                ctrPersonSelect1.SelectedPerson.PersonID;

            _LocalDrivingLicenseApplication.ApplicationTypeID =
                ctrApplicationInfo1.ApplicationTypeID;

            _LocalDrivingLicenseApplication.ApplicationStatus = 1;

            _LocalDrivingLicenseApplication.ApplicationDate =
                DateTime.Now;

            _LocalDrivingLicenseApplication.LastStatusDate =
                DateTime.Now;

            _LocalDrivingLicenseApplication.PaidFees =
                ctrApplicationInfo1.PaidFees;

            _LocalDrivingLicenseApplication.CreatedByUserID =
                  clsGlobal.CurrentUser.UserID;

            _LocalDrivingLicenseApplication.LicenseClassID =
                ctrApplicationInfo1.LicenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                ctrApplicationInfo1.SetApplicationID(
     _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);

                MessageBox.Show(
                    "Application Saved Successfully.",
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Application was not saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
