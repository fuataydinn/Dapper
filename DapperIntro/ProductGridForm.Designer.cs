
namespace DapperIntro
{
    partial class ProductGridForm
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
            this.grdProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantityPerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitsOnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscontinued = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // grdProducts
            // 
            this.grdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colQuantityPerUnit,
            this.colUnitPrice,
            this.colUnitsInStock,
            this.colUnitsOnOrder,
            this.colReorderLevel,
            this.colDiscontinued});
            this.grdProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProducts.Location = new System.Drawing.Point(0, 0);
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RowHeadersWidth = 51;
            this.grdProducts.RowTemplate.Height = 29;
            this.grdProducts.Size = new System.Drawing.Size(800, 450);
            this.grdProducts.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "ProductId";
            this.colId.HeaderText = "Id";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 125;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "ProductName";
            this.colName.HeaderText = "Ürün Adı";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 125;
            // 
            // colQuantityPerUnit
            // 
            this.colQuantityPerUnit.DataPropertyName = "QuantityPerUnit";
            this.colQuantityPerUnit.HeaderText = "Paket içeriği";
            this.colQuantityPerUnit.MinimumWidth = 6;
            this.colQuantityPerUnit.Name = "colQuantityPerUnit";
            this.colQuantityPerUnit.ReadOnly = true;
            this.colQuantityPerUnit.Width = 125;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Birim Fiyatı";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 125;
            // 
            // colUnitsInStock
            // 
            this.colUnitsInStock.DataPropertyName = "UnitsInStock";
            this.colUnitsInStock.HeaderText = "Stok";
            this.colUnitsInStock.MinimumWidth = 6;
            this.colUnitsInStock.Name = "colUnitsInStock";
            this.colUnitsInStock.ReadOnly = true;
            this.colUnitsInStock.Width = 125;
            // 
            // colUnitsOnOrder
            // 
            this.colUnitsOnOrder.DataPropertyName = "UnitsOnOrder";
            this.colUnitsOnOrder.HeaderText = "Sipariş edilen miktar";
            this.colUnitsOnOrder.MinimumWidth = 6;
            this.colUnitsOnOrder.Name = "colUnitsOnOrder";
            this.colUnitsOnOrder.ReadOnly = true;
            this.colUnitsOnOrder.Width = 125;
            // 
            // colReorderLevel
            // 
            this.colReorderLevel.DataPropertyName = "ReorderLevel";
            this.colReorderLevel.HeaderText = "Kritik stok miktarı";
            this.colReorderLevel.MinimumWidth = 6;
            this.colReorderLevel.Name = "colReorderLevel";
            this.colReorderLevel.ReadOnly = true;
            this.colReorderLevel.Width = 125;
            // 
            // colDiscontinued
            // 
            this.colDiscontinued.DataPropertyName = "Discontinued";
            this.colDiscontinued.HeaderText = "Pasif mi?";
            this.colDiscontinued.MinimumWidth = 6;
            this.colDiscontinued.Name = "colDiscontinued";
            this.colDiscontinued.ReadOnly = true;
            this.colDiscontinued.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDiscontinued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDiscontinued.Width = 125;
            // 
            // ProductGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdProducts);
            this.Name = "ProductGridForm";
            this.Text = "ProductGridForm";
            this.Load += new System.EventHandler(this.ProductGridForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityPerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitsInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitsOnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorderLevel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDiscontinued;
    }
}