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

namespace DVLD.Forms.PeopleManagement
{
    public partial class frmManageDriver : Form
    {
        private DataTable _dtDrivers;
        public frmManageDriver()
        {
            InitializeComponent();
            dgvDrivers.AutoGenerateColumns = false;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _UpdateRecordsCount()
        {
                  lblRecords.Text = _dtDrivers.DefaultView.Count.ToString();
        }
        private void _RefreshDriversList()
        {
            _dtDrivers = clsDriver.GetAllDrivers();

            dgvDrivers.DataSource = _dtDrivers;
            _UpdateRecordsCount(); 
        }
        private void frmManageDriver_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshDriversList();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            txtFilterValue.Visible = false;
            if (cbFilterBy.SelectedIndex != 0)
            {
                txtFilterValue.Visible = true;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string value = txtFilterValue.Text.Trim();

            if (cbFilterBy.SelectedIndex == 0 || value == "")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                _UpdateRecordsCount();
                return;
            }

            switch (cbFilterBy.Text)
            {
                case "Driver ID":

                    if (int.TryParse(value, out int DriverID))
                        _dtDrivers.DefaultView.RowFilter =
                            $"DriverID = {DriverID}";
                    else
                        _dtDrivers.DefaultView.RowFilter = "";

                    break;


                case "Person ID":

                    if (int.TryParse(value, out int PersonID))
                        _dtDrivers.DefaultView.RowFilter =
                            $"PersonID = {PersonID}";
                    else
                        _dtDrivers.DefaultView.RowFilter = "";

                    break;


                case "National No.":

                    _dtDrivers.DefaultView.RowFilter =
                        $"NationalNo LIKE '%{value.Replace("'", "''")}%'";

                    break;


                case "FullName":
                    _dtDrivers.DefaultView.RowFilter =
                        $"FullName LIKE '%{value}%'";
                    break;

            }

            _UpdateRecordsCount();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" ||
     cbFilterBy.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) &&
                    !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
