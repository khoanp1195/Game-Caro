
namespace Game_Caro
{
    partial class PlayervsPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMusic = new Bunifu.Framework.UI.BunifuFlatButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.btnPlayAgain = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pct_playername = new System.Windows.Forms.PictureBox();
            this.text_IP = new System.Windows.Forms.TextBox();
            this.prcb_CoolDown = new System.Windows.Forms.ProgressBar();
            this.text_playername = new System.Windows.Forms.TextBox();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.pnl_chessboard = new System.Windows.Forms.Panel();
            this.radLiveTileElement1 = new Telerik.WinControls.UI.RadLiveTileElement();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayAgain)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_playername)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel3.BackgroundImage = global::Game_Caro.Properties.Resources._32bb8d420c4c0edc7356bba3a6acf6e6;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.btnMusic);
            this.panel3.Controls.Add(this.radButton1);
            this.panel3.Controls.Add(this.radButton2);
            this.panel3.Controls.Add(this.btnPlayAgain);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.pct_playername);
            this.panel3.Controls.Add(this.text_IP);
            this.panel3.Controls.Add(this.prcb_CoolDown);
            this.panel3.Controls.Add(this.text_playername);
            this.panel3.Location = new System.Drawing.Point(865, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 465);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnMusic
            // 
            this.btnMusic.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnMusic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMusic.BorderRadius = 0;
            this.btnMusic.ButtonText = "Music: On";
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.DisabledColor = System.Drawing.Color.Gray;
            this.btnMusic.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMusic.Iconimage = global::Game_Caro.Properties.Resources.icons8_sound_96;
            this.btnMusic.Iconimage_right = null;
            this.btnMusic.Iconimage_right_Selected = null;
            this.btnMusic.Iconimage_Selected = null;
            this.btnMusic.IconMarginLeft = 0;
            this.btnMusic.IconMarginRight = 0;
            this.btnMusic.IconRightVisible = true;
            this.btnMusic.IconRightZoom = 0D;
            this.btnMusic.IconVisible = true;
            this.btnMusic.IconZoom = 90D;
            this.btnMusic.IsTab = false;
            this.btnMusic.Location = new System.Drawing.Point(21, 380);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnMusic.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnMusic.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMusic.selected = false;
            this.btnMusic.Size = new System.Drawing.Size(158, 76);
            this.btnMusic.TabIndex = 6;
            this.btnMusic.Text = "Music: On";
            this.btnMusic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMusic.Textcolor = System.Drawing.Color.White;
            this.btnMusic.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click_1);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(22, 326);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(123, 36);
            this.radButton1.TabIndex = 10;
            this.radButton1.Text = "Connect Lan";
            this.radButton1.ThemeName = "MaterialTeal";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click_1);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(185, 378);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(117, 36);
            this.radButton2.TabIndex = 9;
            this.radButton2.Text = "New Game";
            this.radButton2.ThemeName = "MaterialTeal";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.Location = new System.Drawing.Point(185, 420);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(120, 36);
            this.btnPlayAgain.TabIndex = 8;
            this.btnPlayAgain.Text = "Đi lại";
            this.btnPlayAgain.ThemeName = "MaterialTeal";
            this.btnPlayAgain.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 224);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Game_Caro.Properties.Resources._27327_tic_tac_toe;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(316, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pct_playername
            // 
            this.pct_playername.BackColor = System.Drawing.Color.Transparent;
            this.pct_playername.Location = new System.Drawing.Point(163, 239);
            this.pct_playername.Name = "pct_playername";
            this.pct_playername.Size = new System.Drawing.Size(139, 123);
            this.pct_playername.TabIndex = 6;
            this.pct_playername.TabStop = false;
            this.pct_playername.Click += new System.EventHandler(this.pct_playername_Click);
            // 
            // text_IP
            // 
            this.text_IP.Location = new System.Drawing.Point(21, 294);
            this.text_IP.Name = "text_IP";
            this.text_IP.Size = new System.Drawing.Size(124, 20);
            this.text_IP.TabIndex = 3;
            this.text_IP.Text = "127.0.0.1";
            this.text_IP.TextChanged += new System.EventHandler(this.text_IP_TextChanged);
            // 
            // prcb_CoolDown
            // 
            this.prcb_CoolDown.BackColor = System.Drawing.Color.LightSalmon;
            this.prcb_CoolDown.Location = new System.Drawing.Point(22, 265);
            this.prcb_CoolDown.Name = "prcb_CoolDown";
            this.prcb_CoolDown.Size = new System.Drawing.Size(124, 23);
            this.prcb_CoolDown.TabIndex = 1;
            this.prcb_CoolDown.Click += new System.EventHandler(this.prcb_CoolDown_Click);
            // 
            // text_playername
            // 
            this.text_playername.Location = new System.Drawing.Point(22, 239);
            this.text_playername.Name = "text_playername";
            this.text_playername.Size = new System.Drawing.Size(124, 20);
            this.text_playername.TabIndex = 0;
            this.text_playername.TextChanged += new System.EventHandler(this.text_playername_TextChanged);
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // pnl_chessboard
            // 
            this.pnl_chessboard.BackColor = System.Drawing.Color.MintCream;
            this.pnl_chessboard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_chessboard.Location = new System.Drawing.Point(31, 49);
            this.pnl_chessboard.Name = "pnl_chessboard";
            this.pnl_chessboard.Size = new System.Drawing.Size(813, 426);
            this.pnl_chessboard.TabIndex = 0;
            this.pnl_chessboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_chessboard_Paint);
            // 
            // radLiveTileElement1
            // 
            this.radLiveTileElement1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(224)))), ((int)(((byte)(227)))));
            this.radLiveTileElement1.ColSpan = 5;
            this.radLiveTileElement1.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radLiveTileElement1.Font = new System.Drawing.Font("Lucida Sans Unicode", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLiveTileElement1.Name = "radLiveTileElement1";
            this.radLiveTileElement1.RowSpan = 5;
            this.radLiveTileElement1.Text = "";
            this.radLiveTileElement1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.radLiveTileElement1.UseCompatibleTextRendering = false;
            this.radLiveTileElement1.Click += new System.EventHandler(this.radLiveTileElement1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // PlayervsPlayer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackgroundImage = global::Game_Caro.Properties.Resources.bk;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1305, 529);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_chessboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayervsPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlayAgain)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pct_playername)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox text_IP;
        private System.Windows.Forms.TextBox text_playername;
        private System.Windows.Forms.PictureBox pct_playername;
        private System.Windows.Forms.Timer tmCoolDown;
        private System.Windows.Forms.Panel pnl_chessboard;
        private Telerik.WinControls.UI.RadLiveTileElement radLiveTileElement1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar prcb_CoolDown;
        private Telerik.WinControls.UI.RadButton btnPlayAgain;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Bunifu.Framework.UI.BunifuFlatButton btnMusic;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerPlay;
    }
}

