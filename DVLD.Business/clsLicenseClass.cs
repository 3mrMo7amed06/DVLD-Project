using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsLicenseClass
    {

        public static bool GetLicenseClassInfo(
           int LicenseClassID,
           ref int DefaultValidityLength,
           ref decimal ClassFees)
        {
            return clsLicenseClassData.GetLicenseClassInfo(
                LicenseClassID,
                ref DefaultValidityLength,
                ref ClassFees);
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

    }
}
