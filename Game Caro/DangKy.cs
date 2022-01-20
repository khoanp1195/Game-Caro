
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Game_Caro.BUS;
using Game_Caro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Caro
{
    public partial class DangKy : Form
    {
       




        Library library = new Library();

        IFirebaseClient client;

        string gender;
        public DangKy()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
        //    //  info.name = tbName.Text;
        //    if (tbName.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbUname.Focus();
        //        return;
        //    }
        //    else if (tbName.Text.Trim().Length < 1 || tbName.Text.Trim().Length > 255)
        //    {
        //        MessageBox.Show("Độ dài tối thiểu của tài khoản là 6 và tối đa là 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbUname.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        info.name = tbName.Text;
        //    };

        //    if (rbMalee.Checked == true)
        //    {
        //        gender = "Male";
        //    }
        //    if (rbFemale.Checked == true)
        //    {
        //        gender = "Female";
        //    }
        //    info.gender = gender;

        //    info.dob = dtpDOB.Value.ToShortDateString();
        //    info.address = tbAdrs.Text;
        //    info.education = cbEdu.Text;
        //    //info.username = tbUname.Text;
        //    if (tbUname.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbUname.Focus();
        //        return;
        //    }
        //    else if (tbUname.Text.Trim().Length < 1 || tbUname.Text.Trim().Length > 255)
        //    {
        //        MessageBox.Show("Độ dài tối thiểu của tài khoản là 6 và tối đa là 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbUname.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        info.username = tbUname.Text;
        //    };
        //    //   info.password = tbPass.Text;


        //    if (tbPass.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbPass.Focus();
        //        return;
        //    }
        //    else if (tbPass.Text.Trim().Length < 6 || tbPass.Text.Trim().Length > 255)
        //    {
        //        MessageBox.Show("Độ dài tối thiểu của mật khẩu là 6 và tối đa là 255", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbPass.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        info.password = tbPass.Text;
        //    };



        //    if (tbPassConf.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbPassConf.Focus();
        //        return;
        //    }
        //    else if (tbPassConf.Text.Trim() != tbPass.Text.Trim())
        //    {
        //        MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        tbPass.Focus();
        //        return;
        //    }



        //    int rows = opr.insertEmp(info);
        //    if (rows > 0)
        //    {
        //        MessageBox.Show("Data Saved Successfully");
        //    }

        //    Account newAccount = new Account()
        //    {
        //        //userid= ,
        //        name = tbName.Text.Trim(),
        //     //   gender = tbGender.Text.Trim(),
        //        dob = dtpDOB.Value.ToShortDateString(),
        //        address = tbAdrs.Text.Trim(),
        //        education = cbEdu.Text.Trim(),
        //        username = tbUname.Text.Trim(),
        //        password = MD5Hash(tbPass.Text.Trim())
        //    };
        //    bool result = new AccountBUS().AddNew(newAccount);
        //    if (result) MessageBox.Show("Register success");
        //    else MessageBox.Show("Sorry please again");

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


        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            this.Hide();
            si.Show();
        }

        private void cbEdu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider1.SetError(txtName, "Vui lòng nhập họ và tên");
            }
            else if (txtName.Text.Length < 6 || txtName.Text.Length >= 64)
            {
                errorProvider1.SetError(txtName, "Độ dài tối thiểu của họ và tên là 6 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, null);
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                errorProvider1.SetError(txtAddress, "Vui lòng nhập địa chỉ");
            }
            else if (txtAddress.Text.Length < 3 || txtAddress.Text.Length >= 255)
            {
                errorProvider1.SetError(txtAddress, "Độ dài tối thiểu của địa chỉ là 3 và tối đa là 255 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, null);
            }
        }
        private void cboGender_Validating(object sender, CancelEventArgs e)
        {
            if (cboGender.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboGender, "Vui lòng chọn giới tính");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(cboGender, null);
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Vui lòng nhập số điện thoại");
            }
            else if (Regex.IsMatch(txtPhone.Text.Trim(), "^[a-zA-Z]"))
            {
                errorProvider1.SetError(txtPhone, "Vui lòng chỉ nhập số. Không nhập chữ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu");
            }
            else if (txtPassword.Text.Length < 6 || txtPassword.Text.Length >= 64)
            {
                errorProvider1.SetError(txtPassword, "Độ dài tối thiểu của mật khẩu là 6 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void tbPassConf_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPassword_Confirm.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword_Confirm, "Vui lòng nhập lại mật khẩu để xác nhận");
            }
            else if (txtPassword.Text.Trim() != txtPassword_Confirm.Text.Trim())
            {
                errorProvider1.SetError(txtPassword_Confirm, "Mật khẩu không trùng khớp");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword_Confirm, null);
            }
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAge, "Vui lòng nhập tuổi");
            }
            else if (Regex.IsMatch(txtAge.Text.Trim(), "^[a-zA-Z]"))
            {
                errorProvider1.SetError(txtAge, "Vui lòng chỉ nhập số. Không nhập chữ");
            }
            else if (Convert.ToInt32(txtAge.Text.Trim()) < 15)
            {
                errorProvider1.SetError(txtAge, "Xin lỗi bạn chưa đủ 15 tuổi để đăng ký");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAge, null);
            }
        }
        private void txtUser_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text.Trim()))
            {
                errorProvider1.SetError(txtUser, "Vui lòng nhập tài khoản");
            }
            else if (txtUser.Text.Length < 6 || txtUser.Text.Length >= 64)
            {
                errorProvider1.SetError(txtUser, "Độ dài tối thiểu của tài khoản là 6 và tối đa là 64 ký tự");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUser, null);
            }
        }
        private async void bunifuThinButton27_Click(object sender, EventArgs e)
        {

            if (ConnectFireBase())
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                 
                    string Name = txtName.Text.Trim();
                    string Age = txtAge.Text.Trim();
                    //string Mssv = txtMssv.Text.Trim();
                    string Gender = cboGender.Text.Trim();
                    string Address = txtAddress.Text.Trim();
                    string Phone = txtPhone.Text.Trim();
                    string Username = txtUser.Text.Trim();
                    string Password = library.MD5Hash(txtPassword.Text.Trim());
                  

                    User user = new User()
                    {
                     //  Mssv = int.Parse(Mssv),
                        Name = Name,
                        Age = Convert.ToInt32(Age),
                        Gender = Gender,
                        Address = Address,
                        Phone = Convert.ToInt32(Phone),
                        Username = Username,
                        Password = Password,
                        Image = "",
                        Rule = "",
                    };
                    try
                    {

                        if (user != null)
                        {
                            SetResponse response = await client.SetAsync("accountss/" + user.Username, user);
                         //   ResetData();
                            MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           dangnhap();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối với hệ thống. Vui lòng kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
         public void dangnhap()
        {
            SignIn si = new SignIn();
            this.Close();
            si.Show();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            this.Close();
            si.Show();
        }
    }
}
