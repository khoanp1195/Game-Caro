using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace ManageUser
{
    class PlayerDao
    {
        private DBHelper helper = new DBHelper();
        public PlayerDao()
        {
            helper.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        }
        public List<Informations> getAllPlayers()
        {
            List<Informations> informations = new List<Informations>();
            DataSet ds = helper.executeSELECTDS("select * from userRegister", "userRegister");
            DataTable dt = ds.Tables["userRegister"];
            foreach (DataRow dr in dt.Rows)
            {

                Informations dept = new Informations()
                {
                   name = dr.ItemArray[0].ToString(),
                   gender = dr.ItemArray[1].ToString(),
                    dob = dr.ItemArray[2].ToString(),
                    address = dr.ItemArray[3].ToString(),
                    education = dr.ItemArray[4].ToString(),
                    username = dr.ItemArray[5].ToString(),
                    password = dr.ItemArray[6].ToString(),


                };
                informations.Add(dept);

            }
            return informations;
        }



    }
}
