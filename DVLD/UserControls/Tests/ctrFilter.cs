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
    public partial class ctrFilter : UserControl
    {
        public delegate void PersonFoundEvent(object sender, clsPerson Person);
        public event PersonFoundEvent PersonFound;
        public ctrFilter()
        {
            InitializeComponent();
        }

        private void ctrFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsPerson Person = null;
            if (cbFilterBy.Text == "Person ID")
            {
                if (!int.TryParse(txtFilterValue.Text, out int PersonID))
                    return;

                Person = clsPerson.Find(PersonID);
            }
            else if (cbFilterBy.Text == "National No.")
            {
                Person = clsPerson.Find(txtFilterValue.Text.Trim());
            }

            if (Person == null)
            {
                PersonFound?.Invoke(this, null);

                MessageBox.Show("Person not found.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            PersonFound?.Invoke(this, Person);
        }
    }
}
