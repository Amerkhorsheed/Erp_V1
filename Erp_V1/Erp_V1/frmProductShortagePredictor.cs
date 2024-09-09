using Erp_V1.BLL;
using Erp_V1.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Erp_V1
{
    public partial class frmProductShortagePredictor : Form
    {
        private readonly ProductBLL _productBLL;
        private readonly LinearRegressionModel _linearRegressionModel;

        public frmProductShortagePredictor()
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
            _linearRegressionModel = new LinearRegressionModel();
        }

        private void LoadProductList()
        {
            try
            {
                List<ProductDetailDTO> products = _productBLL.Select().Products;
                _linearRegressionModel.Train(products);

                foreach (ProductDetailDTO product in products)
                {
                    int predictedStockAmount = _linearRegressionModel.Predict(product);
                    product.stockAmount = predictedStockAmount;
                }

                dgvProductList.DataSource = products;

                // Check if the product list is being loaded correctly
                if (products.Count == 0)
                {
                    MessageBox.Show("No products found.");
                }
                else
                {
                    MessageBox.Show($"Loaded {products.Count} products.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product list: {ex.Message}");
            }
        }
    }
}