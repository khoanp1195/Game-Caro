using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ManageUser
{
    public partial class Form1 : Form
    {
         
        private PlayerDao deptDAO = new PlayerDao();
        private BindingSource bs = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bs.DataSource = deptDAO.getAllPlayers(); // List<Department>
             gv_player.DataSource = bs;


        }
    }
}
