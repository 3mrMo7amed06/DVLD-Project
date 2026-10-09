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
    public partial class frmShowUserDetail : Form
    {
        public event Action<object> OnSave;
        private int _UserID;
        private clsUser _User;
        public frmShowUserDetail()
        {
            InitializeComponent();

        }
        public frmShowUserDetail(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show(
                    "User was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            clsPerson Person = clsPerson.Find(_User.PersonID);

            if (Person != null)
                ctrPersonCard1.LoadPersonInfo(Person);

            ctrUserCard1.LoadUserInfo(_User);
        }
        private void ctrUserCard1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmShowUserDetail_Load(object sender, EventArgs e)
        {
_LoadUserInfo();
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
             
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_User.PersonID);

            frm.ShowDialog();

            _LoadUserInfo();
            OnSave?.Invoke(_User.PersonID);
        }
    }
}
