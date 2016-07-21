using Phm.Billing.Cdo;
using Phm.Billing.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phm.Billing.Bl
{
    public class BlInvoice
    {
        public int InsertInvoice(CdoInvoice cdoInvoice)
        {
            Logger.LogInfo("Enters BlInvoice_InsertInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@CustomerId", cdoInvoice.CustomerId),
                new SqlParameter("@InvoiceNo", cdoInvoice.InvoiceNo),
                new SqlParameter("@InvoiceDate", cdoInvoice.InvoiceDate),
                new SqlParameter("@OrderNo", cdoInvoice.OrderNo),
                new SqlParameter("@OrderDate", cdoInvoice.OrderDate),
                new SqlParameter("@JobRgpNo", cdoInvoice.JobRgpNo),
                new SqlParameter("@TaxableAmount", cdoInvoice.TaxableAmount),
                new SqlParameter("@ServiceTaxPerc", cdoInvoice.ServiceTaxPerc),
                new SqlParameter("@ServiceTaxAmount", cdoInvoice.ServiceTaxAmount),
                new SqlParameter("@Freight", cdoInvoice.Freight),
                new SqlParameter("@Total", cdoInvoice.Total),
                new SqlParameter("@ReduceTax", cdoInvoice.ReduceTax),
                new SqlParameter("@ReducedServiceTaxPerc", cdoInvoice.ReducedServiceTaxPerc),
                new SqlParameter("@NetAmount", cdoInvoice.NetAmount)
            };

            var invoiceId = BlUtil.ExecuteScalar("usp_InsertInvoice", parameters);
            Logger.LogInfo("Exits BlInvoice_InsertInvoice");
            return invoiceId;
        }

        public int InsertInvoiceItem(CdoInvoiceItems cdoInvoiceItems)
        {
            Logger.LogInfo("Enters BlInovice_InsertInvoiceItems");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", cdoInvoiceItems.InvoiceId),
                new SqlParameter("@Description", cdoInvoiceItems.Description),
                new SqlParameter("@Qty", cdoInvoiceItems.Qty),
                new SqlParameter("@Price", cdoInvoiceItems.Price),
                new SqlParameter("@Discount", cdoInvoiceItems.Discount),
                new SqlParameter("@Amount", cdoInvoiceItems.Amount),
            };
            var invoiceItemId = BlUtil.ExecuteScalar("usp_InsertInvoiceItems", parameters);
            Logger.LogInfo("Exits BlInovice_InsertInvoiceItems");
            return invoiceItemId;
        }

        public CdoInvoice GetInvoiceDetails(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_GetInvoiceDetails");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", invoiceId)
            };
            var ds = BlUtil.ExecuteDataset("usp_GetInvoiceDetails", parameters);
            CdoInvoice cdoInvoice = new CdoInvoice();
            if (ds.Tables.Count == 2)
            {
                cdoInvoice.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                cdoInvoice.InvoiceNo = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]);
                cdoInvoice.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerId"]);
                cdoInvoice.InvoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InvoiceDate"]);
                cdoInvoice.OrderNo = Convert.ToString(ds.Tables[0].Rows[0]["OrderNo"]);
                cdoInvoice.OrderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"]);
                cdoInvoice.JobRgpNo = Convert.ToString(ds.Tables[0].Rows[0]["JobRgpNo"]);
                cdoInvoice.TaxableAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxableAmount"]);
                cdoInvoice.ServiceTaxPerc = Convert.ToDecimal(ds.Tables[0].Rows[0]["ServiceTaxPerc"]);
                cdoInvoice.ServiceTaxAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["ServiceTaxAmount"]);
                cdoInvoice.Freight = Convert.ToDecimal(ds.Tables[0].Rows[0]["Freight"]);
                cdoInvoice.Total = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]);
                cdoInvoice.ReduceTax = Convert.ToBoolean(ds.Tables[0].Rows[0]["ReduceTax"]);
                cdoInvoice.ReducedServiceTaxPerc = Convert.ToDecimal(ds.Tables[0].Rows[0]["ReducedServiceTaxPerc"]);
                cdoInvoice.NetAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"]);

                List<CdoInvoiceItems> invoiceItems = new List<CdoInvoiceItems>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    invoiceItems.Add(new CdoInvoiceItems()
                    {
                        Description = Convert.ToString(dr["Description"]),
                        InvoiceId = Convert.ToInt32(dr["InvoiceId"]),
                        Qty = Convert.ToDecimal(dr["Qty"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Discount = Convert.ToDecimal(dr["Discount"]),
                        Amount = Convert.ToDecimal(dr["Amount"]),
                    });
                }

                cdoInvoice.InvoiceItems = invoiceItems;
            }
            Logger.LogInfo("Exits BlInovice_GetInvoiceDetails");
            return cdoInvoice;
        }

        public int UpdateInvoice(CdoInvoice cdoInvoice)
        {
            Logger.LogInfo("Enters BlInovice_UpdateInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", cdoInvoice.Id),
                new SqlParameter("@InvoiceNo", cdoInvoice.InvoiceNo),
                new SqlParameter("@CustomerId", cdoInvoice.CustomerId),
                new SqlParameter("@InvoiceDate", cdoInvoice.InvoiceDate),
                new SqlParameter("@OrderNo", cdoInvoice.OrderNo),
                new SqlParameter("@OrderDate", cdoInvoice.OrderDate),
                new SqlParameter("@JobRgpNo", cdoInvoice.JobRgpNo),
                new SqlParameter("@TaxableAmount", cdoInvoice.TaxableAmount),
                new SqlParameter("@ServiceTaxPerc", cdoInvoice.ServiceTaxPerc),
                new SqlParameter("@ServiceTaxAmount", cdoInvoice.ServiceTaxAmount),
                new SqlParameter("@Freight", cdoInvoice.Freight),
                new SqlParameter("@Total", cdoInvoice.Total),
                new SqlParameter("@ReduceTax", cdoInvoice.ReduceTax),
                new SqlParameter("@ReducedServiceTaxPerc", cdoInvoice.ReducedServiceTaxPerc),
                new SqlParameter("@NetAmount", cdoInvoice.NetAmount)
            };

            var invoiceId = BlUtil.ExecuteNonQuery("usp_UpdateInvoice", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateInvoice");
            return invoiceId;
        }

        public int UpdateInvoiceItems(CdoInvoiceItems cdoInvoiceItems)
        {
            Logger.LogInfo("Enters BlInovice_UpdateInvoiceItems");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", cdoInvoiceItems.InvoiceId),
                new SqlParameter("@Description", cdoInvoiceItems.Description),
                new SqlParameter("@Qty", cdoInvoiceItems.Qty),
                new SqlParameter("@Price", cdoInvoiceItems.Price),
                new SqlParameter("@Discount", cdoInvoiceItems.Discount),
                new SqlParameter("@Amount", cdoInvoiceItems.Amount),
            };
            var invoiceItemId = BlUtil.ExecuteNonQuery("usp_UpdateInvoiceItems", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateInvoiceItems");
            return invoiceItemId;
        }

        public DataTable GetInvoiceList(int? id, DateTime? startDate, DateTime? endDate)
        {
            Logger.LogInfo("Enters BlInovice_GetInvoiceList");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", id),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
            };
            DataSet ds = BlUtil.ExecuteDataset("usp_GetInvoiceList", parameters);
            Logger.LogInfo("Exits BlInovice_GetInvoiceList");
            return ds.Tables[0];
        }

        public DataTable PrintInvoice(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_PrintInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId)
            };
            var ds = BlUtil.ExecuteDataset("usp_PrintInvoice", parameters);
            Logger.LogInfo("Exits BlInovice_PrintInvoice");
            return ds.Tables[0];
        }

        public decimal GetServiceTax()
        {
            Logger.LogInfo("Enters BlInovice_GetServiceTax");
            SqlParameter[] parameters = new SqlParameter[]{};
            var ds = BlUtil.ExecuteDataset("usp_GetServiceTax", parameters);
            var tax = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            Logger.LogInfo("Exits BlInovice_GetServiceTax");
            return tax;
        }

        public int UpdateServiceTax(decimal taxPercentage)
        {
            Logger.LogInfo("Enters BlInovice_UpdateServiceTax");
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@TaxPercentage", taxPercentage)
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_UpdateServiceTax", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateServiceTax");
            return rowsAffected;
        }

        public int DeleteInvoiceItem(int invoiceId, string description)
        {
            Logger.LogInfo("Enters BlInovice_DeleteInvoiceItem");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId),
                new SqlParameter("@Description", description),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_DeleteInvoiceItem", parameters);
            Logger.LogInfo("Exits BlInovice_DeleteInvoiceItem");
            return rowsAffected;
        }

        public DataTable GetOutstandingPayments()
        {
            Logger.LogInfo("Enters BlInovice_GetOutstandingPayments");
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = BlUtil.ExecuteDataset("usp_GetOutstandingPayments", parameters);
            Logger.LogInfo("Exits BlInovice_GetOutstandingPayments");
            return ds.Tables[0];
        }

        public void UpdatePaymentStatus(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_UpdatePaymentStatus");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_UpdatePaymentStatus", parameters);
            Logger.LogInfo("Exits BlInovice_UpdatePaymentStatus");
        }

        public decimal GetVat()
        {
            Logger.LogInfo("Enters BlInovice_GetVat");
            SqlParameter[] parameters = new SqlParameter[] { };
            var ds = BlUtil.ExecuteDataset("usp_GetVat", parameters);
            var tax = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            Logger.LogInfo("Exits BlInovice_GetVat");
            return tax;
        }

        public int InsertVatInvoice(CdoInvoice cdoInvoice)
        {
            Logger.LogInfo("Enters BlInvoice_InsertVatInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@CustomerId", cdoInvoice.CustomerId),
                new SqlParameter("@InvoiceNo", cdoInvoice.InvoiceNo),
                new SqlParameter("@InvoiceDate", cdoInvoice.InvoiceDate),
                new SqlParameter("@OrderNo", cdoInvoice.OrderNo),
                new SqlParameter("@OrderDate", cdoInvoice.OrderDate),
                new SqlParameter("@Amendment", cdoInvoice.Amendment),
                new SqlParameter("@TaxableAmount", cdoInvoice.TaxableAmount),
                new SqlParameter("@VatPerc", cdoInvoice.VatPerc),
                new SqlParameter("@VatAmount", cdoInvoice.VatAmount),
                new SqlParameter("@Freight", cdoInvoice.Freight),
                new SqlParameter("@Total", cdoInvoice.Total),
                new SqlParameter("@NetAmount", cdoInvoice.NetAmount),
                new SqlParameter("@VatBill", cdoInvoice.VatBill)
            };

            var invoiceId = BlUtil.ExecuteScalar("usp_InsertVatInvoice", parameters);
            Logger.LogInfo("Exits BlInvoice_InsertVatInvoice");
            return invoiceId;
        }

        public int InsertVatInvoiceItem(CdoInvoiceItems cdoInvoiceItems)
        {
            Logger.LogInfo("Enters BlInovice_InsertVatInvoiceItems");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", cdoInvoiceItems.InvoiceId),
                new SqlParameter("@Description", cdoInvoiceItems.Description),
                new SqlParameter("@Qty", cdoInvoiceItems.Qty),
                new SqlParameter("@Price", cdoInvoiceItems.Price),
                new SqlParameter("@Discount", cdoInvoiceItems.Discount),
                new SqlParameter("@Amount", cdoInvoiceItems.Amount),
            };
            var invoiceItemId = BlUtil.ExecuteScalar("usp_InsertVatInvoiceItems", parameters);
            Logger.LogInfo("Exits BlInovice_InsertVatInvoiceItem");
            return invoiceItemId;
        }

        public CdoInvoice GetVatInvoiceDetails(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_GetVatInvoiceDetails");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", invoiceId)
            };
            var ds = BlUtil.ExecuteDataset("usp_GetVatInvoiceDetails", parameters);
            CdoInvoice cdoInvoice = new CdoInvoice();
            if (ds.Tables.Count == 2)
            {
                cdoInvoice.Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                cdoInvoice.InvoiceNo = Convert.ToString(ds.Tables[0].Rows[0]["InvoiceNo"]);
                cdoInvoice.CustomerId = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerId"]);
                cdoInvoice.InvoiceDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InvoiceDate"]);
                cdoInvoice.OrderNo = Convert.ToString(ds.Tables[0].Rows[0]["OrderNo"]);
                cdoInvoice.OrderDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["OrderDate"]);
                cdoInvoice.Amendment = Convert.ToString(ds.Tables[0].Rows[0]["Amendment"]);
                cdoInvoice.TaxableAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["TaxableAmount"]);
                cdoInvoice.VatPerc = Convert.ToDecimal(ds.Tables[0].Rows[0]["VatPerc"]);
                cdoInvoice.VatAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["VatAmount"]);
                cdoInvoice.Freight = Convert.ToDecimal(ds.Tables[0].Rows[0]["Freight"]);
                cdoInvoice.Total = Convert.ToDecimal(ds.Tables[0].Rows[0]["Total"]);
                cdoInvoice.NetAmount = Convert.ToDecimal(ds.Tables[0].Rows[0]["NetAmount"]);
                cdoInvoice.VatBill = Convert.ToBoolean(ds.Tables[0].Rows[0]["VatBill"]);

                List<CdoInvoiceItems> invoiceItems = new List<CdoInvoiceItems>();
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    invoiceItems.Add(new CdoInvoiceItems()
                    {
                        Description = Convert.ToString(dr["Description"]),
                        InvoiceId = Convert.ToInt32(dr["InvoiceId"]),
                        Qty = Convert.ToDecimal(dr["Qty"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Discount = Convert.ToDecimal(dr["Discount"]),
                        Amount = Convert.ToDecimal(dr["Amount"]),
                    });
                }

                cdoInvoice.InvoiceItems = invoiceItems;
            }
            Logger.LogInfo("Exits BlInovice_GetVatInvoiceDetails");
            return cdoInvoice;
        }

        public int UpdateVatInvoice(CdoInvoice cdoInvoice)
        {
            Logger.LogInfo("Enters BlInovice_UpdateVatInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", cdoInvoice.Id),
                new SqlParameter("@InvoiceNo", cdoInvoice.InvoiceNo),
                new SqlParameter("@CustomerId", cdoInvoice.CustomerId),
                new SqlParameter("@InvoiceDate", cdoInvoice.InvoiceDate),
                new SqlParameter("@OrderNo", cdoInvoice.OrderNo),
                new SqlParameter("@OrderDate", cdoInvoice.OrderDate),
                new SqlParameter("@Amendment", cdoInvoice.Amendment),
                new SqlParameter("@TaxableAmount", cdoInvoice.TaxableAmount),
                new SqlParameter("@VatPerc", cdoInvoice.VatPerc),
                new SqlParameter("@VatAmount", cdoInvoice.VatAmount),
                new SqlParameter("@Freight", cdoInvoice.Freight),
                new SqlParameter("@Total", cdoInvoice.Total),
                new SqlParameter("@NetAmount", cdoInvoice.NetAmount),
                new SqlParameter("@VatBill", cdoInvoice.VatBill)
            };

            var invoiceId = BlUtil.ExecuteNonQuery("usp_UpdateVatInvoice", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateVatInvoice");
            return invoiceId;
        }

        public int UpdateVatInvoiceItems(CdoInvoiceItems cdoInvoiceItems)
        {
            Logger.LogInfo("Enters BlInovice_UpdateVatInvoiceItems");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", cdoInvoiceItems.InvoiceId),
                new SqlParameter("@Description", cdoInvoiceItems.Description),
                new SqlParameter("@Qty", cdoInvoiceItems.Qty),
                new SqlParameter("@Price", cdoInvoiceItems.Price),
                new SqlParameter("@Discount", cdoInvoiceItems.Discount),
                new SqlParameter("@Amount", cdoInvoiceItems.Amount),
            };
            var invoiceItemId = BlUtil.ExecuteNonQuery("usp_UpdateVatInvoiceItems", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateVatInvoiceItems");
            return invoiceItemId;
        }

        public int DeleteVatInvoiceItem(int invoiceId, string description)
        {
            Logger.LogInfo("Enters BlInovice_DeleteVatInvoiceItem");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId),
                new SqlParameter("@Description", description),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_DeleteVatInvoiceItem", parameters);
            Logger.LogInfo("Exits BlInovice_DeleteVatInvoiceItem");
            return rowsAffected;
        }

        public DataTable GetVatInvoiceList(int? id, DateTime? startDate, DateTime? endDate)
        {
            Logger.LogInfo("Enters BlInovice_GetVatInvoiceList");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", id),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
            };
            DataSet ds = BlUtil.ExecuteDataset("usp_GetVatInvoiceList", parameters);
            Logger.LogInfo("Exits BlInovice_GetVatInvoiceList");
            return ds.Tables[0];
        }

        public int UpdateVat(decimal vat)
        {
            Logger.LogInfo("Enters BlInovice_UpdateVat");
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@VatPercentage", vat)
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_UpdateVat", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateVat");
            return rowsAffected;
        }

        public DataTable PrintVatInvoice(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_PrintVatInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId)
            };
            var ds = BlUtil.ExecuteDataset("usp_PrintVatInvoice", parameters);
            Logger.LogInfo("Exits BlInovice_PrintVatInvoice");
            return ds.Tables[0];
        }

        public DataTable GetVatOutstandingPayments()
        {
            Logger.LogInfo("Enters BlInovice_GetVatOutstandingPayments");
            SqlParameter[] parameters = new SqlParameter[] { };
            DataSet ds = BlUtil.ExecuteDataset("usp_GetOutstandingVatPayments", parameters);
            Logger.LogInfo("Exits BlInovice_GetVatOutstandingPayments");
            return ds.Tables[0];
        }

        public void UpdateVatPaymentStatus(int invoiceId)
        {
            Logger.LogInfo("Enters BlInovice_UpdateVatPaymentStatus");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@InvoiceId", invoiceId),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_UpdateVatPaymentStatus", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateVatPaymentStatus");
        }

        public decimal GetCst()
        {
            Logger.LogInfo("Enters BlInovice_GetCst");
            SqlParameter[] parameters = new SqlParameter[] { };
            var ds = BlUtil.ExecuteDataset("usp_GetCst", parameters);
            var tax = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            Logger.LogInfo("Exits BlInovice_GetCst");
            return tax;
        }

        public int UpdateCst(decimal taxPercentage)
        {
            Logger.LogInfo("Enters BlInovice_UpdateCst");
            SqlParameter[] parameters = new SqlParameter[] 
            {
                new SqlParameter("@CstPercentage", taxPercentage)
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_UpdateCst", parameters);
            Logger.LogInfo("Exits BlInovice_UpdateCst");
            return rowsAffected;
        }

        public int DeleteInvoice(int id)
        {
            Logger.LogInfo("Enters BlInovice_DeleteInvoice");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Id", id),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_DeleteInvoice", parameters);
            Logger.LogInfo("Exits BlInovice_DeleteInvoice");
            return rowsAffected;
        }
    }
}
