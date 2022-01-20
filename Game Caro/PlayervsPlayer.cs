using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static Game_Caro.ChessBoardManager;

namespace Game_Caro
{
 
    public partial class PlayervsPlayer :Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        SocketManager socket;
        public bool IsPlayMusic { get => isPlayMusic; set => isPlayMusic = value; }
        bool isPlayMusic;
        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();


        string info = "Chào mừng các bạn đến với game cờ Caro\nLuật chơi:\n -Người chơi 1 đi trước: đánh vào vị trí bất\nkỳ trên bàn cờ.\n" +
         "-Khi tới lượt: người chơi phải tick vào một\n ô trên bàn cờ. Tick đủ 5 ô trở lên ô theo \nchiều dọc chiều ngang hoặc đường chéo mà \nkhông bị chặn 2 đầu thì sẽ thắng. " +
         "\n -Mỗi người chơi có 20s để đi. Sau 20s đó \nngười chơi không tick vào ô sẽ bị xử thua.\n**Chúc các bạn chơi vui vẻ**" +
         "\n**Author : Nguyễn Hoàng Nam";
        #endregion


        public PlayervsPlayer()
        {
          
            
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            ChessBoard = new ChessBoardManager(pnl_chessboard, text_playername,pct_playername);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            prcb_CoolDown.Step = cons.COOL_DOWN_STEP;
            prcb_CoolDown.Maximum = cons.COOL_DOWN_TIME;
            prcb_CoolDown.Value = 0;


            tmCoolDown.Interval = cons.COOLD_DOWN_INTERVAL;
     
            ChessBoard.DrawChessBoard();

            tmCoolDown.Start();

            socket = new SocketManager();
            NewGame();


            mediaPlayer.URL = @"Sound\NARUTO Main Theme.mp3";
            mediaPlayer.settings.setMode("autoRewind", true);
            mediaPlayer.settings.setMode("loop", true);
            mediaPlayer.settings.volume = 50;
            mediaPlayer.controls.play();
            IsPlayMusic = true;

        }


        void EndGame()
        {
            tmCoolDown.Stop();
            pnl_chessboard.Enabled = false;
            btnPlayAgain.Enabled = false;
            Sound1();
     //       MessageBox.Show("Finish");
          
        }
        private void Sound1()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\win.wav");
            sound1.Play();

        }
        void NewGame()
        {
            btnPlayAgain.Enabled = true;
            prcb_CoolDown.Value = 0;
            tmCoolDown.Stop();
            ChessBoard.DrawChessBoard();


            
        }
        void Quit()
        {

            home h = new home();
            h.Show();
        }
        void Undo()
        {
            ChessBoard.Undo();
            prcb_CoolDown.Value = 0;
        }
        private void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            tmCoolDown.Start();
            prcb_CoolDown.Value = 0;
            pnl_chessboard.Enabled = false;
            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));

            btnPlayAgain.Enabled = false;
            Listen();
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }

        private void pct_Mark_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void pnl_chessboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_LAN_Click(object sender, EventArgs e)
        {

        }

        private void text_IP_TextChanged(object sender, EventArgs e)
        {

        }

        private void prcb_CoolDown_Click(object sender, EventArgs e)
        {

        }

        private void text_playername_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcb_CoolDown.PerformStep();


            if(prcb_CoolDown.Value >= prcb_CoolDown.Maximum)
            {
               
                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));

            }
        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound3();
            NewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound3();
            Quit();
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("are you sure exit game", "Notice", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }

        }

        private void playAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound3();
            Undo();
        }

        private void radTileElement1_Click(object sender, EventArgs e)
        {

            
        }

        private void radLiveTileElement1_Click(object sender, EventArgs e)
        {
             radLiveTileElement1.Items.Add(new LightVisualElement()
            {
                Text = "Bàn cờ Caro Sử dụng bàn cờ kích thước 26×20(ô vuông) Trên một bàn cờ chỉ cho phép 2 người tham gia."
            });
            radLiveTileElement1.Items.Add(new LightVisualElement()
            {
                Text = "Lượt chơi (tick X/O) Một ván cờ có thể gồm nhiều lượt chơi. Mỗi lượt người chơi thực hiện tick các dấu X / O vào hình vuông trên bàn cờ."
            });
            radLiveTileElement1.Items.Add(new LightVisualElement()
            {
                Text = "Quân cờ: trong game sử dụng bộ dấu ký hiệu X/O ."
            });
            radLiveTileElement1.Items.Add(new LightVisualElement()
            {
                Text = "-Hai bên lần lượt đánh vào từng\nô trên bàn cờ.\n-Bên nào đạt được 5 con trên 1\nhàng ngang, dọc hoặc chéo\ntrước sẽ thắng."
            });
            radLiveTileElement1.Items.Add(new LightVisualElement()
            {
                Text = "-Nếu đánh hết tất cả các ô trên\nbàn cờ mà vẫn chưa có người\nchiến thắng thì xem như hòa."
            });
         
      
            this.radLiveTileElement1.AnimationFrames = 15; //Đặt số lượng khung hình trong quá trình chuyển đổi
            this.radLiveTileElement1.AnimationInterval = 60; //Đặt khoảng thời gian giữa mỗi khung trong quá trình chuyển đổi trong Mili giây
            this.radLiveTileElement1.ContentChangeInterval = 2000; //Đặt khoảng thời gian giữa mỗi thay đổi nội dung
            this.radLiveTileElement1.TransitionType = ContentTransitionType.SlideUp; //Đặt loại hình hoạt hình chuyển tiếp
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sound3();
        }
        private void Sound3()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\button.wav");
            sound1.Play();

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Sound3();
            Undo();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Sound3();
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            pnl_chessboard.Enabled = true;
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            Sound3();
            socket.IP = text_IP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnl_chessboard.Enabled = true;
                socket.CreateServer();
            }
            else
            {
                socket.isServer = false;
                pnl_chessboard.Enabled = false;
                Listen();
            }


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            text_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if(string.IsNullOrEmpty(text_IP.Text))
            {
                text_IP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnl_chessboard.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prcb_CoolDown.Value = 0;
                        pnl_chessboard.Enabled = true;
                        tmCoolDown.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        btnPlayAgain.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    Undo();
                    prcb_CoolDown.Value = 0;
       
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Winnnnn!!!");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Time Out");
                    break;
                case (int)SocketCommand.QUIT:
                    tmCoolDown.Stop();
                    MessageBox.Show("Người chơi đã thoát");
                    break;
                default:
                    break;
            }

            Listen();
        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {
                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            changePlayMusic();
        }

        private void btnMusic_Click_1(object sender, EventArgs e)
        {
            Sound3();
            changePlayMusic();
        }

        private void pnlInfo_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {

        }

        private void pct_playername_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Sound3();
            home h = new home();
            h.Show();
            this.Close();
        //    Quit();
        

        }
    }
    }

