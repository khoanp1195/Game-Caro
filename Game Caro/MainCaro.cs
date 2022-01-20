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
    public partial class MainCaro : Form
    {
        public MainCaro()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
         
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SignUp su = new SignUp();
            //this.Hide();
            //su.Show();
        }

        private void MainCaro_Load(object sender, EventArgs e)
        {
            
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DangKy su = new DangKy();
            this.Hide();
            su.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            SignIn si = new SignIn();
            this.Hide();
            si.Show();
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            DangKy su = new DangKy();
            this.Hide();
            su.Show();

        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {

            SignIn si = new SignIn();
            this.Hide();
            si.Show();
        }
    }
}
