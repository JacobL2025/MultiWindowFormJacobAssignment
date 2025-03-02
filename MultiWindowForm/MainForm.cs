using System;
using System.IO;
using System.Windows.Forms;
namespace MultiWindowForm
{

    public partial class MainForm : Form
    {
        private NewCustomerForm _customerForm;
        private List<Customer> _customerList;
        public MainForm()
        {
            InitializeComponent();
            _customerForm = new NewCustomerForm(this);
            _customerList = new List<Customer>();

            LoadCustomerFromMyFiles(); // this should load once the program starts, and populate the dgv.

            ReloadDataGrid(); // this should refresh the dgv so it reflects the current info in the csv file, before i add any new customers.

            //_customerList.Add(new Customer
            //{
            //    Name = "Jacob",
            //    Email = "jacob.larson@student.centralia.edu", // this might be the issue mentioned below. i think this is what it is putting into the dgv
            //    PhoneNumber = "555-5555"
            //});

            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _customerList;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _customerForm.ShowDialog();
        }

        public void AddCustomer(Customer customer)
        {
            customer.CustomerId = _customerList.Count + 1;
            
            _customerList.Add(customer);

            SaveCustomersToMyFile();

            ReloadDataGrid();



        }

        public void EditCustomer(int id, Customer UpdatedCustomer)
        {
            MessageBox.Show("Mainform is editing the customer now");

            // find the customer out of the list, by id
            var cust = _customerList.Find(c => c.CustomerId == id);

            // did we get a customer
            if (cust != null)
            {
                // found one, process the customer
                cust.Name = UpdatedCustomer.Name;
                cust.Email = UpdatedCustomer.Email;
                cust.PhoneNumber = UpdatedCustomer.PhoneNumber;

                SaveCustomersToMyFile();

                ReloadDataGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {



            // get the row out of the data grid view
            Customer cust;

            // get the position of the selected item from the data grid view
            var index = dgvCustomers.SelectedRows[0].Index;

            // gets the exact customer out of the array
            cust = _customerList[index];

            // load the customer into the form
            _customerForm.LoadCustomer(cust);

            _customerForm.ToggleEdit(true);

            // show the form
            _customerForm.Show();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = true;
        }

        public void SaveCustomersToMyFile()
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "MyCustomers.csv");

            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, false))  
                {
                    writer.WriteLine("Name,Email,Phone Number");  
                    foreach (var Customer in _customerList)  
                    {
                        writer.WriteLine($"{Customer.Name},{Customer.PhoneNumber},{Customer.Email}");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("This File wasn't created. Sorry about that!");
            }
        }


        public void LoadCustomerFromMyFiles() // I am going to use this to load the data from the csv file into the datagridview.
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "MyCustomers.csv");

            try
            {
                if (File.Exists(filepath))
                {
                    _customerList.Clear(); // This should stop duplication

                    string[] lines = File.ReadAllLines(filepath); // this is going to read all the lines from the csv file

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] customerInfo = lines[i].Split(','); // this and the line above should skip the header of the csv

                        if (customerInfo.Length == 3) // this is making sure the info is correct before it pulls it.
                        {
                            Customer customer = new Customer
                            {
                                Name = customerInfo[0],
                                Email = customerInfo[1],
                                PhoneNumber = customerInfo[2]
                            };

                            customer.CustomerId = _customerList.Count + 1; // this should help with customer id?

                            _customerList.Add(customer);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("We don't have any customer data. Add some to get started!");

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Something had gone wrong. Please try again. or don't!");
            }
        }

    }
}

//  csv file thought process


// create csv file
// from new customer form, write info into csv file from Customer Id, Name, Email, Phone Number. according to google i need  using = system.IO
// when save is clicked, save info into csv.
// after info is saved, have program refresh data grid view to reflect new info from csv/new customer form
// on load, have program pull info from csv file, and put it into the data grid view.

// WE HAVE MADE PROGRESS!!!!!!!!!!!! It is reading from the csv file, but when i type info into the text boxes, it doesn't save what i type, it just saves from the first item of the dgv.