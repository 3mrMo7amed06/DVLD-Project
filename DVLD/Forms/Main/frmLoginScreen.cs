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
using System.IO;
namespace DVLD
{
    public partial class frmLoginScreen : Form
    {
        private string _LoginInfoFile = "LoginInfo.txt";

        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void _SaveLoginInfo()
        {
            string UserName = txtUsername.Text.Trim();
            string Password = txtPassword.Text;

            File.WriteAllText(_LoginInfoFile, UserName + "#//#" + Password);
        }
        private bool _Login()
        {
            string UserName = txtUsername.Text.Trim();
            string Password = txtPassword.Text;

            clsUser User = clsUser.Find(UserName, Password);

            if (User == null)
            {
                return false;
            }
            clsGlobal.CurrentUser = User;
            if (chkRememberMe.Checked)
            {
                _SaveLoginInfo();
            }
            else
            {
                if (File.Exists(_LoginInfoFile))
                    File.Delete(_LoginInfoFile);
            }
            return true;
        }
        private void _LoadLoginInfo()
        {
            if (!File.Exists(_LoginInfoFile))
                return;

            string LoginInfo = File.ReadAllText(_LoginInfoFile);

            string[] Info = LoginInfo.Split(new string[] { "#//#" },
                StringSplitOptions.None);

            if (Info.Length == 2)
            {
                txtUsername.Text = Info[0];
                txtPassword.Text = Info[1];
                chkRememberMe.Checked = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (!_Login())
            {
                MessageBox.Show("Invalid Username or Password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            this.Hide();

            using (frmMain frm = new frmMain())
            {
                frm.ShowDialog();
            }

            this.Show();
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            _LoadLoginInfo(); 
        }
    }
    }

