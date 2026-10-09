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
    public partial class ctrDetainLicenseInfo : UserControl
    {
        public decimal FineFees
        {
            get
            {
                decimal.TryParse(
                    txtFineFees.Text,
                    out decimal fees);

                return fees;
            }
        }

        public ctrDetainLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadDetainInfo(
           int DetainID,
           DateTime DetainDate,
           decimal FineFees,
           int LicenseID,
           string CreatedBy)
        {
            lblDetainID.Text = DetainID.ToString();

            lblDetainDate.Text =
                DetainDate.ToShortDateString();

            txtFineFees.Text =
                FineFees.ToString("0.00");

            lblLicenseID.Text =
                LicenseID.ToString();

            lblCreatedBy.Text =
                CreatedBy;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLicenseID_Click(object sender, EventArgs e)
        {

        }

        private void ctrDetainLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
