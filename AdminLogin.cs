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
    public partial class AdminLogin : Form
    {
        public static string fk_ad;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb, passworddb;
            returnclass rc = new returnclass();
            userdb = rc.scalerReturn("select count(ad_id) from admin_authu where ad_user='" + user + "'");
            if (userdb.Equals("0")) 
            {
                MessageBox.Show("Invalid User");
            }
            else 
            {
                passworddb = rc.scalerReturn("select ad_password from admin_authu where ad_user='" + user + "'");
                if (passworddb.Equals(password))
                {
                    fk_ad = rc.scalerReturn("select ad_id from admin_authu where ad_user='" + user + "'");
                    Form2 f = new Form2();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fs = new Form1();
            fs.Show();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
