using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Erp_V1.DAL.DTO;
using Erp_V1.BLL;

namespace Erp_V1
{
    public partial class FrmSales : DevExpress.XtraEditors.XtraForm
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        private void txtProductSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Assuming General.isNumber is a method that checks if the input is a valid number
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public SalesBLL bll = new SalesBLL();
        public SalesDTO dto = new SalesDTO();
        bool combofull = false;

        private void FrmSales_Load(object sender, EventArgs e)
        {
            // Load data when the form is loaded
            dto = bll.Select();

            // Populate the category ComboBox
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1; // No selection initially

            // Populate the product grid
            gridProduct.DataSource = dto.Products;
            gridProduct.Columns[0].HeaderText = "Product Name";
            gridProduct.Columns[1].HeaderText = "Category Name";
            gridProduct.Columns[2].HeaderText = "Stock Amount";
            gridProduct.Columns[3].HeaderText = "Price";
            gridProduct.Columns[4].Visible = false; // Assuming these are not needed
            gridProduct.Columns[5].Visible = false;

            // Populate the customer grid
            gridCustomer.DataSource = dto.Customers;
            gridCustomer.Columns[0].Visible = false; // Assuming the ID or key is hidden
            gridCustomer.Columns[1].HeaderText = "Customer Name";

            // Now allow ComboBox events to be handled
            combofull = dto.Categories.Count > 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only handle the event if the ComboBox is fully populated and a valid item is selected
            if (combofull && cmbCategory.SelectedIndex != -1 && cmbCategory.SelectedValue != null)
            {
                if (int.TryParse(cmbCategory.SelectedValue.ToString(), out int selectedCategoryId))
                {
                    // Filter products based on the selected CategoryID
                    List<ProductDetailDTO> list = dto.Products;
                    list = list.Where(x => x.CategoryID == selectedCategoryId).ToList();

                    // Update the DataGridView with the filtered list
                    gridProduct.DataSource = list;
                    if (list.Count == 0)
                    {
                        txtPrice.Clear();
                        txtProductName.Clear();
                        txtStock.Clear();
                    }
                }
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            // Filter customers based on the search text
            List<CustomerDetailDTO> list = dto.Customers;
            if (!string.IsNullOrEmpty(txtCustomerSearch.Text))
            {
                list = list.Where(x => x.CustomerName.Contains(txtCustomerSearch.Text)).ToList();
            }

            // Update the DataGridView with the filtered list
            gridCustomer.DataSource = list;
            if (list.Count == 0)
                txtCustomerName.Clear();
        }
        SalesDetailDTO detail = new SalesDetailDTO();
        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            txtStock.Text = detail.StockAmount.ToString();

        }

        private void gridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerName = gridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.CustomerID = Convert.ToInt32(gridCustomer.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.CustomerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please Select A Product From Product Table");
            else if (detail.CustomerID == 0)
                MessageBox.Show("Please Select A Customer From Customer Table");
            else if (detail.StockAmount < Convert.ToInt32(txtProductSalesAmount.Text))
                MessageBox.Show("You Have Bot Engough Product For Sale");
            else
            {
             detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                detail.SalesDate = DateTime.Today;
                if (bll.Insert(detail))
                {
                    MessageBox.Show("Sales Was Added");
                    bll = new SalesBLL();
                    dto = bll.Select();
                    gridProduct.DataSource = dto.Products;
                    dto.Customers = dto.Customers;
                    combofull = false;
                    cmbCategory.DataSource =dto.Categories;
                    if(dto.Products.Count > 0) 
                        combofull=true;
                    txtProductSalesAmount.Clear();
                }
            }
        }
    }
}
