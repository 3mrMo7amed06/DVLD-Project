using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Forms.ManageApplication
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID = -1;
        public frmShowInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();

            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (!ctrInternationalLicenseInfo1.LoadInternationalLicenseInfo(
                _InternationalLicenseID))
            {
                MessageBox.Show(
                    "International License was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
            }

        }

        private void ctrInternationalLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
