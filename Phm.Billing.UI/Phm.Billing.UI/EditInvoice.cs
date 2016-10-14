using Phm.Billing.Bl;
using Phm.Billing.Cdo;
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
    public partial class EditInvoice : Form
    {
        public int InvoiceId { get; set; }
        DataTable tempItems = new DataTable();
        BlInvoice blInvoice = new BlInvoice();
        decimal total = 0;
        decimal tax = 0;
        decimal krishiCess = 0;
        decimal swachBharatCess = 0;
        decimal taxableAmount = 0;
        decimal serviceTax = 0;
        List<string> itemsToDelete = new List<string>();

        public EditInvoice()
        {
            InitializeComponent();
        }

        private void EditInvoice_Load(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditInvoice_Load");
            try
            {
                BindCmbCustomer();
                tempItems.Columns.Add(new DataColumn("Description"));
                tempItems.Columns.Add(new DataColumn("Qty"));
                tempItems.Columns.Add(new DataColumn("Price"));
                tempItems.Columns.Add(new DataColumn("Discount"));
                tempItems.Columns.Add(new DataColumn("Amount"));

                dataGridView.DataSource = tempItems;

                CdoInvoice invoiceDetails = blInvoice.GetInvoiceDetails(InvoiceId);
                if (invoiceDetails != null && invoiceDetails.Id > 0)
                {
                    ShowDetails(invoiceDetails);
                }

                lblServiceTax.Text = "Service Tax " + serviceTax + "% :";
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditInvoice_Load");
        }

        private void ShowDetails(CdoInvoice invoiceDetails)
        {
            Logger.LogInfo("Enters EditInvoice_ShowDetails");
            try
            {
                cmbCustomer.SelectedValue = invoiceDetails.CustomerId;
                invoiceDate.Text = invoiceDetails.InvoiceDate.ToString();
                txtOrderNo.Text = invoiceDetails.OrderNo;
                orderDate.Text = invoiceDetails.OrderDate.ToString();
                txtJobRgpNo.Text = invoiceDetails.JobRgpNo;
                txtInvoiceNo.Text = invoiceDetails.InvoiceNo;
                checkBox1.Checked = invoiceDetails.ReduceTax;
                total = invoiceDetails.Total;
                taxableAmount = invoiceDetails.TaxableAmount;
                txtFreight.Text = invoiceDetails.Freight.ToString();
                serviceTax = invoiceDetails.ReduceTax ? invoiceDetails.ReducedServiceTaxPerc : invoiceDetails.ServiceTaxPerc;
                CalculateTotals();

                foreach (var item in invoiceDetails.InvoiceItems)
                {
                    var row = tempItems.NewRow();
                    row["Description"] = item.Description;
                    row["Qty"] = item.Qty;
                    row["Price"] = item.Price;
                    row["Discount"] = item.Discount;
                    row["Amount"] = item.Amount;
                    tempItems.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditInvoice_ShowDetails");
        }

        private void BindCmbCustomer()
        {
            BlCustomer blCustomer = new BlCustomer();
            var dataset = blCustomer.GetCustomer();
            cmbCustomer.DataSource = dataset.Tables[0];
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditInvoice_btnAdd_Click");
            try
            {
                decimal qty = 0;
                decimal rate = 0;
                decimal vat = 0;
                decimal discount = 0;
                if (!decimal.TryParse(txtQty.Text, out qty))
                {
                    MessageBox.Show("Please enter correct quantity.");
                    return;
                }

                if (qty <= 0)
                {
                    MessageBox.Show("Quantity should be more than 0.");
                    return;
                }

                if (!decimal.TryParse(txtRate.Text, out rate))
                {
                    MessageBox.Show("Please enter correct price.");
                    return;
                }

                if (rate <= 0)
                {
                    MessageBox.Show("Price should be more than 0.");
                    return;
                }

                if (!decimal.TryParse(txtDiscount.Text, out discount))
                {
                    MessageBox.Show("Please enter correct discount.");
                    return;
                }

                if (discount < 0)
                {
                    MessageBox.Show("Discount should be greater or equal to 0.");
                    return;
                }

                if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                {
                    MessageBox.Show("Please enter item description.");
                    return;
                }

                if (tempItems.Select("Description = '" + txtDescription.Text + "'").Length <= 0)
                {
                    var row = tempItems.NewRow();
                    var amount = qty * rate;
                    row["Description"] = txtDescription.Text;
                    row["Qty"] = txtQty.Text.Trim();
                    row["Price"] = txtRate.Text.Trim();
                    row["Discount"] = txtDiscount.Text.Trim();
                    var net = amount - discount;
                    row["Amount"] = net;
                    total += net;
                    tempItems.Rows.Add(row);
                    CalculateTotals();

                    txtDescription.Text = "";
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtDiscount.Text = "0.00";
                }
                else
                {
                    MessageBox.Show("This item is already added.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditInvoice_btnAdd_Click");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditInvoice_btnDelete_Click");
            try
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    DataRow gridRow = (dataGridView.SelectedRows[0].DataBoundItem as DataRowView).Row;
                    var description = Convert.ToString(gridRow["Description"]);
                    itemsToDelete.Add(description);

                    total -= Convert.ToDecimal(gridRow["Amount"]);
                    CalculateTotals();
                    gridRow.Delete();
                }
                else
                {
                    MessageBox.Show("Select item to delete.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditInvoice_btnDelete_Click");
        }

        private void CalculateTotals()
        {
            taxableAmount = checkBox1.Checked ? total * 70 / 100 : total;
            txtTaxableAmount.Text = taxableAmount.ToString();
            tax = (taxableAmount * serviceTax) / 100;
            krishiCess = (taxableAmount * (decimal)0.5) / 100;
            swachBharatCess = (taxableAmount * (decimal)0.5) / 100;
            txtServiceTax.Text = tax.ToString("#0.00");
            txtSwachBharatCess.Text = swachBharatCess.ToString("#0.00");
            txtKrishiCess.Text = krishiCess.ToString("#0.00");
            txtTotalAmount.Text = Math.Round(total + tax + swachBharatCess + krishiCess + GetFreight(), 0).ToString("#0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Logger.LogInfo("Enters EditInvoice_btnSave_Click");
            try
            {
                if (total <= 0)
                {
                    MessageBox.Show("Please add items.");
                    return;
                }

                CdoInvoice cdoInvoice = new CdoInvoice()
                {
                    Id = InvoiceId,
                    InvoiceNo = txtInvoiceNo.Text,
                    CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue),
                    InvoiceDate = invoiceDate.Value,
                    OrderNo = txtOrderNo.Text.Trim(),
                    OrderDate = orderDate.Value,
                    JobRgpNo = txtJobRgpNo.Text.Trim(),
                    TaxableAmount = taxableAmount,
                    ServiceTaxPerc = Constants.ServiceTax,
                    ServiceTaxAmount = tax,
                    Freight = GetFreight(),
                    NetAmount = Math.Round(total + tax + swachBharatCess + krishiCess + GetFreight(), 0),
                    ReduceTax = checkBox1.Checked,
                    ReducedServiceTaxPerc = serviceTax,
                    KrishiKalyanCess = krishiCess,
                    SwachBharatCess = swachBharatCess,
                    Total = total,
                };

                BlInvoice blInvoice = new BlInvoice();
                var invoiceId = blInvoice.UpdateInvoice(cdoInvoice);

                if (invoiceId > 0)
                {

                    if (itemsToDelete.Count > 0)
                    {
                        foreach (var description in itemsToDelete)
                        {
                            blInvoice.DeleteInvoiceItem(InvoiceId, description);
                        }
                    }
                    itemsToDelete.Clear();

                    foreach (DataRow item in tempItems.Rows)
                    {
                        CdoInvoiceItems cdoInvoiceItems = new CdoInvoiceItems()
                        {
                            InvoiceId = InvoiceId,
                            Description = Convert.ToString(item["Description"]),
                            Qty = Convert.ToDecimal(item["Qty"]),
                            Price = Convert.ToDecimal(item["Price"]),
                            Discount = Convert.ToDecimal(item["Discount"]),
                            Amount = Convert.ToDecimal(item["Amount"]),
                        };
                        cdoInvoice.InvoiceItems.Add(cdoInvoiceItems);
                        var invoiceItemId = blInvoice.UpdateInvoiceItems(cdoInvoiceItems);
                    }

                    MessageBox.Show("Invoice saved successfully.");

                    InvoicePreview invoice = new InvoicePreview();
                    invoice.InvoiceId = InvoiceId;

                    invoice.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error occurred in saving Invoice");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                MessageBox.Show("Critical Error occurred. Please contact administrator");
            }
            Logger.LogInfo("Exits EditInvoice_btnSave_Click");
        }

        private decimal GetFreight()
        {
            decimal frieght = 0;
            decimal.TryParse(txtFreight.Text.Trim(), out frieght);
            return frieght;
        }

        private void txtFreight_TextChanged(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                serviceTax = Constants.ServiceTax / 2;
            }
            else
            {
                serviceTax = Constants.ServiceTax;
            }

            lblServiceTax.Text = "Service Tax " + serviceTax + "% :";
            CalculateTotals();
        }
    }
}
