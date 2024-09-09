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

namespace Erp_V1
{
    public partial class test1 : Form
    {
        private ProductBLL _productBLL;
        private CustomerBLL _customerBLL;
        private List<ProductDetailDTO> products;
        private List<CustomerDetailDTO> customers;

        public test1()
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
            _customerBLL = new CustomerBLL();
            LoadData();
        }

        private void LoadData()
        {
            // Fetch products and customers using BLL
            var productDTO = _productBLL.Select();
            products = productDTO.Products;

            var customerDTO = _customerBLL.Select();
            customers = customerDTO.Customers;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Get user input
            string customerName = txtCustomerName.Text;
            string preferences = txtPreferences.Text.ToLower();

            // Find the customer by name
            var customer = customers.FirstOrDefault(c => c.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                MessageBox.Show("Customer not found!");
                return;
            }

            // Generate product recommendations based on preferences
            List<ProductDetailDTO> recommendedProducts = GenerateRecommendations(preferences);

            // Display recommendations
            lstRecommendations.Items.Clear();
            lstRecommendations.Items.Add($"Recommendations for {customer.CustomerName}:");
            foreach (var product in recommendedProducts)
            {
                lstRecommendations.Items.Add($"{product.ProductName} (Category: {product.CategoryName}, Price: ${product.price}, Stock: {product.stockAmount})");
            }
        }

        private List<ProductDetailDTO> GenerateRecommendations(string preferences)
        {
            // Matching logic (simple AI)
            List<ProductDetailDTO> recommendations = products
                .Where(p => p.CategoryName.ToLower().Contains(preferences) || p.ProductName.ToLower().Contains(preferences))
                .ToList();

            // Default recommendation if no match found
            if (recommendations.Count == 0)
            {
                lstRecommendations.Items.Add("No specific recommendations based on your input, but check out our popular items!");
            }

            return recommendations;
        }
    }
}
