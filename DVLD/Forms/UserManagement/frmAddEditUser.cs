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
    public partial class frmAddEditUser : Form
    {
       
        private clsPerson _Person;
        private int _UserID;

        public frmAddEditUser()
        {
            InitializeComponent();
            _UserID = -1;
            label1.Text = "Add New User";
        }
        public frmAddEditUser(int UserID)
        {
         
            InitializeComponent();
            _UserID = UserID;
            label1.Text = "Update User";
            ctrUserAddEdit1.LoadUser(UserID);
            clsUser User = clsUser.Find(UserID);

            if (User != null)
            {
                clsPerson Person = clsPerson.Find(User.PersonID);

                if (Person != null)
                    _Person = Person;
                ctrPersonSelect1.LoadPersonInfo(Person);
                ctrPersonSelect1.DisablePersonSelection();
            }

        }

        private void ctrUserAddEdit1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl1.TabPages[e.Index];

            using (Brush brush = new SolidBrush(Color.FromArgb(80, 160, 240)))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(
                    tabPage.Text,
                    e.Font,
                    brush,
                    e.Bounds,
                    sf);
            }
        }

        private void ctrPersonSelect1_Load(object sender, EventArgs e)
        {

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            clsPerson Person = ctrPersonSelect1.SelectedPerson;

            if (Person == null)
            {
                MessageBox.Show(
                    "Please select a person first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (_UserID == -1)
            {
                if (clsUser.IsPersonLinkedToUser(Person.PersonID))
                {
                    MessageBox.Show(
                        "This person is already linked to a user.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            _Person = Person;

            tabControl1.SelectedIndex = 1;
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ctrUserAddEdit1.ValidateInput())
                return;

            if (_Person == null)
            {
                MessageBox.Show(
                    "Please select a person first.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                tabControl1.SelectedIndex = 0;
                return;
            }
            if (clsUser.IsUserNameExist(
    ctrUserAddEdit1.UserName,
    _UserID))
            {
                MessageBox.Show(
                    "This username is already in use.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            clsUser User;

            if (_UserID == -1)
                User = new clsUser();
            else
                User = clsUser.Find(_UserID);

            if (User == null)
            {
                MessageBox.Show(
                    "User was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            User.PersonID = _Person.PersonID;
            User.UserName = ctrUserAddEdit1.UserName;
            User.Password = ctrUserAddEdit1.Password;
            User.IsActive = ctrUserAddEdit1.IsActive;

            if (User.Save())
            {
                ctrUserAddEdit1.SetUserID(User.UserID);

                MessageBox.Show(
                    _UserID == -1
                        ? "User added successfully."
                        : "User updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    _UserID == -1
                        ? "Failed to add user."
                        : "Failed to update user.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void tpPersonInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
