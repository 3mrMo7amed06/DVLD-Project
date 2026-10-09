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
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private int _TestTypeID;
        private clsTestAppointment _Appointment;

        public frmTakeTest(
     int TestAppointmentID,
     int TestTypeID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
            _TestTypeID = TestTypeID;
        }

        private void Lea_Click(object sender, EventArgs e)
        {

        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _Appointment =
       clsTestAppointment.Find(_TestAppointmentID);

            if (_Appointment == null)
            {
                MessageBox.Show(
                    "Appointment not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }
            switch (_TestTypeID)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.VisionTest;
                    break;

                case 2:
                    pictureBox1.Image = Properties.Resources.WrittenTest;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.StreetTest;
                    break;

            }

            lblDate.Text =
        _Appointment.AppointmentDate.ToString("dd/MM/yyyy");

            lblFees.Text =
                _Appointment.PaidFees.ToString("0.00");
            int DLAID = -1;
            string ClassName = "";
            string Applicant = "";
            int Trial = 0;
            decimal TestFees = 0;
            if (clsTestAppointment.GetTestAppointmentInfo(
       _Appointment.LocalDrivingLicenseApplicationID,
       _TestTypeID,
       _TestAppointmentID,
       ref DLAID,
       ref ClassName,
       ref Applicant,
       ref Trial,
       ref TestFees))
            {
                lblDLAAppID.Text = DLAID.ToString();
                lblDClass.Text = ClassName;
                lblName.Text = Applicant;
                lblTrial.Text = Trial.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsTest.IsTestExist(_TestAppointmentID))
            {
                MessageBox.Show(
                    "A test has already been added for this appointment.",
                    "Cannot Add Test",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool TestResult = rbPass.Checked;

            string Notes = txtNotes.Text;

            int TestID =
                clsTest.AddNewTest(
                    _TestAppointmentID,
                    TestResult,
                    Notes,
                    clsGlobal.CurrentUser.UserID);

            if (TestID != -1)
            {
                lblTestID.Text = TestID.ToString();

                if (clsTestAppointment.LockTestAppointment(
                        _TestAppointmentID))
                {
                    MessageBox.Show(
                        "Test added successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Test was added, but the appointment could not be locked.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(
                    "Test was not added.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
