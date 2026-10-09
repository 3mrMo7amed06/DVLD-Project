using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Business;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        private DataTable _dtPeople;
       

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshPeopleList(); 
        }
        private void _RefreshPeopleList()
        {
            _dtPeople = clsPerson.GetAllPeople();
            dataGridView1.DataSource = _dtPeople;
            _UpdateRecordsCount();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();

            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);
            

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string value = txtFilterValue.Text.Trim();
            if (cbFilterBy.SelectedIndex == 0 || value == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    if (int.TryParse(value, out int personID))
                        _dtPeople.DefaultView.RowFilter = $"PersonID = {personID}";
                    else
                        _dtPeople.DefaultView.RowFilter = "";
                    break;

                case "National No.":
                    _dtPeople.DefaultView.RowFilter =
                        $"NationalNo LIKE '%{value}%'";
                    break;

                case "First Name":
                    _dtPeople.DefaultView.RowFilter =
                        $"FirstName LIKE '%{value}%'";
                    break;
                case "Second Name":
                    _dtPeople.DefaultView.RowFilter =
                        $"SecondName LIKE '%{value}%'";
                    break;
                case "Third Name":
                    _dtPeople.DefaultView.RowFilter =
                        $"ThirdName LIKE '%{value}%'";
                    break;
                case "Last Name":
                    _dtPeople.DefaultView.RowFilter =
                        $"LastName LIKE '%{value}%'";
                    break;

                case "Gender":
                    _dtPeople.DefaultView.RowFilter =
                        $"Gendor LIKE '%{value}%'";
                    break;
                case "Date Of Birth":
                    _dtPeople.DefaultView.RowFilter =
                     $"CONVERT(DateOfBirth, 'System.String') LIKE '%{value}%'";
                    break;

                case "Nationality":
                    _dtPeople.DefaultView.RowFilter =
                        $"CountryName LIKE '%{value}%'";
                    break;
                case "Phone":
                    _dtPeople.DefaultView.RowFilter =
                        $"Phone LIKE '%{value}%'";
                    break;
                case "Email":
                    _dtPeople.DefaultView.RowFilter =
                        $"Email LIKE '%{value}%'";
                    break;
            }
            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" ||
        cbFilterBy.Text == "Phone")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            

        }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
            frmShowPersonDetails frm = new frmShowPersonDetails(PersonID);
            frm.OnSave += frm_OnSave; 
            frm.ShowDialog();

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

        private void _AddNewPerson()
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.OnSave += frm_OnSave;
            frm.ShowDialog();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewPerson(); 
        }

        private void frm_OnSave(object obj)
        {
            _RefreshPeopleList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewPerson(); 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(
        dataGridView1.SelectedRows[0].Cells["PersonID"].Value);

            frmAddEditPerson frm = new frmAddEditPerson(PersonID);

            frm.OnSave += frm_OnSave;

            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["PersonID"].Value);
            try
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    _RefreshPeopleList();
                }
            }
            catch
            {
                MessageBox.Show(
                    "This person cannot be deleted because they are linked to other data.",
                    "Delete Person",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtPeople.DefaultView.Count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
