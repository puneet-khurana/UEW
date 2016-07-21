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
    public partial class VatInvoicePreview : Form
    {
        public int InvoiceId { get; set; }

        public VatInvoicePreview()
        {
            InitializeComponent();
        }

        private void VatInvoicePreview_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                int InvId;
                InvId = InvoiceId;
                dt = new Bl.BlInvoice().PrintVatInvoice(InvId);

                VatInvoiceReport rpt = new VatInvoiceReport();
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
