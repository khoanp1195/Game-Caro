
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Game_Caro
{
    public partial class Game : Form
    {

      
        public string utype;

        public string Username = "";
        public string Rule = "";
 
        Library library = new Library();

        IFirebaseClient client;


        public Game()
        {
            InitializeComponent();
            ConnectFireBase();
            //ChessBoard = new ChessBoardManager(panel_chessboard, text_playername, pct_playername);
            //ChessBoard.EndedGame += ChessBoard_EndedGame;
            //ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            //prcb_CoolDown.Step = cons.COOL_DOWN_STEP;
            //prcb_CoolDown.Maximum = cons.COOL_DOWN_TIME;
            //prcb_CoolDown.Value = 0;


            //tmCoolDown.Interval = cons.COOLD_DOWN_INTERVAL;

            //ChessBoard.DrawChessBoard();

            //tmCoolDown.Start();
            //NewGame();
        }

        public Game(string username, string rule)
        {
            InitializeComponent();
            ConnectFireBase();
            this.Username = username;

            this.Rule = rule;
        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radLiveTileElement1_Click(object sender, EventArgs e)
        {

            
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }
        public void ConnectFireBase()
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

                }
                else
                {
                    MessageBox.Show("Không thể kết nối đến cơ sỡ dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            ShowInfo();
            //tbName.Text = "" + Informations.namee;
            //tbAdrss.Text = ""+ Informations.addresss;
            //tbUname.Text = "" + Informations.usernamee;
            //dtpDOB.Text = " " + Informations.dobb;
            //tbRole.Text = "" + Informations.usertype;
            //cbEdu.Text = "" + Informations.educationn;
            //tbSex.Text = "" + Informations.genderr;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
            this.Close();
        }

        private  async void btnUpdate_Click(object sender, EventArgs e)
        {

          
        }
        private async void ShowInfo()
        {
            FirebaseResponse response = await client.GetAsync("accountss/" + Username);
            User user = response.ResultAs<User>();
            if (user != null)
            {
                txtName.Text = user.Name;
                txtAge.Text = user.Age.ToString();
                cboGender.Text = user.Gender;
                txtAddress.Text = user.Address;
                txtPhone.Text = "0" + user.Phone.ToString();
                txtUser.Text = user.Username;
                txtUser.Enabled = true;
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
        private void Sound2()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }
        private void SignUppp_Click(object sender, EventArgs e)
        {
            Sound2();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image files(*.jpg,*.jpeg,*.bmp,*.png) | *.jpg; *.jpeg; *.bmp; *.png|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                profileimage.Load(ofd.FileName);
            }
        }

        private async void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Sound2();
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtName.Text.Length < 6 || txtName.Text.Length >= 64)
            {
                MessageBox.Show("Độ dài tối thiểu của họ và tên là 6 và tối đa là 64 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Regex.IsMatch(txtAge.Text.Trim(), "^[a-zA-Z]"))
            {
                MessageBox.Show("Vui lòng chỉ nhập số cho tuổi. Không nhập chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Convert.ToInt32(txtAge.Text.Trim()) < 15)
            {
                MessageBox.Show("Xin lỗi bạn chưa đủ 15 tuổi để đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtAddress.Text.Length < 3 || txtAddress.Text.Length >= 255)
            {
                MessageBox.Show("Độ dài tối thiểu của địa chỉ là 3 và tối đa là 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Regex.IsMatch(txtPhone.Text.Trim(), "^[a-zA-Z]"))
            {
                MessageBox.Show("Vui lòng chỉ nhập số cho số điện thoại. Không nhập chữ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtUser.Text.Length < 6 || txtUser.Text.Length >= 64)
            {
                MessageBox.Show("Độ dài tối thiểu của tài khoản là 6 và tối đa là 64 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if (txtPassword.Text.Trim() != txtPassword_Confirm.Text.Trim())
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string Name = txtName.Text.Trim();
            int Age = Convert.ToInt32(txtAge.Text.Trim());
            string Gender = cboGender.Text.Trim();
            string Address = txtAddress.Text.Trim();
            int Phone = Convert.ToInt32(txtPhone.Text.Trim());
            string username = txtUser.Text.Trim();

            string password = txtPassword.Text.Trim();
            if (password != null && password != "")
            {
                password = library.MD5Hash(password);
            }

            FirebaseResponse result = await client.GetAsync("accountss/" + Username);
            User user = result.ResultAs<User>();
            if (user != null)
            {
                if (password != null && password != "")
                {

                    user.Name = Name;
                    user.Age = Age;
                    user.Gender = Gender;
                    user.Address = Address;
                    user.Phone = Phone;
                    user.Password = password;
                    user.Image = ImageToBase64String(profileimage);
                }
                else
                {
                    user.Name = Name;
                    user.Age = Age;
                    user.Gender = Gender;
                    user.Address = Address;
                    user.Phone = Phone;
                    user.Image = ImageToBase64String(profileimage);
                }
                try
                {
                    if (user != null)
                    {
                        SetResponse response = await client.SetAsync("accountss/" + Username, user);
                        MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    this.Hide();
                    //  frmMain frm = new frmMain(Username, Rule);
                    //frm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
