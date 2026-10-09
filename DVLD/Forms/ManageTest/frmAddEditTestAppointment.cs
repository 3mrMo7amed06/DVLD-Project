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
    public partial class frmAddEditTestAppointment : Form

    {
        private enum enMode
        {
            AddNew,
            Update
        }
        private int _TestTypeID = -1;
        private int _RetakeApplicationID;
        private bool _IsRetake;
        private enMode _Mode;

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestAppointment _Appointment;

        public frmAddEditTestAppointment(
     int LocalDrivingLicenseApplicationID,
     int TestTypeID,
     bool IsRetake)
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

            _LocalDrivingLicenseApplicationID =
                LocalDrivingLicenseApplicationID;

            _TestTypeID = TestTypeID;

            _IsRetake = IsRetake;
            ctrRetakeTestInfo1.Enabled = _IsRetake;

            _RetakeApplicationID = -1;
        }
        public frmAddEditTestAppointment(
    int TestAppointmentID
     )
        {
            InitializeComponent();

            _Mode = enMode.Update;

            _TestAppointmentID = TestAppointmentID;
        }

        private void _LoadUpdateData()
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
            _TestTypeID = _Appointment.TestTypeID;
            //        MessageBox.Show(
            //"IsLocked = " + _Appointment.IsLocked.ToString());

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
                ctrRetakeTestInfo1.Enabled = false;
            }

            dtpAppointmentDate.Value =
                _Appointment.AppointmentDate;

            lblFees.Text =
                _Appointment.PaidFees.ToString("0.00");

            if (_Appointment.IsLocked)
            {
                dtpAppointmentDate.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                // Create Retake Application only when saving
                if (_IsRetake)
                {
                    _RetakeApplicationID =
                        clsApplication.CreateRetakeApplication(
                            _LocalDrivingLicenseApplicationID,
                            clsGlobal.CurrentUser.UserID);

                    if (_RetakeApplicationID == -1)
                    {
                        MessageBox.Show(
                            "Failed to create Retake Application.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }
                }

                decimal PaidFees =
                    Convert.ToDecimal(lblFees.Text);

                // Add Retake Application Fees
                if (_IsRetake)
                {
                    PaidFees += 5.00m;
                }

                int TestAppointmentID =
       clsTestAppointment.AddNewTestAppointment(
           _TestTypeID,
           _LocalDrivingLicenseApplicationID,
           dtpAppointmentDate.Value,
           PaidFees,
           clsGlobal.CurrentUser.UserID);
                if (TestAppointmentID != -1)
                {
                    MessageBox.Show(
                        "Appointment added successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Appointment was not added.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                _Appointment.AppointmentDate =
                    dtpAppointmentDate.Value;

                if (_Appointment.Update())
                {
                    MessageBox.Show(
                        "Appointment updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Appointment was not updated.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
       
        }
       
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void _LoadAddNewData()
        {
            int DLAID = -1;
            string ClassName = "";
            string Applicant = "";
            int Trial = 0;
            decimal TestFees = 0;

            if (clsTestAppointment.GetTestAppointmentInfo(
                    _LocalDrivingLicenseApplicationID,
                    _TestTypeID,
                    -1,
                    ref DLAID,
                    ref ClassName,
                    ref Applicant,
                    ref Trial,
                    ref TestFees))
            {
                lblDLAAppID.Text =
                    DLAID.ToString();

                lblDClass.Text =
                    ClassName;

                lblName.Text =
                    Applicant;

                lblTrial.Text =
                    Trial.ToString();

                lblFees.Text =
                    TestFees.ToString("0.00");

                ctrRetakeTestInfo1.LoadRetakeInfo(
                    TestFees,
                    Trial,
                    _RetakeApplicationID);

                ctrRetakeTestInfo1.Enabled =
                    _IsRetake;
            }
     
        }
        private void frmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _LoadAddNewData();
            }
            else
            {
                _LoadUpdateData();
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
            }
        }
}
