using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Game_Caro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Caro.BUS
{
    class AccountBUS
    {
        static IFirebaseConfig config = new FirebaseConfig { BasePath = "https://gamecaro-6dbb7-default-rtdb.asia-southeast1.firebasedatabase.app/" };

        static FirebaseClient client = new FirebaseClient(config);

        public bool AddNew(User newAccount)
        {
            try
            {
                client.Set("accountss/" + newAccount.Username, newAccount); // auto -generated key
                return true;
            }
            catch { return false; }
        }


        public bool CheckAccount(User account)
        {
            FirebaseResponse response = client.Get("accountss");
            Dictionary<String, User> dicAccounts = response.ResultAs<Dictionary<String, User>>();
            String key = dicAccounts.FirstOrDefault(x => x.Value.Mssv == account.Mssv && x.Value.Password == account.Password).Key;
            //(x => x.Value.userid == account.userid && x.Value.name == account.name && x.Value.gender == account.gender && x.Value.dob == account.dob && x.Value.address == account.address && x.Value.education == account.education && x.Value.username == account.username && x.Value.password == account.password).Key;
            if (String.IsNullOrEmpty(key)) return false;
            return true;
        }


        public bool CheckAccountAdmin(Account account)
        {
            FirebaseResponse response = client.Get("accountss");
            Dictionary<String, Account> dicAccounts = response.ResultAs<Dictionary<String, Account>>();
            String key = dicAccounts.FirstOrDefault(x => x.Value.username == account.username && x.Value.password == account.password).Key;
            //(x => x.Value.userid == account.userid && x.Value.name == account.name && x.Value.gender == account.gender && x.Value.dob == account.dob && x.Value.address == account.address && x.Value.education == account.education && x.Value.username == account.username && x.Value.password == account.password).Key;
            if (String.IsNullOrEmpty(key)) return false;
            return true;
        }
    }

}


