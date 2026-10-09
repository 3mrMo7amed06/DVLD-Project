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
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show(
                    "Application Type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtFees.Text = _ApplicationType.ApplicationFees.ToString();
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
         !char.IsDigit(e.KeyChar) &&
         e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtFees.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
        private bool ValidateInput()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider1.SetError(
                    txtTitle,
                    "Application Type Title is required.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
            }

            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                errorProvider1.SetError(
                    txtFees,
                    "Application Fees is required.");

                IsValid = false;
            }
            else if (!decimal.TryParse(
                txtFees.Text,
                out decimal Fees))
            {
                errorProvider1.SetError(
                    txtFees,
                    "Please enter a valid amount.");

                IsValid = false;
            }
            else if (Fees < 0)
            {
                errorProvider1.SetError(
                    txtFees,
                    "Fees cannot be negative.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtFees, "");
            }

            return IsValid;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            _ApplicationType.ApplicationTypeTitle =
                txtTitle.Text.Trim();

            _ApplicationType.ApplicationFees =
                decimal.Parse(txtFees.Text);

            if (_ApplicationType.Update())
            {
                MessageBox.Show(
                    "Application Type updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Failed to update Application Type.",
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
