
namespace Game_Caro
{
    partial class Huongdan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Huongdan));
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
            this.radTextBoxControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.radTextBoxControl1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel2.Location = new System.Drawing.Point(0, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(1122, 619);
            this.radPanel2.TabIndex = 1;
            // 
            // radTextBoxControl1
            // 
            this.radTextBoxControl1.BackColor = System.Drawing.Color.Transparent;
            this.radTextBoxControl1.BackgroundImage = global::Game_Caro.Properties.Resources.caro1;
            this.radTextBoxControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radTextBoxControl1.Controls.Add(this.pictureBox1);
            this.radTextBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTextBoxControl1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTextBoxControl1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.radTextBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.radTextBoxControl1.MaxLength = 214;
            this.radTextBoxControl1.Multiline = true;
            this.radTextBoxControl1.Name = "radTextBoxControl1";
            this.radTextBoxControl1.Size = new System.Drawing.Size(1122, 619);
            this.radTextBoxControl1.TabIndex = 1;
            this.radTextBoxControl1.Text = resources.GetString("radTextBoxControl1.Text");
            this.radTextBoxControl1.TextChanged += new System.EventHandler(this.radTextBoxControl1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Game_Caro.Properties.Resources._33011_question;
            this.pictureBox1.Location = new System.Drawing.Point(861, 424);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Huongdan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 619);
            this.Controls.Add(this.radPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Huongdan";
            this.Text = "Huongdan";
            this.Load += new System.EventHandler(this.Huongdan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
            this.radTextBoxControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}