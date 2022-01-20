using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game_Caro
{
    public class ChessBoardManager
    {

     //   #region Properties
        private Panel pnl_chessboard;
        public Panel Pnl_chessboard { get => pnl_chessboard; set => pnl_chessboard = value; }
     //   #endregion
      //  #region Initialize
        

        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }
        private int currentPlayer;
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        private TextBox playerName;
        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private PictureBox playerMark;

        public PictureBox Playermark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private event EventHandler<ButtonClickEvent> playerMarked;
        public event EventHandler<ButtonClickEvent> PlayerMarked
        {
            add
            {
                playerMarked += value;
            }
            remove
            {
                playerMarked -= value;
            }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add
            {
                endedGame += value;
            }
            remove
            {
                endedGame -= value;
            }
        }



        private Stack<PlayInfo> playTimeLine;
        public Stack<PlayInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }
        //  #region Methods
        public void DrawChessBoard()
        {
            pnl_chessboard.Enabled = true;
            pnl_chessboard.Controls.Clear();


            playTimeLine = new Stack<PlayInfo>();

            CurrentPlayer = 0;

            ChangePlayer();


            Matrix = new List<List<Button>>();

            Button oldButton = new Button()
            { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = cons.CHESS_WIDTH,
                        Height = cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()

                    };

                    btn.Click += Btn_Click;


                    Matrix[i].Add(btn);
                    pnl_chessboard.Controls.Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;

            }
        }

        public ChessBoardManager(Panel pnl_chessboard, TextBox playerName, PictureBox mark)
        {
            this.Pnl_chessboard = pnl_chessboard;
            this.PlayerName = playerName;
            this.Playermark = mark;

            this.Player = new List<Player>()
            {
                new Player("Quyen", Image.FromFile(Application.StartupPath + "\\Resources\\O1.png")),
                new Player("Phuong Khoa", Image.FromFile(Application.StartupPath + "\\Resources\\X1.png"))
            };
           

        }

        public void OtherPlayerMark(Point point)
        {
            Button btn = Matrix[point.Y][point.X];

            if (btn.BackgroundImage != null)
                return;

       
            Mark(btn);

            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }

        public void Btn_Click (object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;

            Mark(btn);

            
            
           playTimeLine.Push(new PlayInfo(GetChessPoint(btn), CurrentPlayer));

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new ButtonClickEvent((GetChessPoint(btn))));
            if (isEndGame(btn))
            {
                EndGame();
            }
         

        }
        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
            int winner = CurrentPlayer == 1 ? 0 : 1;
            MessageBox.Show("Kết thúc!\n" + Player[winner].Name + " Win =.=!");

        }
        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndPrimary(btn) || isEndVertical(btn) || isEndSub(btn);
        }
        
        private Point GetChessPoint(Button btn)
        {
           

            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);

            return point;
        }
        
        
        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for(int i = point.X; i >=0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }

            int countRight = 0;
            for (int i = point.X + 1; i < cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }


            return countLeft + countRight == 5; 
        }

        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = point.Y + 1; i < cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }


            return countBottom + countTop == 5;
        }

        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X -i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= cons.CHESS_BOARD_HEIGHT || point.X + i >= cons.CHESS_BOARD_WIDTH)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }


            return countBottom + countTop == 5;
        }

        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }

            int countBottom = 0;
            for (int i = 1; i <= cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= cons.CHESS_BOARD_HEIGHT || point.X - i < 0)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }


            return countBottom + countTop == 5;
        }


        public bool Undo()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            PlayInfo oldPoint = PlayTimeLine.Peek();
            CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;
        }
        private bool UndoAStep()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            PlayInfo oldPoint = playTimeLine.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;


            if (PlayTimeLine.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldPoint = PlayTimeLine.Peek();
              //  CurrentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;
            }

            ChangePlayer();

            return true;
        }


        private void Mark(Button btn)
        {

            btn.BackgroundImage = Player[CurrentPlayer].Mark;
            Sound();

        }
        private void Sound()
        {
            System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Application.StartupPath + "\\Sound\\bloop.wav");
            sound.Play();
          
        }
       

        private void ChangePlayer()
        {

            PlayerName.Text = Player[CurrentPlayer].Name;

            Playermark.Image = Player[CurrentPlayer].Mark;
        }
        public class ButtonClickEvent : EventArgs
        {
            private Point clickedPoint;

            public Point ClickedPoint
            {
                get { return clickedPoint; }
                set { clickedPoint = value; }
            }

            public ButtonClickEvent(Point point)
            {
                this.ClickedPoint = point;
            }
        }
    }

}


