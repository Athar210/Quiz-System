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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentmarks obj = new studentmarks();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addquestions a = new addquestions();
            a.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           setexam a = new setexam();
           a.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fs = new Form1();
            fs.Show();
        }
    }
}
