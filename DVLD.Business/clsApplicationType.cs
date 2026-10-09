using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsApplicationType
    {
        
            public int ApplicationTypeID { get; set; }
            public string ApplicationTypeTitle { get; set; }
            public decimal ApplicationFees { get; set; }

           

            public clsApplicationType(
                int ApplicationTypeID,
                string ApplicationTypeTitle,
                decimal ApplicationFees)
            {
                this.ApplicationTypeID = ApplicationTypeID;
                this.ApplicationTypeTitle = ApplicationTypeTitle;
                this.ApplicationFees = ApplicationFees;
            }
        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationFees = 0;

            if (clsApplicationTypeData.GetApplicationTypeInfoByID(
                ApplicationTypeID,
                ref ApplicationTypeTitle,
                ref ApplicationFees))
            {
                return new clsApplicationType(
                    ApplicationTypeID,
                    ApplicationTypeTitle,
                    ApplicationFees);
            }

            return null;
        }
        public bool Update()
        {
            return clsApplicationTypeData.UpdateApplicationType(
                this.ApplicationTypeID,
                this.ApplicationTypeTitle,
                this.ApplicationFees);
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }
    }
}
