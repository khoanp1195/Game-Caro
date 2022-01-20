//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using Game_Caro.Model;
//using System.Data.SqlClient;
//using System.Data;

//namespace Game_Caro.DAO
//{
//    class AccountDAO
//    {

//        MyDBDataContext db = new MyDBDataContext(ConfigurationManager.ConnectionStrings["strCon"].ConnectionString);

//        public List<Account> SelectAll()
//        {

//            List<Account> accounts = db.userRegisters.ToList();
//            return accounts;
//        }















//            //String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
//            //public Account info = new Account();
//            //public List<Account> SelectAll()
//            //{
//            //    List<Account> accounts = new List<Account>();
//            //    SqlConnection con = new SqlConnection(strCon);
//            //    con.Open();
//            //    String strCom = "SELECT * FROM userRegister";
//            //    SqlCommand com = new SqlCommand(strCom, con);
//            //    SqlDataReader dr = com.ExecuteReader();
//            //    while (dr.Read())
//            //    {
//            //        Account account = new Account()
//            //        {
//            //            Id = (int)dr["Id"],
//            //            username = (String)dr["Name"],
//            //            password = (String)dr["Password"],
//            //            name = (String)dr["Name"],
//            //            gender = (String)dr["Gender"], 
//            //         //   dob = (String)dr["DOB"],
//            //            address = (String)dr["Address"],  
//            //            education = (String)dr["Education"],
//            //            usertype = (String)dr["Usertype"]

//            //        };
//            //        accounts.Add(account);
//            //    }
//            //    con.Close();
//            //    return accounts;
//            //}


//        }
//}
