using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace follow.Infrastructure
{
  public class Coneccion6
    {


        public static SqlConnection CNDB()
        {
            SqlConnection con = new SqlConnection();
            
                con.ConnectionString =
                    "Data Source=followserver.database.windows.net;" +
                    "Initial Catalog=FollowDB;" +
                    "User id=FollowSa;" +
                    "Password=Follow.2018;";

            return con;
        }

        public int Insert(string InsStr, string Table)
        {
            try
            {
                string QryTable = "insert into " + Table +
                    " Values (" + InsStr + ")";

                SqlConnection con = CNDB();
                con.Open();
                SqlCommand comando = new SqlCommand(QryTable, con);
                SqlDataReader reader = comando.ExecuteReader();
                return 0;
            }
            catch (Exception e)
            {
                return 1;
            }
        }

        public static SqlDataReader Select(string Fields, string Table, string ExtraCode)
        {

                string QryTable = "SELECT "+ Fields +" FROM "+ Table +" " + ExtraCode;
                SqlConnection con = CNDB();
                con.Open();
                SqlCommand comando = new SqlCommand(QryTable, con);
                SqlDataReader reader = comando.ExecuteReader();
                return reader;
        }
 
    }
}
