using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneOtomasyonuBerke
{
    public static class SqlCon
    {
        readonly static string connectionString = ("DATA SOURCE = localhost; INITIAL CATALOG = KütüphaneOtomasyonuDB; INTEGRATED SECURITY = TRUE");
    
        public static SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }      
    }
}
