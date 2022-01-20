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
    public partial class GameItems : Form
    {
        public GameItems()
        {
           // if (Program.IsInDesignMode()) return;
            InitializeComponent();
        }

        private void GameItems_Load(object sender, EventArgs e)
        {

        }
        private void Sound2()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Sound2();
            SplashScreen sp = new SplashScreen();
            sp.Show();
        }
    }
}
