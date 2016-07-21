namespace Phm.Billing.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duePaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vatInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVatInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editVatInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printVatInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vatDuePaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripMenuItem,
            this.invoiceToolStripMenuItem,
            this.serviceTaxToolStripMenuItem,
            this.duePaymentsToolStripMenuItem,
            this.vatInvoiceToolStripMenuItem,
            this.vatToolStripMenuItem,
            this.cstToolStripMenuItem,
            this.vatDuePaymentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.editCustomerToolStripMenuItem});
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersToolStripMenuItem.Text = "&Customers";
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addCustomerToolStripMenuItem.Text = "Add";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // editCustomerToolStripMenuItem
            // 
            this.editCustomerToolStripMenuItem.Name = "editCustomerToolStripMenuItem";
            this.editCustomerToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.editCustomerToolStripMenuItem.Text = "Edit";
            this.editCustomerToolStripMenuItem.Click += new System.EventHandler(this.editCustomerToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addInvoiceToolStripMenuItem,
            this.editInvoiceToolStripMenuItem,
            this.printInvoiceToolStripMenuItem});
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.invoiceToolStripMenuItem.Text = "&Invoice";
            // 
            // addInvoiceToolStripMenuItem
            // 
            this.addInvoiceToolStripMenuItem.Name = "addInvoiceToolStripMenuItem";
            this.addInvoiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addInvoiceToolStripMenuItem.Text = "Create New";
            this.addInvoiceToolStripMenuItem.Click += new System.EventHandler(this.addInvoiceToolStripMenuItem_Click);
            // 
            // editInvoiceToolStripMenuItem
            // 
            this.editInvoiceToolStripMenuItem.Name = "editInvoiceToolStripMenuItem";
            this.editInvoiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.editInvoiceToolStripMenuItem.Text = "Edit";
            this.editInvoiceToolStripMenuItem.Click += new System.EventHandler(this.editInvoiceToolStripMenuItem_Click);
            // 
            // printInvoiceToolStripMenuItem
            // 
            this.printInvoiceToolStripMenuItem.Name = "printInvoiceToolStripMenuItem";
            this.printInvoiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.printInvoiceToolStripMenuItem.Text = "Print";
            this.printInvoiceToolStripMenuItem.Click += new System.EventHandler(this.printInvoiceToolStripMenuItem_Click);
            // 
            // serviceTaxToolStripMenuItem
            // 
            this.serviceTaxToolStripMenuItem.Name = "serviceTaxToolStripMenuItem";
            this.serviceTaxToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.serviceTaxToolStripMenuItem.Text = "Service Tax";
            this.serviceTaxToolStripMenuItem.Click += new System.EventHandler(this.serviceTaxToolStripMenuItem_Click);
            // 
            // duePaymentsToolStripMenuItem
            // 
            this.duePaymentsToolStripMenuItem.Name = "duePaymentsToolStripMenuItem";
            this.duePaymentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.duePaymentsToolStripMenuItem.Text = "Due Payments";
            this.duePaymentsToolStripMenuItem.Click += new System.EventHandler(this.duePaymentsToolStripMenuItem_Click);
            // 
            // vatInvoiceToolStripMenuItem
            // 
            this.vatInvoiceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVatInvoiceToolStripMenuItem,
            this.editVatInvoiceToolStripMenuItem,
            this.printVatInvoiceToolStripMenuItem});
            this.vatInvoiceToolStripMenuItem.Name = "vatInvoiceToolStripMenuItem";
            this.vatInvoiceToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.vatInvoiceToolStripMenuItem.Text = "Vat Invoice";
            this.vatInvoiceToolStripMenuItem.Visible = false;
            // 
            // addVatInvoiceToolStripMenuItem
            // 
            this.addVatInvoiceToolStripMenuItem.Name = "addVatInvoiceToolStripMenuItem";
            this.addVatInvoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addVatInvoiceToolStripMenuItem.Text = "Create New";
            this.addVatInvoiceToolStripMenuItem.Click += new System.EventHandler(this.addVatInvoiceToolStripMenuItem_Click);
            // 
            // editVatInvoiceToolStripMenuItem
            // 
            this.editVatInvoiceToolStripMenuItem.Name = "editVatInvoiceToolStripMenuItem";
            this.editVatInvoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editVatInvoiceToolStripMenuItem.Text = "Edit";
            this.editVatInvoiceToolStripMenuItem.Click += new System.EventHandler(this.editVatInvoiceToolStripMenuItem_Click);
            // 
            // printVatInvoiceToolStripMenuItem
            // 
            this.printVatInvoiceToolStripMenuItem.Name = "printVatInvoiceToolStripMenuItem";
            this.printVatInvoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printVatInvoiceToolStripMenuItem.Text = "Print";
            this.printVatInvoiceToolStripMenuItem.Click += new System.EventHandler(this.printVatInvoiceToolStripMenuItem_Click);
            // 
            // vatToolStripMenuItem
            // 
            this.vatToolStripMenuItem.Name = "vatToolStripMenuItem";
            this.vatToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.vatToolStripMenuItem.Text = "Vat";
            this.vatToolStripMenuItem.Visible = false;
            this.vatToolStripMenuItem.Click += new System.EventHandler(this.vatToolStripMenuItem_Click);
            // 
            // cstToolStripMenuItem
            // 
            this.cstToolStripMenuItem.Name = "cstToolStripMenuItem";
            this.cstToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.cstToolStripMenuItem.Text = "Cst";
            this.cstToolStripMenuItem.Visible = false;
            this.cstToolStripMenuItem.Click += new System.EventHandler(this.cstToolStripMenuItem_Click);
            // 
            // vatDuePaymentsToolStripMenuItem
            // 
            this.vatDuePaymentsToolStripMenuItem.Name = "vatDuePaymentsToolStripMenuItem";
            this.vatDuePaymentsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.vatDuePaymentsToolStripMenuItem.Text = "Vat Due Payments";
            this.vatDuePaymentsToolStripMenuItem.Visible = false;
            this.vatDuePaymentsToolStripMenuItem.Click += new System.EventHandler(this.vatDuePaymentsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 261);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "United Engineering Works";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duePaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vatInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVatInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editVatInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printVatInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vatDuePaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cstToolStripMenuItem;
    }
}

