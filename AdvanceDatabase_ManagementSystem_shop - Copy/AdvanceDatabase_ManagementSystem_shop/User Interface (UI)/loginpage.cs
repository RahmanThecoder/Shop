using AdvanceDatabase_ManagementSystem_shop.Business_Logic_Layer;
using AdvanceDatabase_ManagementSystem_shop.Data_Acess_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvanceDatabase_ManagementSystem_shop.User_Interface__UI_
{
    public partial class loginpage : Form
    {
        public loginpage()
        {
            InitializeComponent();
        }

        // creating objects for DAL(Database logic layer) and BLL(business Logic layer)

        Login_class l = new Login_class();
        Login_Database dal = new Login_Database();
        public static string loggedIn;


        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //Checking the login credentials
            bool sucess = dal.loginCheck(l);
            if (sucess == true)
            {
                //Login Successfull
                MessageBox.Show("Login Successful.");
                loggedIn = l.username;
                //Need to open Respective Forms based on User Type
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            //Display Admin Dashboard
                            Adminpage admin = new Adminpage();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            //Display User Dashboard
                            Employeepage user = new Employeepage();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Display an error message
                            MessageBox.Show("Invalid User Type.");
                        }
                        break;
                }
            }
            else
            {
                //login Failed
                MessageBox.Show("Login Failed. Try Again");
            }

        }
    }
}
