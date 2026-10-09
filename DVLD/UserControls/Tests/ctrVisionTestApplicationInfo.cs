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
    public partial class ctrVisionTestApplicationInfo : UserControl
    {
        private int _LocalDrivingLicenseApplicationID;
        public ctrVisionTestApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplicationID =
                LocalDrivingLicenseApplicationID;

            ctrDLAInfo1.LoadDLAInfo(
                LocalDrivingLicenseApplicationID);

            int ApplicationID =
         clsLocalDrivingLicenseApplication.GetApplicationID(
             LocalDrivingLicenseApplicationID);

            if (ApplicationID != -1)
            {
                ctrApplicationBasicInfo1.LoadApplicationInfo(
                    ApplicationID);
            }
        }
        private void ctrDLAInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ctrApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }

        private void ctrVisionTestApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
