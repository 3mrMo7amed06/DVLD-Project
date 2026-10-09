using DVLD.Business;
using DVLD.Forms.ManageApplication;
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
    public partial class ctrDriverLicenseHistory : UserControl
    {
        public ctrDriverLicenseHistory()
        {
            InitializeComponent();
            dgvLocalLicenses.AutoGenerateColumns = false;
            dgvInternationalLicenses.AutoGenerateColumns = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void LoadLicenseHistory(int PersonID)
        {
            _LoadLocalLicenses(PersonID);
            _LoadInternationalLicenses(PersonID);
        }

        private void _LoadLocalLicenses(int PersonID)
        {
            DataTable dt =
                clsLicense.GetAllLicensesByPersonID(PersonID);

            dgvLocalLicenses.DataSource = dt;
            lblRecords.Text = dt.Rows.Count.ToString();
        }
        private void _LoadInternationalLicenses(int PersonID)
        {
            DataTable dt =
                clsInternationalLicense
                    .GetAllInternationalLicensesByPersonID(PersonID);

            dgvInternationalLicenses.DataSource = dt;
            lblRecords1.Text = dt.Rows.Count.ToString();
        }
        private void ctrDriverLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void lblRecords_Click(object sender, EventArgs e)
        {

        }

        private void dgvInternationalLicenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLocalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvLocalLicenses.ClearSelection();

                dgvLocalLicenses.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(
                    dgvLocalLicenses,
                    dgvLocalLicenses.PointToClient(Cursor.Position));
            }
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =
        Convert.ToInt32(
            dgvLocalLicenses.CurrentRow
                .Cells["colLicenseID"]
                .Value);

            frmShowLicense frm =
                new frmShowLicense(LicenseID);

            frm.ShowDialog();
        }
    }
}
