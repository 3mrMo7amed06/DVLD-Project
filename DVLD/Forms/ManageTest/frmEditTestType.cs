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
    public partial class frmEditTestType : Form
    {
        private int _TestTypeID;
        private clsTestType _TestType;
        public frmEditTestType(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show(
                    "Test Type was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            lblID.Text = _TestType.TestTypeID.ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDes.Text = _TestType.TestTypeDescription;

            txtFees.Text = _TestType.TestTypeFees.ToString();
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
            if (string.IsNullOrWhiteSpace(txtDes.Text))
            {
                errorProvider1.SetError(
                    txtTitle,
                    "Application Type Description is required.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtDes, "");
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

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            _TestType.TestTypeTitle =
                txtTitle.Text.Trim();
            _TestType.TestTypeDescription =
              txtDes.Text.Trim();

            _TestType.TestTypeFees =
                decimal.Parse(txtFees.Text);

            if (_TestType.Update())
            {
                MessageBox.Show(
                    "Test Type updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Failed to update Test Type.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
