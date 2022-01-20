using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class SplashScreen : Form
    {
       

        public string Username = "";
        public string Rule = "";
        IFirebaseClient client;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width >= 700)
            {
               // ShowInfo();
                timer1.Stop();
               home1 mc = new home1(Username, Rule);
                mc.Show();
                this.Hide();
            }
        }
        //private async void ShowInfo()
        //{
        //    FirebaseResponse response = await client.GetAsync("accountss/" + Username);
        //    User user = response.ResultAs<User>();
        //    if (user != null)
        //    {

        //        if (user.Image != null && user.Image != "")
        //        {
        //          //  profileimage.Image = Base64StringToImage(user.Image);
        //        }
        //        else
        //        {
        //            //profileimage.Image = null;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public bool ConnectFireBase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                // Project settings -> Database secrets
                AuthSecret = "jIPp6lNlABYsEFPJt818TPvtQYALC53Z8I7gVmOK",
                // Realtime Database
                BasePath = "https://gamecaro-6dbb7-default-rtdb.asia-southeast1.firebasedatabase.app/",
            };
            client = new FireSharp.FirebaseClient(config);
            try
            {
                if (client != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
