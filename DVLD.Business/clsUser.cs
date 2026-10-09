using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            Mode = enMode.AddNew;
        }


        public clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
          
            Mode = enMode.Update;
        }


        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUserData.UpdateUser( this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();
                default:
                    return false;
            }
        }
        public static clsUser Find(string UserName, string Password)
        {


            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false; 

           
            if (clsUserData.GetUserInfoByUserNameAndPassword(UserName, Password, ref UserID , ref PersonID ,ref IsActive))

                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (clsUserData.GetUserInfoByUserID(
                UserID,
                ref PersonID,
                ref UserName,
                ref Password,
                ref IsActive))
            {
                return new clsUser(
                    UserID,
                    PersonID,
                    UserName,
                    Password,
                    IsActive);
            }
            else
            {
                return null;
            }
        }
        public static bool IsPersonLinkedToUser(int PersonID)
        {
            return clsUserData.IsPersonLinkedToUser(PersonID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();

        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserNameExist(string UserName, int UserID)
        {
            return clsUserData.IsUserNameExist(UserName, UserID);
        }
    }
}
