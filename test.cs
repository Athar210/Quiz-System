using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class test : Form 
    {
        string correctop;
        int i,score=0;
        
       
        
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
      
        

        public test()
        {
            InitializeComponent();
        }
        returnclass rc = new returnclass();
        private void test_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connstring);
  
          label3.Text = score.ToString();
          i=  Convert.ToInt16(rc.scalerReturn("select min(q_id) from questions where q_fk_ex="+studentlogin.exam_id));
          label1.Text = rc.scalerReturn("select q_title from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
          radioButton1.Text = rc.scalerReturn("select q_opa from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
          radioButton2.Text = rc.scalerReturn("select q_opb from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
          radioButton3.Text = rc.scalerReturn("select q_opc from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
          radioButton4.Text = rc.scalerReturn("select q_opd from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
          correctop = rc.scalerReturn("select q_opcorrect from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
}
        string s,selectedvalue;
        private void button1_Click(object sender, EventArgs e)
        {
             
            if (radioButton1.Checked==true)
            {
                selectedvalue = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                selectedvalue = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                selectedvalue = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                selectedvalue = radioButton4.Text;
            }

            else
            {
                MessageBox.Show("Select One Option");
            }


            if (selectedvalue.Equals(correctop))
            {  
            score++;
            label3.Text = score.ToString();
            }


            s = rc.scalerReturn("select min(q_id) from questions where q_id>" + i + "and q_fk_ex=" + studentlogin.exam_id);
            if (s.Equals(""))
            {
                MessageBox.Show("Quiz Over!");
                button1.Enabled = false;
                MessageBox.Show("Your Score is "+score);
                studentmarks ss = new studentmarks();
                ss.marks = score.ToString();
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into studentmarks values('" + (ss.ID+1) + "', '" + ss.marks + "','"+"asghar"+"' )", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully.");
                conn.Close();
                
            }
            else
            {
                i = Convert.ToInt32(s);
                label1.Text = rc.scalerReturn("select q_title from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
                radioButton1.Text = rc.scalerReturn("select q_opa from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
                radioButton2.Text = rc.scalerReturn("select q_opb from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
                radioButton3.Text = rc.scalerReturn("select q_opc from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
                radioButton4.Text = rc.scalerReturn("select q_opd from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);
                correctop = rc.scalerReturn("select q_opcorrect from questions where q_id=" + i + "and q_fk_ex=" + studentlogin.exam_id);


            } radiobtn();
                

            
        }

        public void radiobtn() {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 s = new Form1();
            s.Show();

        }
    
    
    }
}
