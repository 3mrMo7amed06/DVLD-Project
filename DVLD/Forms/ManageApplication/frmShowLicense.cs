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
    public partial class frmShowLicense : Form
    {
        private int _LicenseID;

        public frmShowLicense(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrLicenseInfo1.LoadLicenseInfo(_LicenseID);
        }
    }
}
