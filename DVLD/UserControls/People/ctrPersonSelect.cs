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
    public partial class ctrPersonSelect : UserControl
    {

        private clsPerson _Person;
        public ctrPersonSelect()
        {
            InitializeComponent();
            ctrFilter1.PersonFound += ctrFilter1_PersonFound;
        }
        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }
        private void ctrFilter1_PersonFound(object sender, clsPerson Person)
        {
            _Person = Person;
            if (_Person == null)
            {
               
                ClearPersonInfo();
                return;
            }
          
            LoadPersonInfo(_Person);
        }
        public void LoadPersonInfo(clsPerson Person)
        {
            _Person = Person;
            ctrPersonCard1.LoadPersonInfo(Person);
        }
        public void ClearPersonInfo()
        {
            ctrPersonCard1.ClearPersonInfo();
        }
        private void ctrPersonSelect_Load(object sender, EventArgs e)
        {
           
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person == null)
                return;

            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);

            frm.ShowDialog();

            _Person = clsPerson.Find(_Person.PersonID);

            if (_Person != null)
                LoadPersonInfo(_Person);
        }
        public void DisablePersonSelection()
        {
            ctrFilter1.Enabled = false;
            btnAdd.Enabled = false; 


        }
        private void ctrPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void ctrFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();

            frm.OnSave += frm_OnSave;

            frm.ShowDialog();
        }

        private void frm_OnSave(object obj)
        {
            int PersonID = Convert.ToInt32(obj);

            _Person = clsPerson.Find(PersonID);

            if (_Person != null)
            {
                LoadPersonInfo(_Person);
            }
        }
    }
}
