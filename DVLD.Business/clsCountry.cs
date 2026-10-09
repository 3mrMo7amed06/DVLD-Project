using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class clsCountry
    {

        public int CountryID { set; get; }
        public string CountryName { set; get; }

        public clsCountry(int CountryID, string CountryName)
        {

            this.CountryID = CountryID;
            this.CountryName = CountryName;


        }
        public static clsCountry Find(int CountryID)
        {
          
            string CountryName = "";

            if (clsCountryData.GetCountryNameByID(CountryID, ref CountryName))

                return new clsCountry(CountryID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();

        }
    }
}
