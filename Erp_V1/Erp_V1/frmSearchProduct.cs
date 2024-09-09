using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Erp_V1.BLL;
using Erp_V1.DAL.DTO;
using System.Windows.Controls;

namespace Erp_V1
{
    public partial class frmSearchProduct : DevExpress.XtraEditors.XtraForm
    {
        private ProductBLL productBLL;

        public frmSearchProduct()
        {
            InitializeComponent();
            productBLL = new ProductBLL();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.ToLower();
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                MessageBox.Show("Please enter a search keyword.");
                return;
            }

            // Fetch all products
            ProductDTO productDTO = productBLL.Select();
            List<ProductDetailDTO> products = productDTO.Products;

            // Filter products based on search keyword
            var filteredProducts = products
                .Where(p => p.ProductName.ToLower().Contains(searchKeyword) || p.CategoryName.ToLower().Contains(searchKeyword))
                .ToList();

            // Display results
            lstSearchResults.Items.Clear();
            foreach (var product in filteredProducts)
            {
                lstSearchResults.Items.Add(product.ProductName);
            }
        }

        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string selectedProductName = lstSearchResults.SelectedItem.ToString();

                // Fetch all products to get details
                ProductDTO productDTO = productBLL.Select();
                List<ProductDetailDTO> products = productDTO.Products;

                // Find selected product
                ProductDetailDTO selectedProduct = products
                    .FirstOrDefault(p => p.ProductName == selectedProductName);

                if (selectedProduct != null)
                {
                    // Display product details
                    lblProductNameValue.Text = selectedProduct.ProductName;
                    lblCategoryNameValue.Text = selectedProduct.CategoryName;
                    lblPriceValue.Text = selectedProduct.price.ToString("C");
                    lblStockAmountValue.Text = selectedProduct.stockAmount.ToString();
                }
                else
                {
                    MessageBox.Show("Product details not found.");
                }
            }
        }
    }
}