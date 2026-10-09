using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        public static int AddNewDriver(
            int PersonID,
            int CreatedByUserID)
        {
            return clsDriverData.AddNewDriver(
                PersonID,
                CreatedByUserID);
        }

        public static int GetDriverIDByPersonID(int PersonID)
        {
            return clsDriverData.GetDriverIDByPersonID(
                PersonID);
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return clsDriverData.GetPersonIDByDriverID(
                DriverID);
        }

    }
}
