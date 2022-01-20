using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Game_Caro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class home1 : Form
    {
       // private  currentBtn;
        private Form currentChildForm;
        public string Username = "";
        public string Rule = "";
        Library library = new Library();
        IFirebaseClient client;

        public home1()
        {
            Sound1();
            InitializeComponent();
           



        }
        public home1(string username, string rule)
        {
            Sound1();
            InitializeComponent();
            ConnectFireBase();
            this.Username = username;
            this.Rule = rule;
   

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Reset()
        {
          //  DisableButton();
        //    leftBorderBtn.Visible = false;
        ///    iconCurrentChild.IconChar = IconChar.Home;
         //   iconCurrentChild.IconColor = Color.White;
            //lbl_title.Text = "Home";
            currentChildForm.Close();
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

        public static string ImageToBase64String(PictureBox ptb)
        {
            MemoryStream m = new MemoryStream();
            ptb.Image.Save(m, ptb.Image.RawFormat);
            return Convert.ToBase64String(m.ToArray());
        }

        public static Image Base64StringToImage(string str64)
        {
            byte[] img = Convert.FromBase64String(str64);
            MemoryStream m = new MemoryStream(img);
            return Image.FromStream(m);
        }
        private async void ShowInfo()
        {
            FirebaseResponse response = await client.GetAsync("accountss/" + Username);
            User user = response.ResultAs<User>();
            if (user != null)
            {

                if (user.Image != null && user.Image != "")
                {
                    profileimage.Image = Base64StringToImage(user.Image);
                }
                else
                {
                    profileimage.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Sound1()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\home.wav");
            sound1.Play();

        }
        private void Sound2()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OpenChildForm(Form childFrom)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childFrom);
            panelDesktop.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new PlayervsPlayer());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Reset();
            Sound2();
        }

        private void home1_Load(object sender, EventArgs e)
        {
            Sound1();
           //ShowInfo();
            lbDate1.Text = library.changeDate(DateTime.Now.DayOfWeek.ToString()) + " " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime1.Text = "Bây giờ là: " + DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new PlayervsPc());
        }
    }
}
