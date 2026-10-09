using DVLD.Business;
using DVLD.Forms.ManageApplication;
using DVLD.Forms.PeopleManagement;
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
    public partial class frmMain : Form
    {
        private bool _IsSigningOut = false;
        public frmMain()
        {
            InitializeComponent();
        }
        private void CenterControls()
        {
            Control[] controls =
            {
        pbCar,
        lblTitle,
        lblDepartment,
        lblWelcome
    };

            int topPadding = menuStrip1.Height;
            int spacing = 20;

            int totalHeight = controls.Sum(c => c.Height);
            totalHeight += spacing * (controls.Length - 1);

            int availableHeight = ClientSize.Height - topPadding;

            int top = topPadding + (availableHeight - totalHeight) / 2;

            if (top < topPadding + 10)
            {
                top = topPadding + 10;
            }

            foreach (Control control in controls)
            {
                control.Left = (ClientSize.Width - control.Width) / 2;
                control.Top = top;

                top += control.Height + spacing;
            }
        }
        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                 frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
                 frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
        frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CenterControls(); 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            CenterControls(); 
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _IsSigningOut = true;
            clsGlobal.CurrentUser = null;
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_IsSigningOut)
            {
                Application.Exit();
            }
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmManageUsers frm2 = new frmManageUsers();
                  frm2.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);

            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                frmShowUserDetail frm = new frmShowUserDetail(clsGlobal.CurrentUser.UserID);

            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmManageApplicationTypes frm = new frmManageApplicationTypes();

            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
                frmManageTestTypes frm = new frmManageTestTypes();

                frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
             

                frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();

                 frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        { 

                  frmManageDriver frm = new frmManageDriver();

                   frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddInternationalDrivingLicenseApplication frm = new frmAddInternationalDrivingLicenseApplication();

            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmManageInternationalLicenses frm = new frmManageInternationalLicenses();

            frm.ShowDialog();

             
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense frm = new frmReplaceLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
               frm.ShowDialog();
        }

        private void manageDetainedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void releaseTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
