using AdvanceDatabase_ManagementSystem_shop.Business_Logic_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AdvanceDatabase_ManagementSystem_shop.Data_Acess_Layer
{
    class Login_Database
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(Login_class l)
        {
            //Create a boolean variable and set its value to false and return it
            bool isSuccess = false;

            //Connecting To DAtabase
            //SqlConnection conn = new SqlConnection(myconnstrng);
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to check login
                //  string sql = "SELECT * FROM tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";
                string sql = "SELECT * FROM tbl_users WHERE username=@username AND password=@password AND user_type=@user_type";
                //Creating SQL Command to pass value
                // SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd = new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);

                //msg = "Row Inserted Successfully!";
                //cmd.Parameters.AddWithValue("EMPLOYEE_ID", OracleDbType.Int32, 6).Value = Int32.Parse(employee_id_txtbx.Text);
                //cmd.Parameters.Add("LAST_NAME", OracleDbType.Varchar2, 25).Value = last_name_txtbx.Text;
                //cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2, 25).Value = email_txtbx.Text;
                //cmd.Parameters.Add("HIRE_DATE", OracleDbType.Date, 7).Value = hire_date_picker.SelectedDate;
                //cmd.Parameters.Add("JOB_ID", OracleDbType.Varchar2, 10).Value = job_id_txtbx.Text;


                //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                //Checking The rows in DataTable 
                if (dt.Rows.Count > 0)
                {
                    //Login Sucessful
                    isSuccess = true;
                }
                else
                {
                    //Login Failed
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

    }
}
