using Phm.Billing.Bl;
using Phm.Billing.Cdo;
using Phm.Billing.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phm.Billing.UI
{
    public partial class EditCustomer : Form
    {
        BlCustomer blCustomer = new BlCustomer();
        DataSet dataset = new DataSet();

        public EditCustomer()
        {
            InitializeComponent();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditCustomer_Load");
            try
            {
                BindCmbCustomer();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditCustomer_Load");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditCustomer_btnEdit_Click");
            try
            {
                if (!string.IsNullOrEmpty(cmbCustomer.Text))
                {
                    var selectedCustomer = dataset.Tables[0].Select("Id = " + cmbCustomer.SelectedValue).FirstOrDefault();
                    lblId.Text = Convert.ToString(selectedCustomer[0]);
                    txtName.Text = Convert.ToString(selectedCustomer[1]);
                    txtLocation.Text = Convert.ToString(selectedCustomer[2]);
                    txtAddress.Text = Convert.ToString(selectedCustomer[3]);
                    txtPhone.Text = Convert.ToString(selectedCustomer[4]);
                    txtEmail.Text = Convert.ToString(selectedCustomer[5]);
                    txtTinNo.Text = Convert.ToString(selectedCustomer[6]);
                    panel1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No customer selected.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditCustomer_btnEdit_Click");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditCustomer_btnSave_Click");
            try
            {
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    MessageBox.Show("Please enter customer name.");
                    return;
                }

                if (cmbCustomer.SelectedValue != null)
                {
                    var selectedCustomer = new CdoCustomer();
                    selectedCustomer.Id = Convert.ToInt32(lblId.Text);
                    selectedCustomer.Name = txtName.Text.Trim();
                    selectedCustomer.Location = txtLocation.Text.Trim();
                    selectedCustomer.Address = txtAddress.Text.Trim();
                    selectedCustomer.Phone = txtPhone.Text.Trim();
                    selectedCustomer.Email = txtEmail.Text.Trim();
                    selectedCustomer.TinNo = txtTinNo.Text.Trim();
                    blCustomer.UpdateCustomer(selectedCustomer);
                    ClearFields();
                    MessageBox.Show("Customer updated successfully.");
                    BindCmbCustomer();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditCustomer_btnSave_Click");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditCustomer_btnDelete_Click");
            try
            {
                var result = MessageBox.Show("Sure to delete the customer?", "Delete Customer", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (cmbCustomer.SelectedValue != null)
                    {
                        var selectedCustomer = Convert.ToInt32(cmbCustomer.SelectedValue);
                        blCustomer.DeleteCustomer(selectedCustomer);
                        ClearFields();
                        MessageBox.Show("Customer Deleted successfully.");
                        BindCmbCustomer();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditCustomer_btnDelete_Click");
        }

        private void BindCmbCustomer()
        {
            dataset = blCustomer.GetCustomer();
            cmbCustomer.DataSource = dataset.Tables[0];
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "Id";
        }

        private void ClearFields()
        {
            lblId.Text = "";
            txtName.Text = "";
            txtLocation.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtTinNo.Text = "";
        }
    }
}
