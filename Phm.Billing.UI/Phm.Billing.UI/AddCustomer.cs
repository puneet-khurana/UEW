using Phm.Billing.Bl;
using Phm.Billing.Cdo;
using Phm.Billing.Utility;
using System;
using System.Windows.Forms;

namespace Phm.Billing.UI
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             Logger.LogInfo("Enters AddCustomer_btnSave_Click");
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("Please enter customer name.");
                }
                else
                {
                    BlCustomer blCustomer = new BlCustomer();
                    CdoCustomer cdoCustomer = new CdoCustomer()
                    {
                        Name = txtName.Text.Trim(),
                        Location = txtLocation.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        TinNo = txtTinNo.Text.Trim()
                    };
                    var customerId = blCustomer.AddCustomer(cdoCustomer);

                    if (customerId > 0)
                    {
                        MessageBox.Show("Customer added successfully.");
                        txtName.Text = "";
                        txtLocation.Text = "";
                        txtPhone.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        txtTinNo.Text = "";
                    }
                    else if (customerId == -1)
                    {
                        MessageBox.Show("Customer with same name alreay exists.");
                    }
                    else
                    {
                        MessageBox.Show("Error occurred in adding Customer. Please contact administrator");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits AddCustomer_btnSave_Click");
        }
    }
}
