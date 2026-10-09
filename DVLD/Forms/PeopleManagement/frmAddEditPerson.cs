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
    public partial class frmAddEditPerson : Form
    {
        public event Action<object> OnSave;
        private int _PersonID;
        public frmAddEditPerson()
        {
            InitializeComponent();
            ctrPersonAddEdit1.OnClose += ctrPersonAddEdit1_OnClose;
         ctrPersonAddEdit1.OnSave += ctrPersonAddEdit1_OnSave;
            label1.Text = "Add New Person";
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            ctrPersonAddEdit1.OnClose += ctrPersonAddEdit1_OnClose;
            ctrPersonAddEdit1.OnSave += ctrPersonAddEdit1_OnSave;
            ctrPersonAddEdit1.LoadPerson(PersonID);
            lblPersonID.Text = PersonID.ToString();
            label1.Text = "Update Person";
        }

        private void ctrPersonAddEdit1_OnSave(object obj)
        {
            lblPersonID.Text = obj.ToString();
            label1.Text = "Update Person";
            OnSave?.Invoke(obj);
        }

        private void ctrPersonAddEdit1_OnClose(object obj)
        {
            this.Close(); 
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            
        }

        private void ctrPersonAddEdit1_Load(object sender, EventArgs e)
        {

        }

        private void ctrPersonAddEdit1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
