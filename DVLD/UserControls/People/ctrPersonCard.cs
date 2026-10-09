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
    public partial class ctrPersonCard : UserControl
    {
        public ctrPersonCard()
        {
            InitializeComponent();
        }
        public void LoadPersonInfo(clsPerson Person)
        {
            lblPersonID.Text = Person.PersonID.ToString();
            lblNationalNo.Text = Person.NationalNo;
            lblName.Text = Person.FullName();
            lblPhone.Text = Person.Phone;
            lblEmail.Text = Person.Email;
            lblAddress.Text = Person.Address;
            lblDateOfBirth.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
            // lblCountry.Text = Person.CountryName;
            lblGender.Text = Person.Gendor == 0 ? "Male" : "Female";
            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                Image.ImageLocation = Person.ImagePath;
            }
            else
            {
                if (Person.Gendor == 0)
                    Image.Image = Properties.Resources.man;
                else
                    Image.Image = Properties.Resources.girl;
            }

            clsCountry Counrty = clsCountry.Find(Person.NationalityCountryID);
            if (Counrty != null)
            {
                lblCountry.Text = Counrty.CountryName; 

            }

        }

        public void ClearPersonInfo()
        {
            lblPersonID.Text = "";
            lblNationalNo.Text = "";
            lblName.Text = "";
            lblPhone.Text = "";
            lblEmail.Text = "";
            lblAddress.Text = "";
            lblDateOfBirth.Text = "";
            lblGender.Text = "";
            lblCountry.Text = "";

            Image.Image = null;
        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ctrPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
