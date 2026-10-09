using DVLD.DataAccess; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD.Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gendor { set; get; }

        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string ImagePath { set; get; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalNo = "";
            this.DateOfBirth = DateTime.Now;
            this.Gendor = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = ""; 
            Mode = enMode.AddNew;
        }


        public clsPerson     (
    int PersonID, string NationalNo,
    string FirstName,string SecondName,
    string ThirdName,  string LastName,
    DateTime DateOfBirth, short Gendor,
    string Address,string Phone,string Email,
    int NationalityCountryID,string ImagePath    )
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName,this.NationalNo ,
                this.DateOfBirth ,this.Gendor ,this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath );

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

        }

        public static clsPerson Find(int PersonID)
        {


            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string NationalNo = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = -1; 
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1; 
            string ImagePath = "";

             

            if (clsPersonData.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName, ref NationalNo
            , ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email
            , ref NationalityCountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email,
 NationalityCountryID, ImagePath);
            else
                return null;
        }


        public static clsPerson Find(string NationalNo)
        {

            int PersonID = -1; 
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            
            DateTime DateOfBirth = DateTime.Now;
            short Gendor = -1;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

           

            if (clsPersonData.GetPersonInfoByNationalNo( NationalNo, ref PersonID, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName
            , ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email
            , ref NationalityCountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email,
 NationalityCountryID, ImagePath);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                   return _UpdatePerson();
                default:
                    return false;
            }
        }


        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();

        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }












    }


}
