
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FontAwesome.Sharp;
using Game_Caro.Model;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class Dashboard : MaterialForm
    {

        private Panel leftBorderBtn;
        private IconButton currentBtn;
        private Form currentChildForm;
  
        public string utype;


        public string Username = "";
        public string Rule = "";

        Library library = new Library();
        IFirebaseClient client;
        public Dashboard()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.LightBlue200, TextShade.WHITE);
   
        }
        public Dashboard(string username, string rule)
        {
            InitializeComponent();
            ConnectFireBase();
            this.Username = username;
            this.Rule = rule;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.LightBlue200, TextShade.WHITE);
           
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
        private void Sound2()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // lbl_currentUser.Text = "" + Informations.usernamee;
            ShowInfo();
            lbDate1.Text = library.changeDate(DateTime.Now.DayOfWeek.ToString()) + " " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

            if (Username != null && Username != "")
            {
                lbl_currentUser.Text = "Xin chào " + Username;
            }
        }
        private struct RGBColor
        {
            public static Color color1 = Color.FromArgb(176, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(50, 50, 50);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
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
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(50, 50, 50);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Curretn Child Form
                iconCurrentChild.IconChar = currentBtn.IconChar;
                iconCurrentChild.IconColor = color;
            }
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChild.IconChar = IconChar.Home;
            iconCurrentChild.IconColor = Color.White;
            lbl_title.Text = "Home";
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new Dashboard1());
            ActivateButton(sender, RGBColor.color3);
        }

        private void btnroder_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new GameItems());
            ActivateButton(sender, RGBColor.color4);
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new Game(Username, Rule));
            ActivateButton(sender, RGBColor.color5);
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Sound2();
            OpenChildForm(new FormMail());
            ActivateButton(sender, RGBColor.color6);
        }

        private void panelMenu_SizeChanged(object sender, EventArgs e)
        {

        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void lbl_currentUser_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            this.Close();
            si.Show();
            ActivateButton(sender, RGBColor.color6);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime1.Text = "Bây giờ là: " + DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
        }

        private void lbTime1_Click(object sender, EventArgs e)
        {

        }

        private void imagebk_Click(object sender, EventArgs e)
        {

        }
    }
}
