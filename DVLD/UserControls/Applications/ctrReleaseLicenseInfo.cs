using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UserControls.Applications
{
    public partial class ctrReleaseLicenseInfo : UserControl
    {
        public ctrReleaseLicenseInfo()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public decimal FineFees
        {
            get
            {
                return Convert.ToDecimal(lblFineFees.Text);
            }
        }

        public decimal ApplicationFees
        {
            get
            {
                return Convert.ToDecimal(lblApplicationFees.Text);
            }
        }

        public decimal TotalFees
        {
            get
            {
                return Convert.ToDecimal(lblTotalFees.Text);
            }
        }

        public void LoadReleaseInfo(
            int DetainID,
            DateTime DetainDate,
            decimal FineFees,
            decimal ApplicationFees,
            decimal TotalFees,
            int LicenseID,
            string CreatedBy,
            int ReleaseApplicationID)
        {
            lblDetainID.Text =
                DetainID.ToString();

            lblDetainDate.Text =
                DetainDate.ToShortDateString();

            lblFineFees.Text =
                FineFees.ToString("0.00");

            lblApplicationFees.Text =
                ApplicationFees.ToString("0.00");

            lblTotalFees.Text =
                TotalFees.ToString("0.00");

            lblLicenseID.Text =
                LicenseID.ToString();

            lblCreatedBy.Text =
                CreatedBy;

            lblReleaseApplicationID.Text =
                ReleaseApplicationID.ToString();
        }

        private void ctrReleaseLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
