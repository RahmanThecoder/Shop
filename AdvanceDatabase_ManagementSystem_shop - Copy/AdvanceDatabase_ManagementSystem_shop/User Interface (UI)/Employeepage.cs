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
    public partial class Employeepage : Form
    {
        public Employeepage()
        {
            InitializeComponent();
        }

        //Set a public static method to specify whether the form is purchase or sales
        public static string transactionType;


        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //set value on transactionType static method
            transactionType = "Purchase";
            Purchase_Sales_ui purchase = new Purchase_Sales_ui();
            purchase.Show();
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set the value to transacionType method to sales
            transactionType = "Sales";
            Purchase_Sales_ui sales = new Purchase_Sales_ui();
            sales.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventoryui inventory = new Inventoryui();
            inventory.Show();
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer_Customerui DeaCust = new Dealer_Customerui();
            DeaCust.Show();
        }

        private void Employeepage_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = loginpage.loggedIn;
        }

        private void Employeepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginpage login = new loginpage();
            login.Show();
            this.Hide();
        }
    }
}
