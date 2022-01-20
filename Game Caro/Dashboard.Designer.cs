
namespace Game_Caro
{
    partial class Dashboard
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_currentUser = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.msManhinhchinh = new System.Windows.Forms.MenuStrip();
            this.lbTime1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbDate1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btndashboard = new FontAwesome.Sharp.IconButton();
            this.btncustomer = new FontAwesome.Sharp.IconButton();
            this.btnroder = new FontAwesome.Sharp.IconButton();
            this.btnproduct = new FontAwesome.Sharp.IconButton();
            this.profileimage = new Game_Caro.Libary.CircularPictureBox();
            this.iconCurrentChild = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.msManhinhchinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChild)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(49)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 497);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panelMenu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 387);
            this.panel3.TabIndex = 5;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(49)))), ((int)(((byte)(70)))));
            this.panelMenu.Controls.Add(this.iconButton1);
            this.panelMenu.Controls.Add(this.btndashboard);
            this.panelMenu.Controls.Add(this.btncustomer);
            this.panelMenu.Controls.Add(this.btnroder);
            this.panelMenu.Controls.Add(this.btnproduct);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 387);
            this.panelMenu.TabIndex = 3;
            this.panelMenu.SizeChanged += new System.EventHandler(this.panelMenu_SizeChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.profileimage);
            this.panel2.Controls.Add(this.lbl_currentUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 110);
            this.panel2.TabIndex = 4;
            // 
            // lbl_currentUser
            // 
            this.lbl_currentUser.AutoSize = true;
            this.lbl_currentUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_currentUser.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentUser.ForeColor = System.Drawing.Color.Tomato;
            this.lbl_currentUser.Location = new System.Drawing.Point(109, 28);
            this.lbl_currentUser.Name = "lbl_currentUser";
            this.lbl_currentUser.Size = new System.Drawing.Size(112, 17);
            this.lbl_currentUser.TabIndex = 6;
            this.lbl_currentUser.Text = "PHUONGKHOA";
            this.lbl_currentUser.Click += new System.EventHandler(this.lbl_currentUser_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(231, 64);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1037, 497);
            this.panelDesktop.TabIndex = 1;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(61, 38);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(45, 16);
            this.lbl_title.TabIndex = 3;
            this.lbl_title.Text = "Home";
            this.lbl_title.Click += new System.EventHandler(this.lbl_title_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // msManhinhchinh
            // 
            this.msManhinhchinh.BackColor = System.Drawing.Color.LightBlue;
            this.msManhinhchinh.Dock = System.Windows.Forms.DockStyle.None;
            this.msManhinhchinh.Font = new System.Drawing.Font("Palatino Linotype", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msManhinhchinh.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msManhinhchinh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTime1,
            this.lbDate1});
            this.msManhinhchinh.Location = new System.Drawing.Point(231, 25);
            this.msManhinhchinh.Name = "msManhinhchinh";
            this.msManhinhchinh.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msManhinhchinh.Size = new System.Drawing.Size(155, 36);
            this.msManhinhchinh.TabIndex = 6;
            this.msManhinhchinh.Text = "menuStrip1";
            // 
            // lbTime1
            // 
            this.lbTime1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime1.ForeColor = System.Drawing.Color.Peru;
            this.lbTime1.Name = "lbTime1";
            this.lbTime1.Size = new System.Drawing.Size(75, 32);
            this.lbTime1.Text = "Time:";
            // 
            // lbDate1
            // 
            this.lbDate1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate1.ForeColor = System.Drawing.Color.Peru;
            this.lbDate1.Name = "lbDate1";
            this.lbDate1.Size = new System.Drawing.Size(74, 32);
            this.lbDate1.Text = "Date:";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.iconButton1.IconColor = System.Drawing.Color.Ivory;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 240);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton1.Size = new System.Drawing.Size(228, 60);
            this.iconButton1.TabIndex = 19;
            this.iconButton1.Text = "Sign Out";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btndashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndashboard.FlatAppearance.BorderSize = 0;
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.ForeColor = System.Drawing.Color.White;
            this.btndashboard.IconChar = FontAwesome.Sharp.IconChar.Google;
            this.btndashboard.IconColor = System.Drawing.Color.Ivory;
            this.btndashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.Location = new System.Drawing.Point(0, 180);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btndashboard.Size = new System.Drawing.Size(228, 60);
            this.btndashboard.TabIndex = 15;
            this.btndashboard.Text = "Contact Us";
            this.btndashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndashboard.UseVisualStyleBackColor = false;
            this.btndashboard.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // btncustomer
            // 
            this.btncustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btncustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncustomer.FlatAppearance.BorderSize = 0;
            this.btncustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncustomer.ForeColor = System.Drawing.Color.White;
            this.btncustomer.IconChar = FontAwesome.Sharp.IconChar.StreetView;
            this.btncustomer.IconColor = System.Drawing.Color.Ivory;
            this.btncustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncustomer.Location = new System.Drawing.Point(0, 120);
            this.btncustomer.Name = "btncustomer";
            this.btncustomer.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btncustomer.Size = new System.Drawing.Size(228, 60);
            this.btncustomer.TabIndex = 18;
            this.btncustomer.Text = "Detail Profile";
            this.btncustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncustomer.UseVisualStyleBackColor = false;
            this.btncustomer.Click += new System.EventHandler(this.btncustomer_Click);
            // 
            // btnroder
            // 
            this.btnroder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnroder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnroder.FlatAppearance.BorderSize = 0;
            this.btnroder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnroder.ForeColor = System.Drawing.Color.White;
            this.btnroder.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.btnroder.IconColor = System.Drawing.Color.Ivory;
            this.btnroder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnroder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnroder.Location = new System.Drawing.Point(0, 60);
            this.btnroder.Name = "btnroder";
            this.btnroder.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnroder.Size = new System.Drawing.Size(228, 60);
            this.btnroder.TabIndex = 16;
            this.btnroder.Text = "List Game";
            this.btnroder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnroder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnroder.UseVisualStyleBackColor = false;
            this.btnroder.Click += new System.EventHandler(this.btnroder_Click);
            // 
            // btnproduct
            // 
            this.btnproduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnproduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnproduct.FlatAppearance.BorderSize = 0;
            this.btnproduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproduct.ForeColor = System.Drawing.Color.White;
            this.btnproduct.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnproduct.IconColor = System.Drawing.Color.Ivory;
            this.btnproduct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnproduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduct.Location = new System.Drawing.Point(0, 0);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnproduct.Size = new System.Drawing.Size(228, 60);
            this.btnproduct.TabIndex = 17;
            this.btnproduct.Text = "DashBoard";
            this.btnproduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproduct.UseVisualStyleBackColor = false;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            // 
            // profileimage
            // 
            this.profileimage.Location = new System.Drawing.Point(3, 8);
            this.profileimage.Name = "profileimage";
            this.profileimage.Size = new System.Drawing.Size(100, 96);
            this.profileimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.profileimage.TabIndex = 7;
            this.profileimage.TabStop = false;
            // 
            // iconCurrentChild
            // 
            this.iconCurrentChild.BackColor = System.Drawing.Color.Transparent;
            this.iconCurrentChild.ForeColor = System.Drawing.Color.Black;
            this.iconCurrentChild.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChild.IconColor = System.Drawing.Color.Black;
            this.iconCurrentChild.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChild.IconSize = 41;
            this.iconCurrentChild.Location = new System.Drawing.Point(3, 24);
            this.iconCurrentChild.Name = "iconCurrentChild";
            this.iconCurrentChild.Size = new System.Drawing.Size(52, 41);
            this.iconCurrentChild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconCurrentChild.TabIndex = 2;
            this.iconCurrentChild.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 564);
            this.Controls.Add(this.msManhinhchinh);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconCurrentChild);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.msManhinhchinh.ResumeLayout(false);
            this.msManhinhchinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btndashboard;
        private FontAwesome.Sharp.IconButton btncustomer;
        private FontAwesome.Sharp.IconButton btnroder;
        private FontAwesome.Sharp.IconButton btnproduct;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChild;
        private System.Windows.Forms.Label lbl_title;
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label lbl_currentUser;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip msManhinhchinh;
        private System.Windows.Forms.ToolStripMenuItem lbTime1;
        private System.Windows.Forms.ToolStripMenuItem lbDate1;
        private Libary.CircularPictureBox profileimage;
    }
}