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
    public partial class frmManageInternationalLicenses : Form
    {
        private DataTable _dtInternationalLicenses;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtInternationalLicenses.DefaultView.Count.ToString();
        }

        private void _RefreshInternationalLicensesList()
        {
            _dtInternationalLicenses =
        clsInternationalLicense.GetAllInternationalLicenses();

            dgvInternationalLicenses.DataSource =
                _dtInternationalLicenses;

            _UpdateRecordsCount();
        }

        
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshInternationalLicensesList();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();

            txtFilterValue.Visible =
                (cbFilterBy.SelectedIndex != 0);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string value = txtFilterValue.Text.Trim();

            if (cbFilterBy.SelectedIndex == 0 ||
                value == "")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";

                _UpdateRecordsCount();

                return;
            }

            switch (cbFilterBy.Text)
            {
                case "International License ID":

                    if (int.TryParse(value, out int InternationalLicenseID))
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter =
                            $"InternationalLicenseID = {InternationalLicenseID}";
                    }
                    else
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter = "";
                    }

                    break;

                case "Application ID":

                    if (int.TryParse(value, out int ApplicationID))
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter =
                            $"ApplicationID = {ApplicationID}";
                    }
                    else
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter = "";
                    }

                    break;

                case "Driver ID":

                    if (int.TryParse(value, out int DriverID))
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter =
                            $"DriverID = {DriverID}";
                    }
                    else
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter = "";
                    }

                    break;

                case "Local License ID":

                    if (int.TryParse(value, out int LicenseID))
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter =
                            $"IssuedUsingLocalLicenseID = {LicenseID}";
                    }
                    else
                    {
                        _dtInternationalLicenses.DefaultView.RowFilter = "";
                    }

                    break;
            }

            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "International License ID" ||
        cbFilterBy.Text == "Application ID" ||
        cbFilterBy.Text == "Driver ID" ||
        cbFilterBy.Text == "Local License ID")
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddInternationalDrivingLicenseApplication frm = new frmAddInternationalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshInternationalLicensesList();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID =
      Convert.ToInt32(
          dgvInternationalLicenses.CurrentRow
              .Cells["colInternationalLicenseID"]
              .Value);

            frmShowInternationalLicenseInfo frm =
                new frmShowInternationalLicenseInfo(
                    InternationalLicenseID);

            frm.ShowDialog();
        }

        private void dgvInternationalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvInternationalLicenses.ClearSelection();

                dgvInternationalLicenses.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(
                    dgvInternationalLicenses,
                    dgvInternationalLicenses.PointToClient(Cursor.Position));
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID =
        Convert.ToInt32(
            dgvInternationalLicenses.CurrentRow
                .Cells["colDriverID"]
                .Value);

            int PersonID =
                clsDriver.GetPersonIDByDriverID(DriverID);

            if (PersonID == -1)
            {
                MessageBox.Show(
                    "Person was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            frmPersonLicenseHistory frm =
                new frmPersonLicenseHistory(PersonID);

            frm.ShowDialog();
        }
    }
}
