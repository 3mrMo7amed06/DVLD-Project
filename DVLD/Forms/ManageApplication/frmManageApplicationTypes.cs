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
    public partial class frmManageApplicationTypes : Form
    {   private DataTable _dtApplicationTypes;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
      

        private void _RefreshApplicationTypesList()
        {
            _dtApplicationTypes =
                clsApplicationType.GetAllApplicationTypes();

            dataGridView1.DataSource = _dtApplicationTypes;
        }
        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dtApplicationTypes.DefaultView.Count.ToString();
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
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
            int ApplicationTypeID = Convert.ToInt32(
        dataGridView1.SelectedRows[0]
        .Cells["ID"].Value);

            frmEditApplicationType frm =
                new frmEditApplicationType(ApplicationTypeID);

            frm.ShowDialog();

            _RefreshApplicationTypesList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
