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
    public partial class ctrUserAddEdit : UserControl
    {
        public ctrUserAddEdit()
        {
            InitializeComponent();
        }
        public string UserName
        {
            get { return txtUserName.Text.Trim(); }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
        }
        public bool ValidateInput()
        {
            bool IsValid = true;

       
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Username is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }

          
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

      
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(
                    txtConfirmPassword,
                    "Please confirm your password.");

                IsValid = false;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
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
        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void ctrUserAddEdit_Load(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        public void SetUserID(int UserID)
        {
            lblUserID.Text = UserID.ToString();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(
                    txtConfirmPassword,
                    "Please confirm your password.");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(
                    txtConfirmPassword,
                    "Passwords do not match.");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Username is required.");
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(
                    txtPassword,
                    "Password is required.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }

            if (!string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    errorProvider1.SetError(
                        txtConfirmPassword,
                        "Passwords do not match.");
                }
                else
                {
                    errorProvider1.SetError(txtConfirmPassword, "");
                }
            }
        }
        public void LoadUser(int UserID)
        {
            clsUser User = clsUser.Find(UserID);

            if (User == null)
                return;

            lblUserID.Text = User.UserID.ToString();
            txtUserName.Text = User.UserName;
            txtPassword.Text = User.Password;
            txtConfirmPassword.Text = User.Password;
            chkIsActive.Checked = User.IsActive;
        }
    }
}
