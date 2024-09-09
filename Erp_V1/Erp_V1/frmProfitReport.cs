using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using Erp_V1.BLL;
using Erp_V1.DAL.DTO;

namespace Erp_V1
{
    public partial class frmProfitReport : DevExpress.XtraEditors.XtraForm
    {
        private ProductBLL productBLL = new ProductBLL();
        private SalesBLL salesBLL = new SalesBLL();
        private Dictionary<string, decimal> monthlyProfits = new Dictionary<string, decimal>();

        public frmProfitReport()
        {
            InitializeComponent();
        }

        private void frmProfitReport_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void LoadProductData()
        {
            var products = productBLL.Select().Products;
            cboProductNames.DataSource = products;
            cboProductNames.DisplayMember = "ProductName";
            cboProductNames.ValueMember = "ProductID";
        }

        private void btnLoadSales_Click(object sender, EventArgs e)
        {
            if (cboProductNames.SelectedItem != null)
            {
                var selectedProduct = (ProductDetailDTO)cboProductNames.SelectedItem;
                LoadSalesData(selectedProduct.ProductID);
            }
        }

        private void LoadSalesData(int productId)
        {
            try
            {
                var salesData = salesBLL.Select().Sales.Where(s => s.ProductID == productId).ToList();
                var originalPrice = productBLL.Select().Products.First(p => p.ProductID == productId).price;

                dgvSalesDetails.DataSource = salesData.Select(s => new
                {
                    s.SalesID,
                    s.CustomerName,
                    s.ProductName,
                    s.CategoryName,
                    s.SalesAmount,
                    OriginalPrice = originalPrice,
                    s.Price,
                    Profit = s.Price - originalPrice,
                    s.SalesDate
                }).ToList();

                CalculateTotalProfit(salesData, originalPrice);
                UpdateProfitChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading sales data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalProfit(List<SalesDetailDTO> salesData, decimal originalPrice)
        {
            decimal totalProfit = 0;
            foreach (var sale in salesData)
            {
                decimal profit = sale.Price - originalPrice;
                totalProfit += profit;

                // Record monthly profit
                string monthYear = sale.SalesDate.ToString("MMMM yyyy");
                if (monthlyProfits.ContainsKey(monthYear))
                {
                    monthlyProfits[monthYear] += profit;
                }
                else
                {
                    monthlyProfits[monthYear] = profit;
                }
            }

            txtTotalProfit.Text = totalProfit.ToString("C");
        }

        private void UpdateProfitChart()
        {
            chartControl1.Series["ProfitSeries"].Points.Clear();
            foreach (var entry in monthlyProfits)
            {
                chartControl1.Series["ProfitSeries"].Points.Add(new SeriesPoint(entry.Key, entry.Value));
            }
        }
    }
}
