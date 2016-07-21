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
    public partial class PrintInvoice : Form
    {
        public int InvoiceId { get; set; }

        public PrintInvoice()
        {
            InitializeComponent();
        }

        private void InvoiceList_Load(object sender, EventArgs e)
        {
            if (InvoiceId > 0)
            {
                txtInvoiceNo.Text = InvoiceId.ToString();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int saleId = 0;
            if (int.TryParse(txtInvoiceNo.Text, out saleId))
            {
                InvoicePreview f = new InvoicePreview();
                f.InvoiceId = saleId;
                f.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter correct invoice number.");
            }
        }
    }
}
