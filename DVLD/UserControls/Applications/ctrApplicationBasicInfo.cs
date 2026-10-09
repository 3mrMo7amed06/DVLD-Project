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
    public partial class ctrApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;
        public ctrApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);

            if (_Application == null)
                return;

            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblApplicationStatus.Text = _Application.ApplicationStatus;
            lblApplicationFees.Text = _Application.PaidFees.ToString("0.00");
            lblApplicationType.Text = _Application.ApplicationType;
            lblApplicant.Text = _Application.Applicant;
            lblApplicationDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");
            lblStatusDate.Text = _Application.LastStatusDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = _Application.CreatedBy;
        }
        private void ctrApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void lnkShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Application == null)
                return;

            frmShowPersonDetails frm =
                new frmShowPersonDetails(_Application.ApplicantPersonID);

            frm.ShowDialog();
        }
    }
}
