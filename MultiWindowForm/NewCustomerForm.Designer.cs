namespace MultiWindowForm
{
    partial class NewCustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbCustomer = new GroupBox();
            btnSave = new Button();
            txtPhoneNumber = new TextBox();
            lblPhoneHeading = new Label();
            txtEmail = new TextBox();
            lblEmailHeading = new Label();
            txtName = new TextBox();
            lblNameHeading = new Label();
            btnClear = new Button();
            gbCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // gbCustomer
            // 
            gbCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCustomer.AutoSize = true;
            gbCustomer.Controls.Add(btnClear);
            gbCustomer.Controls.Add(btnSave);
            gbCustomer.Controls.Add(txtPhoneNumber);
            gbCustomer.Controls.Add(lblPhoneHeading);
            gbCustomer.Controls.Add(txtEmail);
            gbCustomer.Controls.Add(lblEmailHeading);
            gbCustomer.Controls.Add(txtName);
            gbCustomer.Controls.Add(lblNameHeading);
            gbCustomer.Location = new Point(12, 12);
            gbCustomer.Name = "gbCustomer";
            gbCustomer.Size = new Size(704, 276);
            gbCustomer.TabIndex = 0;
            gbCustomer.TabStop = false;
            gbCustomer.Text = "New Customer";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhoneNumber.Location = new Point(186, 137);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(512, 39);
            txtPhoneNumber.TabIndex = 5;
            // 
            // lblPhoneHeading
            // 
            lblPhoneHeading.AutoSize = true;
            lblPhoneHeading.Location = new Point(6, 137);
            lblPhoneHeading.Name = "lblPhoneHeading";
            lblPhoneHeading.Size = new Size(182, 32);
            lblPhoneHeading.TabIndex = 4;
            lblPhoneHeading.Text = "Phone Number:";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(186, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(512, 39);
            txtEmail.TabIndex = 3;
            // 
            // lblEmailHeading
            // 
            lblEmailHeading.AutoSize = true;
            lblEmailHeading.Location = new Point(6, 92);
            lblEmailHeading.Name = "lblEmailHeading";
            lblEmailHeading.Size = new Size(76, 32);
            lblEmailHeading.TabIndex = 2;
            lblEmailHeading.Text = "Email:";
            lblEmailHeading.Click += lblEmailHeading_Click;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.Location = new Point(186, 47);
            txtName.Name = "txtName";
            txtName.Size = new Size(512, 39);
            txtName.TabIndex = 1;
            // 
            // lblNameHeading
            // 
            lblNameHeading.AutoSize = true;
            lblNameHeading.Location = new Point(6, 47);
            lblNameHeading.Name = "lblNameHeading";
            lblNameHeading.Size = new Size(83, 32);
            lblNameHeading.TabIndex = 0;
            lblNameHeading.Text = "Name:";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(541, 192);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 46);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 265);
            Controls.Add(gbCustomer);
            Name = "NewCustomerForm";
            Text = "New Customer Form";
            gbCustomer.ResumeLayout(false);
            gbCustomer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbCustomer;
        private TextBox txtName;
        private Label lblNameHeading;
        private TextBox txtEmail;
        private Label lblEmailHeading;
        private Button btnSave;
        private TextBox txtPhoneNumber;
        private Label lblPhoneHeading;
        private Button btnClear;
    }
}