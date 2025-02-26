﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("The Custoner Name is Empty");
                return;
            }

            if(CheckValidity(txtEmail))
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
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            };


            // send that data to the AddCustomer function on the parent form
            _mainForm.AddCustomer(customer);
            CustomerCount++;
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
