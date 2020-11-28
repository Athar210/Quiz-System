using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
namespace WindowsFormsApplication2
{
    class insertclass
    {
        private string connstring = ConfigurationManager.ConnectionStrings["quiz"].ConnectionString;
        public string  insert_srecord(questions q)
        {
            string msg = " ";
            SqlConnection conn =new SqlConnection(connstring);
        try 
	        {	        
		        SqlCommand cmd = new SqlCommand("[insert_record]",conn);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.Add("@q_title",SqlDbType.NVarChar).Value= q.q_title;
            cmd.Parameters.Add("@q_opa",SqlDbType.NVarChar,200).Value= q.q_opa;
            cmd.Parameters.Add("@q_opb",SqlDbType.NVarChar,200).Value= q.q_opb;
            cmd.Parameters.Add("@q_opc",SqlDbType.NVarChar,200).Value= q.q_opc;
            cmd.Parameters.Add("@q_opd",SqlDbType.NVarChar,200).Value= q.q_opd;
            cmd.Parameters.Add("@q_opcorrect",SqlDbType.NVarChar,200).Value= q.q_opcorrect;
            cmd.Parameters.Add("@q_addeddate",SqlDbType.NVarChar,200).Value= q.q_addeddate;
            cmd.Parameters.Add("@q_fk_ad",SqlDbType.Int).Value= q.q_fk_ad;
            cmd.Parameters.Add("@q_fk_ex",SqlDbType.Int).Value= q.q_fk_ex;
            conn.Open();
            cmd.ExecuteNonQuery();
            msg="data successfully added!";
            
          


	        }
        catch (Exception)
	        {
		
		        msg="data is not inserted!";
	        }
            finally
            {
            conn.Close();
            }
            return msg;

        }














        public string insert_setexam(string date,string stid,string exid)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                SqlCommand cmd = new SqlCommand("[insert_set_exam]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@set_exam_date", SqlDbType.NVarChar).Value = date;
                cmd.Parameters.Add("@stu_id_fk", SqlDbType.NVarChar).Value = stid;
                cmd.Parameters.Add("@exam_id_fk", SqlDbType.NVarChar).Value = exid;
                
                conn.Open();
                cmd.ExecuteNonQuery();
                msg = "data successfully added!";



            }
            catch (Exception)
            {

                msg = "data is not inserted!";
            }
            finally
            {
                conn.Close();
            }
            return msg;

        }









        
    
    }
}
