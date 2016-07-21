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
    public partial class InvoicePreview : Form
    {
        public int InvoiceId { get; set; }

        public InvoicePreview()
        {
            InitializeComponent();
        }

        private void InvoicePreview_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int InvId;
                InvId = InvoiceId;
                dt = new Bl.BlInvoice().PrintInvoice(InvId);

                InvoiceReport rpt = new InvoiceReport();
                rpt.SetDataSource(dt);

                crystalReportViewer.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
        }
    }
}
