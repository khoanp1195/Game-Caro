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
    public partial class home : Telerik.WinControls.UI.RadForm
    {
        public home()
        {
            InitializeComponent();
            Sound1();
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
        private void home_Load(object sender, EventArgs e)
        {

        }

        private void SignUppp_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Sound2();
            PlayervsPc frm1 = new PlayervsPc();
            frm1.Show();
            this.Close();
        }




        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Sound2();

            this.Close();
          
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            Sound2();
            Game g = new Game();
            g.Show();
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Sound2();
            PlayervsPlayer frm1 = new PlayervsPlayer();
            frm1.Show();
            this.Close();
       
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Sound2();
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("are you sure exit game", "Notice", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
