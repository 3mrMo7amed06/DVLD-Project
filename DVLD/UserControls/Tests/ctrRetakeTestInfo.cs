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
    public partial class ctrRetakeTestInfo : UserControl
    {
        public ctrRetakeTestInfo()
        {
            InitializeComponent();
        }
        public void LoadRetakeInfo(
    decimal TestFees,
    int Trial,
    int RetakeApplicationID)
        {
            if (Trial == 0)
            {
                lblRetakeAppFees.Text = "0.00";
                lblTotalFees.Text = TestFees.ToString("0.00");
                lblRetakeTestAppID.Text = "-";
            }
            else
            {
                decimal RetakeApplicationFees = 5.00m;

                lblRetakeAppFees.Text =
                    RetakeApplicationFees.ToString("0.00");

                lblTotalFees.Text =
                    (TestFees + RetakeApplicationFees).ToString("0.00");

                lblRetakeTestAppID.Text =
                    RetakeApplicationID.ToString();
            }
        }
        private void ctrRetakeTestInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
