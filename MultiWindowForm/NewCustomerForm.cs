using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace MultiWindowForm
{
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount = 0;
        private bool IsEditing;
        private int CurrentSelectionId;
        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount++;
            IsEditing = false;
            CurrentSelectionId = -1;
        }

        private void lblEmailHeading_Click(object sender, EventArgs e)
        {

        }

        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;

            
        }

        private void CreateCustomer()
        {
            if (CheckValidity(txtName))
            {
                MessageBox.Show("The Customer Name is Empty");
                return;
            }

            if (CheckValidity(txtEmail))
            {
                MessageBox.Show("The Customer Email Is Empty");
                return;
            }

            if (CheckValidity(txtPhoneNumber))
            {
                MessageBox.Show("There is No Customer Phone Number");
                return;
            }
            Customer customer = new Customer
            {
                CustomerId = CustomerCount,
                Name = txtName.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
            };

            string name = txtName.Text; // info for the csv file to pull from i think
            string email = txtEmail.Text; // ""
            string phoneNumber = txtPhoneNumber.Text; // ""



            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "MyCustomers.csv"); // need to do more research on this

            try
            {
                bool fileExists = File.Exists(filepath); // this is creating a file if it doesn't exist, which i think it already exists, because i have ran this dang thing 30 times

                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    if (!fileExists) // if the file doesnt exist, this will trigger
                    {
                        writer.WriteLine("Name,Email,PhoneNumber"); // and then this will write the headers
                    }


                    writer.WriteLine($"{customer.Name},{customer.Email},{customer.PhoneNumber}"); // this should be where the data is pulled from
                }


                _mainForm.AddCustomer(customer);
                CustomerCount++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, This File Couldn't Save. Whoops!"); // even though the info isn't saving right now, this doesn't pop up. I guess the process isn't breaking, but it isn't working properly either.
            }
            }

        private bool CheckValidity(Control control)
        {
            return control.Text == "";
            // some logic to validate the various inputs

            // set this to the validity of the form
            
        }

        private void EditCustomer()
        {
            if (CheckValidity(txtName))
            {
                MessageBox.Show("The Custoner Name is Empty");
                return;
            }

            if (CheckValidity(txtEmail))
            {
                MessageBox.Show("The Customer Email Is Empty");
                return;
            }

            if (CheckValidity(txtPhoneNumber))
            {
                MessageBox.Show("There is No Customer Phone Number");
                return;
            }

                // tell the main form what customer looks like
                _mainForm.EditCustomer(CurrentSelectionId, new Customer
            {
                CustomerId = CurrentSelectionId,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            });

            CurrentSelectionId = -1;
            ToggleEdit(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (IsEditing)
            {
                EditCustomer();
            }
            else
            {
                // create a new customer
                CreateCustomer();
            }



            // clear the new customer form
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";


            // close the form if we want to
            Hide();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
        }

        public void LoadCustomer(Customer customer)
        {
            CurrentSelectionId = customer.CustomerId;
            txtName.Text= customer.Name;
            txtEmail.Text= customer.Email;
            txtPhoneNumber.Text= customer.PhoneNumber;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
