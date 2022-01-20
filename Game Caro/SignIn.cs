using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Caro.Model;


using Game_Caro.BUS;
using System.Security.Cryptography;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using ProjectKTPM;

namespace Game_Caro
{
    public partial class SignIn : Form
    {
        
        public string utype;

        IFirebaseClient client;

        Library library = new Library();


        DataTable dt = new DataTable();
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void tbUname_Click(object sender, EventArgs e)
        {
            tbUname.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            tbPass.BackColor = SystemColors.Control;

        }

        private void tbPass_Click(object sender, EventArgs e)
        {
            panel4.BackColor = Color.White;
            tbPass.BackColor = Color.White;

            tbUname.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            tbPass.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            tbPass.UseSystemPasswordChar = true;
        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            DangKy si = new DangKy();
            this.Hide();
            si.Show();
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
        private async void btLogin_Click(object sender, EventArgs e)
        {
            if (ConnectFireBase())
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string Username = tbUname.Text.Trim();
                    string Password = library.MD5Hash(tbPass.Text.Trim());
                    try
                    {
                        FirebaseResponse response = await client.GetAsync("accountss/" + Username);
                        User responseUser = response.ResultAs<User>();
                        User currentUser = new User()
                        {
                            Username = Username,
                            Password = Password
                        };
                        if (User.checkLogin(responseUser, currentUser))
                        {
                            // ResetData();
                            this.Hide();
                            // Sanh1 s = new Sanh1();
                            //s.Show();

                            Dashboard frm = new Dashboard(responseUser.Username, responseUser.Rule);
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show(User.error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối với hệ thống. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //if (ConnectFireBase())
            //{
            //    if (ValidateChildren(ValidationConstraints.Enabled))
            //    {
            //        string Username = tbUname.Text.Trim();
            //        string Password = library.MD5Hash(tbPass.Text.Trim());
            //        try
            //        {
            //            FirebaseResponse response = await client.GetAsync("accountss/" + Username);
            //            User responseUser = response.ResultAs<User>();
            //            User currentUser = new User()
            //            {
            //                Username = Username,
            //                Password = Password
            //            };
            //            if (User.checkLoginAdmin(responseUser, currentUser))
            //            {
            //                // ResetData();
            //                this.Hide();
            //                // Sanh1 s = new Sanh1();
            //                //s.Show();
            //                Form1 frm = new Form1(responseUser.Username, responseUser.Rule);
            //                frm.Show();
            //            }
            //            else
            //            {
            //                MessageBox.Show(User.error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Lỗi kết nối với hệ thống. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //if (tbUname.Text.Trim() == "")
            //{
            //    MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbUname.Focus();
            //    return;
            //}
            //else if (tbUname.Text.Trim().Length < 1 || tbUname.Text.Trim().Length > 255)
            //{
            //    MessageBox.Show("Độ dài tối thiểu của tài khoản là 6 và tối đa là 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbUname.Focus();
            //    return;
            //}
            //else
            //{
            //    info.username = tbUname.Text;
            //};


            //if (tbPass.Text.Trim() == "")
            //{
            //    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbPass.Focus();
            //    return;
            //}
            //else if (tbPass.Text.Trim().Length < 6 || tbPass.Text.Trim().Length > 255)
            //{
            //    MessageBox.Show("Độ dài tối thiểu của mật khẩu là 6 và tối đa là 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbPass.Focus();
            //    return;
            //}
            //else
            //{
            //    info.password = tbPass.Text;
            //};


            //dt = opr.login(info);

            //if (dt.Rows.Count > 0)
            //{
            //    utype = dt.Rows[0][8].ToString().Trim();
            //    if (utype == "admin")
            //    {
            //        Informations.usernamee = dt.Rows[0]["Username"].ToString();
            //        this.Hide();
            //        Form1 mda = new Form1();
            //        mda.Show();
            //    }
            //    else
            //    {

            //        Informations.usernamee = dt.Rows[0]["Username"].ToString();
            //        Informations.namee = dt.Rows[0]["Name"].ToString();
            //        Informations.addresss = dt.Rows[0]["Address"].ToString();
            //        Informations.educationn = dt.Rows[0]["Education"].ToString();
            //        Informations.usertype = dt.Rows[0]["Usertype"].ToString();
            //        Informations.dobb = dt.Rows[0]["DOB"].ToString();
            //        Informations.genderr = dt.Rows[0]["Gender"].ToString();


            //        this.Hide();

            //        Form1 mde = new Form1();
            //        mde.Show();
            //    }

            //}

            //else
            //{
            //    MessageBox.Show("Invalid username or password !");
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (ConnectFireBase())
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string Username = tbUname.Text.Trim();
                    string Password = library.MD5Hash(tbPass.Text.Trim());
                    try
                    {
                        FirebaseResponse response = await client.GetAsync("accountss/" + Username);
                        User responseUser = response.ResultAs<User>();
                        User currentUser = new User()
                        {
                            Username = Username,
                            Password = Password
                        };
                        if (User.checkLogin(responseUser, currentUser))
                        {
                            // ResetData();
                            this.Hide();
                            // Sanh1 s = new Sanh1();
                            //s.Show();

                            Dashboard frm = new Dashboard(responseUser.Username, responseUser.Rule);
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show(User.error, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối với hệ thống. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //    Account Account = new Account()
            //    {
            //        username = tbUname.Text.Trim(),
            //        password = MD5Hash(tbPass.Text.Trim())

            //    };
            //    bool result = new AccountBUS().CheckAccount(Account);
            //    if (result)
            //    {
            //        //Account.usernamee.ToString();
            //        new Dashboard().Show();
            //        this.Hide();
            //    }
            //    else MessageBox.Show("Sorry please again");
            //}
        }
    }
}
