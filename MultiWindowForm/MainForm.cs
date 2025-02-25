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

            _customerList.Add(new Customer
            {
                Name = "Jacob",
                Email = "jacob.larson@student.centralia.edu",
                PhoneNumber = "555-5555"
            });

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
            _customerList.Add(customer);

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
    }
}
