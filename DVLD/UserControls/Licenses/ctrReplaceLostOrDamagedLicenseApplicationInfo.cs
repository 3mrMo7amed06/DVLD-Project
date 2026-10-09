using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UserControls.Licenses
{
    public partial class ctrReplaceLostOrDamagedLicenseApplicationInfo : UserControl
    {
        public ctrReplaceLostOrDamagedLicenseApplicationInfo()
        {
            InitializeComponent();
        }
        public decimal ApplicationFees
        {
            set
            {
                lblApplicationFees.Text = value.ToString("0.00");
            }
        }
        public void LoadApplicationInfo(
    int RLApplicationID,
    DateTime ApplicationDate,
    decimal ApplicationFees,
    int ReplacedLicenseID,
    int OldLicenseID,
    string CreatedBy)
        {
            lblRLAppID.Text = RLApplicationID.ToString();

            lblApplicationDate.Text =
                ApplicationDate.ToShortDateString();

            lblApplicationFees.Text =
                ApplicationFees.ToString("0.00");

            lblReplacedLicenseID.Text =
                ReplacedLicenseID.ToString();

            lblOldLicenseID.Text =
                OldLicenseID.ToString();

            lblCreatedBy.Text = CreatedBy;
        }
        private void ctrReplaceLostOrDamagedLicenseApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
