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
    public partial class frmManageUsers : Form
    {
        private DataTable _dtUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtUsers.DefaultView.Count.ToString();
        }

        private void _RefreshUsersList()
        {
            _dtUsers = clsUser.GetAllUsers();
            dataGridView1.DataSource = _dtUsers;
            _UpdateRecordsCount();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshUsersList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
              cbIsActive.SelectedIndex = 0;


            txtFilterValue.Visible = false;
            cbIsActive.Visible = false;

            if (cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Visible = true;
            }
            else if (cbFilterBy.SelectedIndex != 0)
            {
                txtFilterValue.Visible = true;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string value = txtFilterValue.Text.Trim();
            if (cbFilterBy.SelectedIndex == 0 || value == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    if (int.TryParse(value, out int UserID))
                        _dtUsers.DefaultView.RowFilter = $"UserID = {UserID}";
                    else
                        _dtUsers.DefaultView.RowFilter = "";
                    break;

                case "Person ID":
                    if (int.TryParse(value, out int PersonID))
                        _dtUsers.DefaultView.RowFilter = $"PersonID = {PersonID}";
                    else
                        _dtUsers.DefaultView.RowFilter = "";
                    break;

                case "UserName":
                    _dtUsers.DefaultView.RowFilter =
                        $"UserName LIKE '%{value}%'";
                    break;

                case "FullName":
                    _dtUsers.DefaultView.RowFilter =
                        $"FullName LIKE '%{value}%'";
                    break;
                


            }
            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" ||
     cbFilterBy.Text == "User ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }


            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtUsers == null)
                return;

            if (cbFilterBy.Text != "Is Active")
                return;
            switch (cbIsActive.SelectedIndex)
            {
                case 0: // All
                    _dtUsers.DefaultView.RowFilter = "";
                    break;

                case 1: // Yes
                    _dtUsers.DefaultView.RowFilter = "IsActive = True";
                    break;

                case 2: // No
                    _dtUsers.DefaultView.RowFilter = "IsActive = False";
                    break;
            }

            _UpdateRecordsCount();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewUser(); 
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(
       dataGridView1.SelectedRows[0].Cells["UserID"].Value);

            frmShowUserDetail frm = new frmShowUserDetail(UserID);
            frm.OnSave += frm_OnSave;
            frm.ShowDialog();
        }

        private void frm_OnSave(object obj)
        {
            _RefreshUsersList();
        }

        private void _AddNewUser()
        {
            frmAddEditUser frm = new frmAddEditUser();

            frm.ShowDialog();

            _RefreshUsersList();
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewUser(); 

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[e.RowIndex].Selected = true;

                contextMenuStrip1.Show(
                    dataGridView1,
                    dataGridView1.PointToClient(Cursor.Position));
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(
    dataGridView1.SelectedRows[0].Cells["UserID"].Value);
            frmAddEditUser frm = new frmAddEditUser(UserID);

            frm.ShowDialog();

            _RefreshUsersList();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserID"].Value);
            try
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefreshUsersList();
                }
            }
            catch
            {
                MessageBox.Show(
                    "This User cannot be deleted because they are linked to other data.",
                    "Delete Person",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(
       dataGridView1.SelectedRows[0].Cells["UserID"].Value);
            frmChangePassword frm = new frmChangePassword(UserID);

            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon"); 
        }

        private void lblRecords_Click(object sender, EventArgs e)
        {

        }
    }
    }

