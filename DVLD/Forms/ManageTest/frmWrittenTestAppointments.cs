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
    public partial class frmWrittenTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public frmWrittenTestAppointments(
            int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID =
                LocalDrivingLicenseApplicationID;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RefreshAppointmentsList()
        {
            DataTable dt =
                clsTestAppointment.GetTestAppointments(
    _LocalDrivingLicenseApplicationID,
    2);

            dgvAppointments.DataSource = dt;

            dgvAppointments.ColumnHeadersVisible =
                dt.Rows.Count > 0;
        }


        private void dgvAppointments_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvAppointments.ClearSelection();

                dgvAppointments.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(
                    dgvAppointments,
                    dgvAppointments.PointToClient(Cursor.Position));
            }
        }

        private void frmWrittenTestAppointments_Load(object sender, EventArgs e)
        {
            ctrWrittenTestApplicationInfo1.LoadApplicationInfo(
        _LocalDrivingLicenseApplicationID);

            _RefreshAppointmentsList();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (clsTest.IsTestPassed(
           _LocalDrivingLicenseApplicationID,
           2))
            {
                MessageBox.Show(
                    "The Written Test has already been passed.",
                    "Cannot Add Appointment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            bool IsRetake =
        clsTest.IsTestFailed(
            _LocalDrivingLicenseApplicationID,2);

            if (clsTestAppointment.IsThereActiveAppointment(
                _LocalDrivingLicenseApplicationID, 2))
            {
                MessageBox.Show(
                    "There is already an active appointment for this application.",
                    "Cannot Add Appointment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            frmAddEditTestAppointment frm =
                new frmAddEditTestAppointment(
                    _LocalDrivingLicenseApplicationID,
                    2,  
                    IsRetake);

            frm.ShowDialog();

            _RefreshAppointmentsList();
        }

        private void ctrWrittenTestApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID =
        Convert.ToInt32(
            dgvAppointments.CurrentRow
                .Cells["colAppointmentID"].Value);

            frmTakeTest frm =
                new frmTakeTest(
                    TestAppointmentID,
                    2);

            frm.ShowDialog();

            _RefreshAppointmentsList();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID =
        Convert.ToInt32(
            dgvAppointments.CurrentRow
                .Cells["colAppointmentID"].Value);

            frmAddEditTestAppointment frm =
                new frmAddEditTestAppointment(
                    TestAppointmentID);

            frm.ShowDialog();

            _RefreshAppointmentsList();
        }
    }
}
