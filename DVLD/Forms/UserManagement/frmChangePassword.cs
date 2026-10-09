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
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;
        
        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
            _User = clsUser.Find(UserID);
            if (_User != null)
                ctrUserCard1.LoadUserInfo(_User);
        }
        private bool ValidateInput()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(
                    txtCurrentPassword,
                    "Current password is required.");

                IsValid = false;
            }
            else if (_User == null || txtCurrentPassword.Text != _User.Password)
            {
                errorProvider1.SetError(
                    txtCurrentPassword,
                    "Current password is incorrect.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(
                    txtNewPassword,
                    "New password is required.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(
                    txtConfirmPassword,
                    "Please confirm your new password.");

                IsValid = false;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(
                    txtConfirmPassword,
                    "Passwords do not match.");

                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

            return IsValid;
        }
        private void ctrUserCard1_Load(object sender, EventArgs e)
        {

        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show(
                    "Password changed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Failed to change password.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
