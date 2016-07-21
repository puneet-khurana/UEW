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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer newMDIChild = new AddCustomer();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomer newMDIChild = new EditCustomer();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void addInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInvoice newMDIChild = new AddInvoice();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters Main_Load");
            try
            {
                var blInvoice = new Bl.BlInvoice();
                Constants.ServiceTax = blInvoice.GetServiceTax();
                Constants.Vat = blInvoice.GetVat();
                Constants.Cst = blInvoice.GetCst();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits Main_Load");
        }

        private void serviceTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateServiceTax newMDIChild = new UpdateServiceTax();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void printInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintInvoice newMDIChild = new PrintInvoice();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void editInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceList newMDIChild = new InvoiceList();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void duePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutstandingPayment newMDIChild = new OutstandingPayment();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void addVatInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddVatInvoice newMDIChild = new AddVatInvoice();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void editVatInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VatInvoiceList newMDIChild = new VatInvoiceList();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void vatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVat newMDIChild = new UpdateVat();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void printVatInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintVatInvoice newMDIChild = new PrintVatInvoice();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void vatDuePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VatOutstandingPayment newMDIChild = new VatOutstandingPayment();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void cstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCst newMDIChild = new UpdateCst();
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
