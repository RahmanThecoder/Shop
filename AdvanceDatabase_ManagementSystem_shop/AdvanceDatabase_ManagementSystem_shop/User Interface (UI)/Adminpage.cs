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
    public partial class Adminpage : Form
    {
        public Adminpage()
        {
            InitializeComponent();
        }


        //private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    frmLogin login = new frmLogin();
        //    login.Show();
        //    this.Hide();
        //}

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users_ui user = new Users_ui();
            user.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_Categoriesui category = new Menu_Categoriesui();
            category.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productui product = new Productui();
            product.Show();
        }

        private void deealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dealer_Customerui DeaCust = new Dealer_Customerui();
            DeaCust.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventoryui inventory = new Inventoryui();
            inventory.Show();
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transactionui transaction = new Transactionui();
            transaction.Show();
        }

        private void Adminpage_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = loginpage.loggedIn;
        }

        private void Adminpage_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginpage login = new loginpage();
            login.Show();
            this.Hide();
        }
    }
}
