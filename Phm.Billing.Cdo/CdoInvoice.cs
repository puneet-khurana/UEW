using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phm.Billing.Cdo
{
    public class CdoInvoice
    {
        private List<CdoInvoiceItems> invoiceItems;

        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string JobRgpNo { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal ServiceTaxPerc { get; set; }
        public decimal Freight { get; set; }
        public decimal ServiceTaxAmount { get; set; }
        public decimal Total { get; set; }
        public bool ReduceTax { get; set; }
        public decimal ReducedServiceTaxPerc { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatPerc { get; set; }
        public decimal VatAmount { get; set; }
        public string Amendment { get; set; }
        public bool VatBill { get; set; }

        public List<CdoInvoiceItems> InvoiceItems
        {
            get
            {
                if (invoiceItems == null)
                {
                    invoiceItems = new List<CdoInvoiceItems>();
                }
                return invoiceItems;
            }
            set
            {
                invoiceItems = value;
            }
        }
    }
}
