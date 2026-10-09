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
using System.IO;

namespace DVLD
{
    public partial class ctrPersonAddEdit : UserControl
    {
        private clsPerson _Person;
        private DataTable _dtCountries;
        public event Action<object> OnClose;

       public event Action<object> OnSave;

         public ctrPersonAddEdit()
        {
            InitializeComponent();
            _Person = new clsPerson();
        }
     

        protected virtual void Close()
        {
            Action<object> Handler = OnClose;

            if (Handler != null)
            {
                Handler(this);
            }
        }



        private void _LoadPersonInfo()
        {
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountry.SelectedValue = _Person.NationalityCountryID;

            if (_Person.Gendor == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (!string.IsNullOrEmpty(_Person.ImagePath))
                pbPersonImage.ImageLocation = _Person.ImagePath;
        }
        protected virtual void Save()
        {
            if (!_ValidateNationalNo())
                return;
            if (!_ValidateAddress())
                return;

            if (!_ValidateEmail())
                return;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Address = txtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Gendor = rbMale.Checked ? (short)0 : (short)1;
            _Person.ImagePath = pbPersonImage.ImageLocation;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID =Convert.ToInt32(cbCountry.SelectedValue);
            try
            {
                clsPerson.enMode CurrentMode = _Person.Mode;

                if (_Person.Save())
                {
                    if (CurrentMode == clsPerson.enMode.AddNew)
                    {
                        MessageBox.Show("Person added successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Person updated successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    Action<object> Handler = OnSave;

                    if (Handler != null)
                    {
                        Handler(_Person.PersonID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void _LoadCountries()
        {
            _dtCountries = clsCountry.GetAllCountries();

            cbCountry.DataSource = _dtCountries;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedValue = 51;
        }
        private bool _ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "");
                return true;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                errorProvider1.SetError(txtEmail, "Invalid Email.");
                return false;
            }

            errorProvider1.SetError(txtEmail, "");
            return true;
        }
        private bool _ValidateNationalNo()
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "National No is required.");
                return false;
            }

            clsPerson Person = clsPerson.Find(txtNationalNo.Text);

            if (Person != null && Person.PersonID != _Person.PersonID)
            {
                errorProvider1.SetError(txtNationalNo, "National No already exists.");
                return false;
            }

            errorProvider1.SetError(txtNationalNo, "");
            return true;
        }
        private bool _ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Address is required.");
                return false;
            }

            errorProvider1.SetError(txtAddress, "");
            return true;
        }
        public void LoadPerson(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person != null)
            {
                _LoadPersonInfo();
            }
        }
        private void ctrPersonAddEdit_Load(object sender, EventArgs e)
        {
            rbMale.Checked = true;
            pbPersonImage.Image = Properties.Resources.man;
            _LoadCountries();
            if (_Person.Mode == clsPerson.enMode.Update)
            {
                _LoadPersonInfo();
            }
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagesFolder = Path.Combine(Application.StartupPath, "PeopleImages");
                Directory.CreateDirectory(ImagesFolder);
                string FileName = Guid.NewGuid().ToString() + Path.GetExtension(openFileDialog1.FileName);
                string DestinationPath = Path.Combine(ImagesFolder, FileName);
                File.Copy(openFileDialog1.FileName, DestinationPath);
                pbPersonImage.ImageLocation = DestinationPath;
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            string ImagePath = pbPersonImage.ImageLocation;

            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
            {
                File.Delete(ImagePath);
            }
            pbPersonImage.ImageLocation = null;
            pbPersonImage.Image = null;
        }

        private void btuClose_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Properties.Resources.man;
                pbPersonImage.ImageLocation = null;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Properties.Resources.girl;
                pbPersonImage.ImageLocation = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
