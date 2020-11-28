using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration; 
namespace WindowsFormsApplication2
{
    class viewclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
        string query;
        public viewclass(string q) 
        {
            this.query = q;
        }

        public DataTable showrecord()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO Data Found");
            }
            finally {
                conn.Close();
            }
            return dt;

        }
    }
}
