
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FontAwesome.Sharp;
using Game_Caro;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ProjectKTPM
{
    public partial class Form1 : MaterialForm
    {
        private Form currentChildForm;
        public string Username = "";
        public string Rule = "";
        public string Mssv = "";

     //   Library library = new Library();
        IFirebaseClient client;

        private IconButton currentBtn;
        private Panel leftBorderBtn;
     

      //  Library library = new Library();

        public bool ConnectFireBase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "mtqW68Ko0KJ4gZbypVAFXvVB21K49n7pd8GLlAB7",
                // Realtime Database
                BasePath = "https://ktpm-156ad-default-rtdb.asia-southeast1.firebasedatabase.app/",
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
        public Form1()
        {
            InitializeComponent();
            PopulateTelerikThemes();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.LightBlue200, TextShade.WHITE);





            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        public Form1(string username, string rule)
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
                    pictureBox1.Image = Base64StringToImage(user.Image);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        //    ShowInfo();
        //    lbDate.Text = library.changeDate(DateTime.Now.DayOfWeek.ToString()) + " " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

            if (Username != null && Username != "")
            {
                lbl_Username.Text = "" + Username;
            }
            //lbl_Username.Text = "" + Informations.Ten;
            //lb_gender.Text = "" + Informations.genderr;
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
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
               // leftBorderBtn.BackColor = color;
                //leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                //leftBorderBtn.Visible = true;
                //leftBorderBtn.BringToFront();

                //Icon Curretn Child Form
                iconCurrentChild.IconChar = currentBtn.IconChar;
                iconCurrentChild.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(50,50,50);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
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
            lbl_title.Text = childFrom.Text;
        }


        private void btnproduct_Click(object sender, EventArgs e)
        {
        
            ActivateButton(sender, RGBColor.color1);
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
          //  OpenChildForm(new PhongBan());
            ActivateButton(sender, RGBColor.color2);
            SignIn si = new SignIn();
            si.Show();
            this.Close();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
         
                //ds.Show();
            //   OpenChildForm(new Employee_Dependence());
            ActivateButton(sender, RGBColor.color4);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnroder_Click(object sender, EventArgs e)
        {
        //   OpenChildForm(new KhachHang());
            ActivateButton(sender, RGBColor.color3);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
          /// OpenChildForm(new QuanLyKhachHang());
            ActivateButton(sender, RGBColor.color1);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new HoaDon());
            ActivateButton(sender, RGBColor.color5);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
         //   OpenChildForm(new frmAccount());
            ActivateButton(sender, RGBColor.color6);
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
        //    OpenChildForm(new PhongBan());
         
            ActivateButton(sender, RGBColor.color1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            Reset();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconCurrentChild_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PopulateTelerikThemes()
        {
            //CreateThemeMenuItem(radMenuItem1, "Default", "Default");
            //CreateThemeMenuItem(radMenuItem1, "Aqua", "Aqua");
            //CreateThemeMenuItem(radMenuItem1, "Breeze", "Breeze");
            //CreateThemeMenuItem(mnuTelerikThemes, "Crystal", "Crystal");
            //CreateThemeMenuItem(mnuTelerikThemes, "CrystalDark", "CrystalDark");
            //CreateThemeMenuItem(mnuTelerikThemes, "Desert", "Desert");
            //CreateThemeMenuItem(mnuTelerikThemes, "Fluent", "Fluent");
            //CreateThemeMenuItem(mnuTelerikThemes, "HighContrastBlack", "HighContrastBlack");
            //CreateThemeMenuItem(mnuTelerikThemes, "Material", "Material");
            //CreateThemeMenuItem(mnuTelerikThemes, "MaterialTeal", "MaterialTeal");
            //CreateThemeMenuItem(mnuTelerikThemes, "Office2007Black", "Office2007Black");
            //CreateThemeMenuItem(mnuTelerikThemes, "TelerikMetro", "TelerikMetro");

            //CreateThemeMenuItem(mnuTelerikThemes, "Office2007Black", "Office2007Black");
            //CreateThemeMenuItem(mnuTelerikThemes, "Office2010Black", "Office2010Black");
            //CreateThemeMenuItem(mnuTelerikThemes, "Office2010Blue", "Office2010Blue");
            //CreateThemeMenuItem(mnuTelerikThemes, "Office2010Silver", "Office2010Silver");
            //CreateThemeMenuItem(mnuTelerikThemes, "Windows7", "Windows7");
            //CreateThemeMenuItem(mnuTelerikThemes, "Windows8", "Windows8");
            //CreateThemeMenuItem(mnuTelerikThemes, "VisualStudio2012Light", "VisualStudio2012Light");
        }
        private void CreateThemeMenuItem(RadMenuItem parentMenu, string menuName, string themeName)
        {
            RadMenuItem newMenuItem = new RadMenuItem(menuName, themeName);
            newMenuItem.Click += new EventHandler(themeMenuItem_Click);
            parentMenu.Items.Add(newMenuItem);
        }
        void themeMenuItem_Click(object sender, EventArgs e)
        {
            RadMenuItem menuItem = sender as RadMenuItem;
            ThemeResolutionService.ApplicationThemeName = menuItem.Tag as string;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void lbl_Username_Click(object sender, EventArgs e)
        {

        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // OpenChildForm(new Lien_He());
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   OpenChildForm(new Sanh1());
            //Sanh1 sanh1 = new Sanh1();
            //sanh1.Show();
            //this.Close();
            //currentChildForm.Close();
            //Reset();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  frmAccount frm = new frmAccount(Username, Rule);
            OpenChildForm(new Game(Username, Rule));
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

          ///  FrmEmail em = new FrmEmail();
           // em.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = "Bây giờ là: " + DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
        }

        private void lbDate_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void lb_gender_Click(object sender, EventArgs e)
        {

        }

        private void lbTime_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          //  OpenChildForm(new Thongke());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
