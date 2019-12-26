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
    public partial class Dealer_Customerui : Form
    {
        public Dealer_Customerui()
        {
            InitializeComponent();
        }

        // creating objects for DAL(Database logic layer) and BLL(business Logic layer)

        Dealer_Customer_class dc = new Dealer_Customer_class();
        Dealer_Customer_Database dcDal = new Dealer_Customer_Database();

        Users_Database uDal = new Users_Database();

        public void Clear()
        {
            txtDeaCustID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the Values from Form
            dc.type = cmbDeaCust.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = loginpage.loggedIn;
            Users_class usr = uDal.GetIDFromUsername(loggedUsr);
            dc.added_by = usr.id;

            //Creating boolean variable to check whether the dealer or cutomer is added or not
            bool success = dcDal.Insert(dc);

            if (success == true)
            {
                //Dealer or Cutomer inserted successfully 
                MessageBox.Show("Dealer or Customer Added Successfully");
                Clear();
                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //failed to insert dealer or customer
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values from Form
            dc.id = int.Parse(txtDeaCustID.Text);
            dc.type = cmbDeaCust.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = loginpage.loggedIn;
            Users_class usr = uDal.GetIDFromUsername(loggedUsr);
            dc.added_by = usr.id;

            //create boolean variable to check whether the dealer or customer is updated or not
            bool success = dcDal.Update(dc);

            if (success == true)
            {
                //Dealer and Customer update Successfully
                MessageBox.Show("Dealer or Customer updated Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Failed to udate Dealer or Customer
                MessageBox.Show("Failed to Udpate Dealer or Customer");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the id of the user to be deleted from form
            dc.id = int.Parse(txtDeaCustID.Text);

            //Create boolean variable to check wheteher the dealer or customer is deleted or not
            bool success = dcDal.Delete(dc);

            if (success == true)
            {
                //Dealer or Customer Deleted Successfully
                MessageBox.Show("Dealer or Customer Deleted Successfully");
                Clear();
                //Refresh the Data Grid View
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Dealer or Customer Failed to Delete
                MessageBox.Show("Failed to Delete Dealer or Customer");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyowrd from text box
            string keyword = txtSearch.Text;

            if (keyword != null)
            {
                //Search the Dealer or Customer
                DataTable dt = dcDal.Search(keyword);
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                //Show all the Dealer or Customer
                DataTable dt = dcDal.Select();
                dgvDeaCust.DataSource = dt;
            }
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int variable to get the identityof row clicked
            int rowIndex = e.RowIndex;

            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cmbDeaCust.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Dealer_Customerui_Load(object sender, EventArgs e)
        {
            //Refresh Data Grid View
            DataTable dt = dcDal.Select();
            dgvDeaCust.DataSource = dt;
        }
    }
}
