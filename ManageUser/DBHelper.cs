using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ManageUser
{
    public class DBHelper
    {
        //properties

        public string ConnectionString { get; set; }
        private SqlConnection con = null;
        public SqlConnection GetConnection()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            return con;
        }

        // insert / update / delete CRUD
        public int executeInsertUpdateDelete(string sql)
        {
            int result = 0;
            try
            {
                //1. 
                con = GetConnection();

                //2. open
                con.Open();
                //3. Command
                SqlCommand cmd = new SqlCommand(sql, con);

                //4. execute command
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //select
        public SqlDataReader executeSELECT(string selectSQL)
        {
            SqlDataReader dr = null;
            try
            {
                //1. 
                con = GetConnection();

                //2. open
                con.Open();
                //3. Command
                SqlCommand cmd = new SqlCommand(selectSQL, con);

                //4. execute command
                dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                dr = null;
            }
            return dr;
        }

        public DataSet executeSELECTDS(string selectSQL, string tableName)
        {
            //1. Create Connection
            con = GetConnection();
            // 2. open connection
            con.Open();
            //3. DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(selectSQL, con);
            //4. fill Dataset
            DataSet ds = new DataSet();
            da.Fill(ds, tableName);
            return ds;
        }

        public void CloseConnection() {

            if (con != null) {
                if (con.State == ConnectionState.Open)
                {
                    try {
                        con.Close();
                    }
                    catch (Exception ex) { 
                    
                    }
                }
            }
        }

    }
}
