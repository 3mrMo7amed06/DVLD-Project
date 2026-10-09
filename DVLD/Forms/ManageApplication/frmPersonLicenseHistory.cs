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

namespace DVLD.Forms.ManageApplication
{
    public partial class frmPersonLicenseHistory : Form
    {
        private int _PersonID;

        public frmPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }
        private void ctrPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find(_PersonID);

            if (Person == null)
            {
                MessageBox.Show(
                    "Person was not found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            ctrPersonCard1.LoadPersonInfo(Person);
            ctrDriverLicenseHistory1.LoadLicenseHistory(_PersonID);


        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
