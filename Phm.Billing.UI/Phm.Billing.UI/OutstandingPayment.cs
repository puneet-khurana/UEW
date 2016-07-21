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
    public partial class OutstandingPayment : Form
    {
        BlInvoice blInvoice = new BlInvoice();

        public OutstandingPayment()
        {
            InitializeComponent();
        }

        private void OutstandingPayment_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            DataTable dt = blInvoice.GetOutstandingPayments();
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                blInvoice.UpdatePaymentStatus(Convert.ToInt32(id));
                BindGrid();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var invoiceDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["InvoiceDate"].Value);
                if (invoiceDate.AddDays(21) < DateTime.Today)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }

            dataGridView1.Columns[1].Visible = false;
        }
    }
}
