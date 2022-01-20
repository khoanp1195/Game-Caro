using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ThreeTierStructure
{
    class Operation
    {
        public Connection db = new Connection();
        public Information info = new Information();
        // here we declare the queries and db operations needed for the application


        public int insertEmp(Information info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO userRegister VALUES ('" + info.name + "','" + info.gender + "','" + info.dob + "','" + info.address + "','" + info.education + "','" + info.username + "','" + info.password + "','U')";
            return db.ExeNonQuery(cmd);
        }

        public DataTable login(Information info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from userRegister where Username='" + info.username + "' and Password='" + info.password + "'";
            return db.ExeReader(cmd);
        }
    }
}
