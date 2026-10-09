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
    public partial class ctrDLAInfo : UserControl
    {
        private clsLocalDrivingLicenseApplication _DLA;
        public ctrDLAInfo()
        {
            InitializeComponent();
        }
        public void LoadDLAInfo(int LocalDrivingLicenseApplicationID)
        {
            _DLA = clsLocalDrivingLicenseApplication.GetDLAInfo(
                LocalDrivingLicenseApplicationID);

            if (_DLA == null)
                return;

            lblDLAID.Text =
                _DLA.LocalDrivingLicenseApplicationID.ToString();

            lblAppliedFor.Text =
                _DLA.ClassName;

            lblPassedTests.Text =
                _DLA.PassedTests.ToString() + "/3";
        }
        private void ctrDLAInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
