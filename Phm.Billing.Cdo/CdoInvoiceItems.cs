using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phm.Billing.Cdo
{
    public class CdoInvoiceItems
    {
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
    }
}
