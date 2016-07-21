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
    public partial class UpdateVat : Form
    {
        BlInvoice blInvoice = new BlInvoice();

        public UpdateVat()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateVat_btnSave_Click");
            try
            {
                if (string.IsNullOrEmpty(txtVat.Text.Trim()))
                {
                    MessageBox.Show("Please enter vat.");
                    return;
                }

                decimal tax = 0;
                if (!decimal.TryParse(txtVat.Text, out tax))
                {
                    MessageBox.Show("Please enter correct vat.");
                    return;
                }

                if (tax <= 0)
                {
                    MessageBox.Show("Vat should be more than 0.");
                    return;
                }

                var rowsAffected = blInvoice.UpdateVat(tax);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Vat updated successfully.");
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
            Logger.LogInfo("Exits UpdateVat_btnSave_Click");
        }

        private void UpdateVat_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters UpdateVat_Load_Load");
            try
            {
                txtVat.Text = blInvoice.GetVat().ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits UpdateVat_Load_Load");
        }
    }
}
