using Phm.Billing.Bl;
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
    public partial class VatInvoiceList : Form
    {
        public VatInvoiceList()
        {
            InitializeComponent();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int? invoiceNo = null;
            DateTime? startDate = null;
            DateTime? endDate = null;

            int id;
            DateTime date1;
            DateTime date2;

            if (int.TryParse(txtInvoiceNo.Text.Trim(), out id))
            {
                invoiceNo = id;
            }

            if (DateTime.TryParse(txtStartDate.Text.Trim(), out date1))
            {
                startDate = date1;
            }

            if (DateTime.TryParse(txtEndDate.Text.Trim(), out date2))
            {
                endDate = date2;
            }

            BindInvoiceList(invoiceNo, startDate, endDate);
        }

        private void BindInvoiceList(int? invoiceNo, DateTime? startDate, DateTime? endDate)
        {
            BlInvoice blInvoice = new BlInvoice();
            DataTable dt = blInvoice.GetVatInvoiceList(invoiceNo, startDate, endDate);
            dataGridView1.DataSource = dt;
        }

        private void InvoiceList_Load(object sender, EventArgs e)
        {
            txtStartDate.Text = DateTime.Now.ToShortDateString();
            txtEndDate.Text = DateTime.Now.ToShortDateString();
            BindInvoiceList(null, null, null);
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                EditVatInvoice form = new EditVatInvoice();
                form.InvoiceId = Convert.ToInt32(id);

                form.Show();
                form.MdiParent = this.MdiParent;
                this.Close();
            }
        }
    }
}
