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
    public partial class studentmarks : Form
    {
        public string ID;
        public string marks;
        
        public studentmarks()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void studentmarks_Load(object sender, EventArgs e)
        {
            string q = "select * from studentmarks";
            viewclass vc = new viewclass(q);
            dataGridView1.DataSource = vc.showrecord();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fs = new Form2();
            fs.Show();
        }
    }
}
