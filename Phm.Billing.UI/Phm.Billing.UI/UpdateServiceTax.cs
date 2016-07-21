using Phm.Billing.Bl;
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
    public partial class UpdateServiceTax : Form
    {
        BlInvoice blInvoice = new BlInvoice();

        public UpdateServiceTax()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateServiceTax_btnSave_Click");
            try
            {
                if (string.IsNullOrEmpty(txtPercent.Text.Trim()))
                {
                    MessageBox.Show("Please enter tax percentage.");
                    return;
                }

                decimal tax = 0;
                if (!decimal.TryParse(txtPercent.Text, out tax))
                {
                    MessageBox.Show("Please enter correct tax percentage.");
                    return;
                }

                if (tax <= 0)
                {
                    MessageBox.Show("Tax percentage should be more than 0.");
                    return;
                }

                var rowsAffected = blInvoice.UpdateServiceTax(tax);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Tax percentage updated successfully.");
                    txtPercent.Text = "";
                }
                else
                {
                    MessageBox.Show("Error occurred in updating tax percentage. Please contact administrator");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits UpdateServiceTax_btnSave_Click");
        }

        private void UpdateServiceTax_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateServiceTax_Load");
            try
            {
                txtPercent.Text = blInvoice.GetServiceTax().ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits UpdateServiceTax_Load");
        }
    }
}
