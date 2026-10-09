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
    public partial class ctrSearchLocalLicense : UserControl
    {
        public bool RequireClass3
        {
            get;
            set;
        }
        public int LicenseClassID
        {
            get { return ctrLicenseInfo1.LicenseClassID; }
        }
        public DateTime ExpirationDate
        {
            get { return ctrLicenseInfo1.ExpirationDate; }
        }
        public event Action<int, int, int> OnLicenseSelected;
        public event Action OnLicenseSelectionCleared;
        public ctrSearchLocalLicense()
        {
            InitializeComponent();
            RequireClass3 = true;
        }
        private bool _IsLicenseValid()
        {
            if (RequireClass3 &&
     ctrLicenseInfo1.LicenseClassID != 3)
            {
                MessageBox.Show(
                    "The license class must be Class 3.",
                    "Invalid License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (ctrLicenseInfo1.ExpirationDate < DateTime.Today)
            {
                MessageBox.Show(
                    "The license has expired.",
                    "Invalid License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (!ctrLicenseInfo1.IsActive)
            {
                MessageBox.Show(
                    "The license is not active.",
                    "Invalid License",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        private void ctrSearchLocalLicense_Load(object sender, EventArgs e)
        {

        }
        public void LoadLicenseInfo(int LicenseID)
        {
            OnLicenseSelectionCleared?.Invoke();

            if (!ctrLicenseInfo1.LoadLicenseInfo(LicenseID))
                return;

            if (!_IsLicenseValid())
                return;

            OnLicenseSelected?.Invoke(
                LicenseID,
                ctrLicenseInfo1.DriverID,
                ctrLicenseInfo1.PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OnLicenseSelectionCleared?.Invoke();
            if (!int.TryParse(txtLicenseID.Text, out int LicenseID))
            {
                MessageBox.Show(
                    "Please enter a valid License ID.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            LoadLicenseInfo(LicenseID);
        }
    }
}
