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
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(clsUser User)
        {
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.UserName;
            lblIsActive.Text = User.IsActive ? "Yes" : "No";
        }
        private void ctrUserCard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblNationalNo_Click(object sender, EventArgs e)
        {

        }
    }
}
