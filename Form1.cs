using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Hide();
            AdminLogin lg = new AdminLogin();
            lg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // Form1 f1 = new Form1();
          //  f1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentlogin sl = new studentlogin();
            sl.Show();
           
        }
    }
}
