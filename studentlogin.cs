using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class studentlogin : Form
    {
        public static string exam_id;
        public string user;
        public string password;
        test t1; // declare 
               

        
        public studentlogin()
        {
            InitializeComponent();
            t1 = new test(); // Yahan constructor mai usko value assign ki hai iska matlab agr login wala destroy hojayega tou ye t1 bhi hojayega
                      
        }

        private void button1_Click(object sender, EventArgs e)
        {
              user = textBox1.Text;
              password = textBox2.Text;

            string userdb, passworddb;
            returnclass rc = new returnclass();
            userdb = rc.scalerReturn("select count(std_id) from student_record where std_id='" + user + "'");

            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid User Name");
            }
            else
            {
                passworddb = rc.scalerReturn("select std_password from student_record where std_id='" + user + "'");

                

                if (passworddb.Equals(password))
                {
                  string val = rc.scalerReturn("select count (std_id) from student_record where std_id=(select stu_id_fk from set_exam where stu_id_fk='"+textBox1.Text+"' and exam_id_fk='"+comboBox1.SelectedValue.ToString()+"')");
                  if (val.Equals("0"))
                  {
                      MessageBox.Show("NO Such Exam Set!");
                  }
                  else
                  {
                      exam_id = comboBox1.SelectedValue.ToString();
                      this.t1.Show(); //aur yahan pe uss composition waly variable ko access krlia hai aur form ko show krwa dia
                  }
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
        }

        private void studentlogin_Load(object sender, EventArgs e)
        {
             studentmarks obj = new studentmarks();
             user = obj.ID;
            
            
            SqlDataAdapter dadpter2 = new SqlDataAdapter("select * from exams", "Data Source=DESKTOP-B6M2MNK\\SQLEXPRESS;Initial Catalog=quizapp;Integrated Security=True");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox1.DataSource = dset2.Tables[0];
            comboBox1.DisplayMember = "exam_name";
            comboBox1.ValueMember = "ex_id";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fs = new Form1();
            fs.Show();
        }
    }
}
