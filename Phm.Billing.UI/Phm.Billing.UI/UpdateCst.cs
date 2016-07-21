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
    public partial class UpdateCst : Form
    {
        BlInvoice blInvoice = new BlInvoice();

        public UpdateCst()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateCst_btnSave_Click");
            try
            {
                if (string.IsNullOrEmpty(txtVat.Text.Trim()))
                {
                    MessageBox.Show("Please enter Cst.");
                    return;
                }

                decimal tax = 0;
                if (!decimal.TryParse(txtVat.Text, out tax))
                {
                    MessageBox.Show("Please enter correct cst.");
                    return;
                }

                if (tax <= 0)
                {
                    MessageBox.Show("Cst should be more than 0.");
                    return;
                }

                var rowsAffected = blInvoice.UpdateCst(tax);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cst updated successfully.");
                    txtVat.Text = "";
                }
                else
                {
                    MessageBox.Show("Error occurred in updating vat. Please contact administrator");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits UpdateCst_btnSave_Click");
        }

        private void UpdateCst_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateCst_Load_Load");
            try
            {
                txtVat.Text = blInvoice.GetCst().ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits UpdateCst_Load_Load");
        }
    }
}
