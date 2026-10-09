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
    public partial class frmShowPersonDetails : Form
    {
        public event Action<object> OnSave;
        private int _PersonID;
        private clsPerson _Person;
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID; 
        }
        private void _LoadPersonInfo()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null) {
                MessageBox.Show("Person was not found.",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

                this.Close();
                return;
            }
            ctrPersonCard1.LoadPersonInfo(_Person);



        }
        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
           
            _LoadPersonInfo();
        }

        private void ctrPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.OnSave += frm_OnSave;
            frm.ShowDialog();
            _LoadPersonInfo();
        }

        private void frm_OnSave(object obj)
        {
            OnSave?.Invoke(obj);
        }
    }
}
