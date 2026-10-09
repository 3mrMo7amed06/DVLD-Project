using DVLD.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _RefreshTestTypesList()
        {
            _dtTestTypes =
                clsTestType.GetAllTestTypes();

            dataGridView1.DataSource = _dtTestTypes;
        }
        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtTestTypes.DefaultView.Count.ToString();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
            _UpdateRecordsCount();
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

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID = Convert.ToInt32(
       dataGridView1.SelectedRows[0]
       .Cells["ID"].Value);

            frmEditTestType frm =
                new frmEditTestType(TestTypeID);

            frm.ShowDialog();

            _RefreshTestTypesList();
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
