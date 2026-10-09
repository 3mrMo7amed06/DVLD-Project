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

namespace DVLD.Forms.ManageApplication
{
    public partial class frmManageDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicenses;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            dgvDetainedLicenses.AutoGenerateColumns = false;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }


        private void _RefreshDetainedLicensesList()
        {
            _dtDetainedLicenses =
                clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource =
                _dtDetainedLicenses;

            _UpdateRecordsCount();
        }
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshDetainedLicensesList();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();

            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(FilterValue))
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }

            switch (cbFilterBy.SelectedIndex)
            {
                case 1:  

                    if (FilterValue.ToLower() == "yes")
                    {
                        _dtDetainedLicenses.DefaultView.RowFilter =
                            "IsReleased = true";
                    }
                    else if (FilterValue.ToLower() == "no")
                    {
                        _dtDetainedLicenses.DefaultView.RowFilter =
                            "IsReleased = false";
                    }
                    else
                    {
                        _dtDetainedLicenses.DefaultView.RowFilter = "";
                    }

                    break;

                case 2:  
                    _dtDetainedLicenses.DefaultView.RowFilter =
                        $"N_NO LIKE '%{FilterValue}%'";
                    break;

                case 3:  
                    _dtDetainedLicenses.DefaultView.RowFilter =
                        $"FullName LIKE '%{FilterValue}%'";
                    break;

                case 4:  

                    if (int.TryParse(FilterValue, out int ReleaseAppID))
                    {
                        _dtDetainedLicenses.DefaultView.RowFilter =
                            $"ReleaseAppID = {ReleaseAppID}";
                    }
                    else
                    {
                        _dtDetainedLicenses.DefaultView.RowFilter = "";
                    }

                    break;
            }

            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Release Application ID")
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void dgvDetainedLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvDetainedLicenses.ClearSelection();

                dgvDetainedLicenses.Rows[e.RowIndex].Selected = true;
                bool IsReleased =
         Convert.ToBoolean(
             dgvDetainedLicenses.CurrentRow
             .Cells["colIsReleased"].Value);

                releaseDetainedLicenseToolStripMenuItem.Enabled =
                    !IsReleased;

                contextMenuStrip1.Show(
                    dgvDetainedLicenses,
                    dgvDetainedLicenses.PointToClient(Cursor.Position));
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID =
        Convert.ToInt32(
            dgvDetainedLicenses.CurrentRow.Cells["colLicenseID"].Value);

            frmShowLicense frm =
                new frmShowLicense(LicenseID);

            frm.ShowDialog();
            
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =
       Convert.ToInt32(
           dgvDetainedLicenses.CurrentRow
           .Cells["colPersonID"].Value);

            frmPersonLicenseHistory frm =
                new frmPersonLicenseHistory(PersonID);

            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LicenseID =
                Convert.ToInt32(
                    dgvDetainedLicenses.CurrentRow
                    .Cells["colLicenseID"].Value);

            frmReleaseLicense frm =
                new frmReleaseLicense(LicenseID);

            frm.ShowDialog();

            _RefreshDetainedLicensesList();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm =
                new frmDetainLicense();

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btnRelase_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm =
                new frmReleaseLicense();

            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }
    }
}
