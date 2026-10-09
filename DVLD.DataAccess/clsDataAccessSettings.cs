using System;
using System.Configuration;
namespace DVLD.DataAccess
{
    static class clsDataAccessSettings
    {
        public static string ConnectionString =
              ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString;

    }
}
