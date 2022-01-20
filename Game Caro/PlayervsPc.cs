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
    public partial class PlayervsPc : Form
    {
        public bool IsPlayMusic { get => isPlayMusic; set => isPlayMusic = value; }
        bool isPlayMusic;
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        private Label[,] Map;
        private static int columns, rows;

    
        string info = "Chào mừng các bạn đến với game cờ Caro\nLuật chơi:\n -Người chơi 1 đi trước: đánh vào vị trí bất\nkỳ trên bàn cờ.\n" +
                "-Khi tới lượt: người chơi phải tick vào một\n ô trên bàn cờ. Tick đủ 5 ô trở lên ô theo \nchiều dọc chiều ngang hoặc đường chéo mà \nkhông bị chặn 2 đầu thì sẽ thắng. " +
                "\n -Mỗi người chơi có 20s để đi. Sau 20s đó \nngười chơi không tick vào ô sẽ bị xử thua.\n**Chúc các bạn chơi vui vẻ**" +
                "\n**Author : Nguyễn Hoàng Nam";


        private int player;
        private bool gameover;
        private bool vsComputer;
        private int[,] vtMap;
        private Stack<Chess> chesses;
        private Chess chess;

        public PlayervsPc()
        {
            InitializeComponent();
            columns = 20;
            rows = 17;
       

            vsComputer = true;
            gameover = false;
            player = 1;          
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();
            BuildTable();
         //   Sound1();
            loadForm();
            mediaPlayer.URL = @"Sound\home.wav";
            mediaPlayer.settings.setMode("autoRewind", true);
            mediaPlayer.settings.setMode("loop", true);
            mediaPlayer.settings.volume = 50;
            mediaPlayer.controls.play();
            IsPlayMusic = true;


        }
        void loadForm()
        {
            //timerPlay.Start();
            
            lbInfo.Text = info;
          
        }
        public void changePlayMusic()
        {
            if (IsPlayMusic == true)
            {
                btnMusic.Text = "Music: Off";
                IsPlayMusic = false;
                mediaPlayer.controls.pause();
            }
            else
            {
                btnMusic.Text = "Music: On";
                IsPlayMusic = true;
                mediaPlayer.controls.play();
            }
        }

        private void BuildTable()
        {
            for (int i = 2; i <= rows; i++)
                for (int j = 1; j <= columns; j++)
                {
                    Map[i, j] = new Label();
                    Map[i, j].Parent = pnTableChess;
                    Map[i, j].Top = i * Contain.edgeChess;
                    Map[i, j].Left = j * Contain.edgeChess;
                    Map[i, j].Size = new Size(Contain.edgeChess-1, Contain.edgeChess-1);
                    Map[i, j].BackColor = Color.Snow;
                    Map[i, j].MouseLeave += Form1_MouseLeave;
                    Map[i, j].MouseEnter += Form1_MouseEnter;
                    Map[i, j].Click += Form1_Click;
                }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (gameover)
                return;
            Label lb = (Label)sender;
            int x = lb.Top / Contain.edgeChess - 1, y = lb.Left / Contain.edgeChess;
            if (vtMap[x, y] != 0)
                return;
            player = 1;
            psbCooldownTime.Value = 0;
            tmCooldown.Start();
            lb.Image =  Image.FromFile(Application.StartupPath + "\\Resources\\X1.png");
            Sound();
            vtMap[x, y] = 1;
            Check(x, y);                        
            CptFindChess();
            chess = new Chess(lb, x, y);
            chesses.Push(chess);          
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (gameover)
                return;
            Label lb = (Label)sender;
            lb.BackColor = Color.AliceBlue;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (gameover)
                return;
            Label lb = (Label)sender;
            lb.BackColor = Color.Snow;
        }

        
        private void tmCooldown_Tick(object sender, EventArgs e)
        {
            psbCooldownTime.PerformStep();
            if (psbCooldownTime.Value >= psbCooldownTime.Maximum)
            {
                Gameover();
            }
        }
      
        private void menuUndo_Click(object sender, EventArgs e)
        {
                Chess template = new Chess();
                template = chesses.Pop();
                template.lb.Image = null;
                vtMap[template.X, template.Y] = 0;

                template = chesses.Pop();
                template.lb.Image = null;
                vtMap[template.X, template.Y] = 0;

                psbCooldownTime.Value = 0;
                player = 1;
           
        }

        private void menuQuit_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void player1VsPlayer2(object sender, EventArgs e)
        {
            vsComputer = false;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            txtNamePlayer.Text = "";
            ptbPayer.Image = null;
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable();
        }
        
        private void PlayVsComputer(object sender, EventArgs e)
        {
            Sound();
            vsComputer = true;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Image.FromFile(Application.StartupPath + "\\Resources\\O.png");
            txtNamePlayer.Text = "Player";
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable();
        }

        private void Gameover()
        {
            tmCooldown.Stop();
            gameover = true;
            backgroundgameover();
        }
        private void backgroundgameover()
        {
            for (int i = 2; i <= rows; i++)
                for (int j = 1; j <= columns; j++)
                {
                    Map[i, j].BackColor = Color.Gray;
                }
        }

      

        private void Check(int x, int y)
        {
            int i = x - 1, j = y;
            int column = 1, row = 1, mdiagonal = 1, ediagonal = 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0)
            {
                column++;
                i--;
            }
            i = x + 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows)
            {
                column++;
                i++;
            }
            i = x; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && j >= 0)
            {
                row++;
                j--;
            }
            j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && j <= columns)
            {
                row++;
                j++;
            }
            i = x - 1; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            i = x + 1; j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            i = x - 1; j = y + 1;
            while (vtMap[x, y] == vtMap[i, j] && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            i = x + 1; j = y - 1;
            while (vtMap[x, y] == vtMap[i, j] && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (row >= 5 || column >= 5 || mdiagonal >= 5 || ediagonal >= 5)
            {
                Gameover();
                if (vsComputer)
                {
                    if (player == 1)
                        MessageBox.Show("You win!!");
                    else
                        MessageBox.Show("You lost!!");
                }
            }

        }




        #region AI

        private int[] Attack = new int[7] { 0, 9, 54, 162, 1458, 13112, 118008 };
        private int[] Defense = new int[7] { 0, 3, 27, 99, 729, 6561, 59049 };

        private void PutChess(int x, int y)
        {
            Sound();
            player = 0;
            psbCooldownTime.Value = 0;          
            Map[x+1, y].Image = Image.FromFile(Application.StartupPath + "\\Resources\\X.png");

            vtMap[x, y] = 2;
            Check(x, y);

            chess = new Chess(Map[x+1, y], x, y);
            chesses.Push(chess);
        }

        private void CptFindChess()
        {
            if (gameover) return;
            long max = 0;
            int imax = 1, jmax = 1;
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                    if (vtMap[i, j] == 0)
                    {
                        long temp = Caculate(i, j);
                        if (temp > max)
                        {
                            max = temp;
                            imax = i; jmax = j;
                        }
                    }
            }
            PutChess(imax, jmax);
        }
        private long Caculate(int x, int y)
        {
            return EnemyChesses(x, y) + ComputerChesses(x, y);
        }
        private long ComputerChesses(int x, int y)
        {
            int i = x - 1, j = y;
            int column = 0, row = 0, mdiagonal = 0, ediagonal = 0;
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;
            while (vtMap[i, j] == 2 && i >= 0)
            {
                column++;
                i--;
            }
            if (vtMap[i, j] == 0) sc_ = 1;
            i = x + 1;
            while (vtMap[i, j] == 2 && i <= rows)
            {
                column++;
                i++;
            }
            if (vtMap[i, j] == 0) sc = 1;
            i = x; j = y - 1;
            while (vtMap[i, j] == 2 && j >= 0)
            {
                row++;
                j--;
            }
            if (vtMap[i, j] == 0) sr_ = 1;
            j = y + 1;
            while (vtMap[i, j] == 2 && j <= columns)
            {
                row++;
                j++;
            }
            if (vtMap[i, j] == 0) sr = 1;
            i = x - 1; j = y - 1;
            while (vtMap[i, j] == 2 && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            if (vtMap[i, j] == 0) sm_ = 1;
            i = x + 1; j = y + 1;
            while (vtMap[i, j] == 2 && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            if (vtMap[i, j] == 0) sm = 1;
            i = x - 1; j = y + 1;
            while (vtMap[i, j] == 2 && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            if (vtMap[i, j] == 0) se_ = 1;
            i = x + 1; j = y - 1;
            while (vtMap[i, j] == 2 && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (vtMap[i, j] == 0) se = 1;

            if (column == 4) column = 5;
            if (row == 4) row = 5;
            if (mdiagonal == 4) mdiagonal = 5;
            if (ediagonal == 4) ediagonal = 5;

            if (column == 3 && sc == 1 && sc_ == 1) column = 4;
            if (row == 3 && sr == 1 && sr_ == 1) row = 4;
            if (mdiagonal == 3 && sm == 1 && sm_ == 1) mdiagonal = 4;
            if (ediagonal == 3 && se == 1 && se_ == 1) ediagonal = 4;

            if (column == 2 && row == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (column == 2 && mdiagonal == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) column = 3;
            if (column == 2 && ediagonal == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) column = 3;
            if (row == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (row == 2 && ediagonal == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (ediagonal == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) column = 3;

            long Sum = Attack[row] + Attack[column] + Attack[mdiagonal] + Attack[ediagonal];

            return Sum;
        }
        //private void Sound1()
        //{
        //    System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\home.wav");
        //    sound1.Play();

        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            lbInfo.Text = info;
           // Sound1();
        }
        private void Sound()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\bloop.wav");
            sound.Play();

        }

        private void pnTableChess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuNewGame_Click(object sender, EventArgs e)
        {

        }

        private void menuGame_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vsComputer = true;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Image.FromFile(Application.StartupPath + "\\Resources\\X1.png"); 
            txtNamePlayer.Text = "Player";
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable();

        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Sound2()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Sound2();
            vsComputer = true;
            gameover = false;
            psbCooldownTime.Value = 0;
            tmCooldown.Stop();
            pnTableChess.Controls.Clear();

            ptbPayer.Image = Image.FromFile(Application.StartupPath + "\\Resources\\X1.png");
            txtNamePlayer.Text = "Player";
            menuStrip1.Parent = pnTableChess;
            player = 1;
            Map = new Label[rows + 2, columns + 2];
            vtMap = new int[rows + 2, columns + 2];
            chesses = new Stack<Chess>();

            BuildTable();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Sound2();
            Chess template = new Chess();
            template = chesses.Pop();
            template.lb.Image = null;
            vtMap[template.X, template.Y] = 0;

            template = chesses.Pop();
            template.lb.Image = null;
            vtMap[template.X, template.Y] = 0;

            psbCooldownTime.Value = 0;
            player = 1;
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            if (lbInfo.Location.Y + lbInfo.Height < 0)
                lbInfo.Location = new Point(lbInfo.Location.X, pnlInfo.Height);
            lbInfo.Location = new Point(lbInfo.Location.X, lbInfo.Location.Y - 1);

        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            Sound2();
            this.Close();
        }

        private void pnShow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            Sound2();
            changePlayMusic();
          
        }

        private long EnemyChesses(int x, int y)
        {
            int i = x - 1, j = y;
            int sc_ = 0, sc = 0, sr_ = 0, sr = 0, sm_ = 0, sm = 0, se_ = 0, se = 0;
            int column = 0, row = 0, mdiagonal = 0, ediagonal = 0;
            while (vtMap[i, j] == 1 && i >= 0)
            {
                column++;
                i--;
            }
            if (vtMap[i, j] == 0) sc_ = 1;
            i = x + 1;
            while (vtMap[i, j] == 1 && i <= rows)
            {
                column++;
                i++;
            }
            if (vtMap[i, j] == 0) sc = 1;
            i = x; j = y - 1;
            while (vtMap[i, j] == 1 && j >= 0)
            {
                row++;
                j--;
            }
            if (vtMap[i, j] == 0) sr_ = 1;
            j = y + 1;
            while (vtMap[i, j] == 1 && j <= columns)
            {
                row++;
                j++;
            }
            if (vtMap[i, j] == 0) sr = 1;
            i = x - 1; j = y - 1;
            while (vtMap[i, j] == 1 && i >= 0 && j >= 0)
            {
                mdiagonal++;
                i--;
                j--;
            }
            if (vtMap[i, j] == 0) sm_ = 1;
            i = x + 1; j = y + 1;
            while (vtMap[i, j] == 1 && i <= rows && j <= columns)
            {
                mdiagonal++;
                i++;
                j++;
            }
            if (vtMap[i, j] == 0) sm = 1;
            i = x - 1; j = y + 1;
            while (vtMap[i, j] == 1 && i >= 0 && j <= columns)
            {
                ediagonal++;
                i--;
                j++;
            }
            if (vtMap[i, j] == 0) se_ = 1;
            i = x + 1; j = y - 1;
            while (vtMap[i, j] == 1 && i <= rows && j >= 0)
            {
                ediagonal++;
                i++;
                j--;
            }
            if (vtMap[i, j] == 0) se = 1;

            if (column == 4) column = 5;
            if (row == 4) row = 5;
            if (mdiagonal == 4) mdiagonal = 5;
            if (ediagonal == 4) ediagonal = 5;

            if (column == 3 && sc == 1 && sc_ == 1) column = 4;
            if (row == 3 && sr == 1 && sr_ == 1) row = 4;
            if (mdiagonal == 3 && sm == 1 && sm_ == 1) mdiagonal = 4;
            if (ediagonal == 3 && se == 1 && se_ == 1) ediagonal = 4;

            if (column == 2 && row == 2 && sc == 1 && sc_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (column == 2 && mdiagonal == 2 && sc == 1 && sc_ == 1 && sm == 1 && sm_ == 1) column = 3;
            if (column == 2 && ediagonal == 2 && sc == 1 && sc_ == 1 && se == 1 && se_ == 1) column = 3;
            if (row == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (row == 2 && ediagonal == 2 && se == 1 && se_ == 1 && sr == 1 && sr_ == 1) column = 3;
            if (ediagonal == 2 && mdiagonal == 2 && sm == 1 && sm_ == 1 && se == 1 && se_ == 1) column = 3;
            long Sum = Defense[row] + Defense[column] + Defense[mdiagonal] + Defense[ediagonal];

            return Sum;
        }
        #endregion

    }

    public class Chess
    {
        public Label lb;
        public int X;
        public int Y;
        public Chess()
        {
            lb = new Label();
        }
        public Chess(Label _lb, int x, int y)
        {
            lb = new Label();
            lb = _lb;
            X = x;
            Y = y;
        }
    }
}
