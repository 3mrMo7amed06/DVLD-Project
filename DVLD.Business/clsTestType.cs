using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsTestType
    {

        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public clsTestType(
                int TestTypeID, string TestTypeTitle,
                string TestTypeDescription,
                decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;


        }
        public static clsTestType Find(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            if (clsTestTypeData.GetTestTypeInfoByID(
                TestTypeID,ref TestTypeTitle,
                ref TestTypeDescription,
                ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
                  
            }

            return null;
        }
        public bool Update()
        {
            return clsTestTypeData.UpdateTestType(this.TestTypeID,
                this.TestTypeTitle,
                this.TestTypeDescription,
                this.TestTypeFees);
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
    }
}
