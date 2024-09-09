using DevExpress.XtraBars;
using Erp_V1.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp_V1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCategoryList list = new FrmCategoryList();
            list.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAddStock frmAddStock = new FrmAddStock();
            frmAddStock.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmStockAlert frmStockAlert = new FrmStockAlert();
            frmStockAlert.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCustomer customer = new FrmCustomer();
            customer.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCustomerList list = new FrmCustomerList();
            list.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmProduct product = new FrmProduct();
            product.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmProductList list = new FrmProductList();
            list.ShowDialog();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSales frmSales = new FrmSales();
            frmSales.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDeleted frmDeleted = new FrmDeleted();
            frmDeleted.ShowDialog();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSalesList list = new FrmSalesList();
            list.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmStockCal frmStockCal = new FrmStockCal();
            frmStockCal.ShowDialog();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            ChatGpt gpt = new ChatGpt();
            gpt.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            test1 test = new test1();
            test.ShowDialog();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSearchProduct searchProduct = new frmSearchProduct();
            searchProduct.ShowDialog();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMultiSales frmMultiSales = new frmMultiSales();
            frmMultiSales.ShowDialog();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMultiSales frmMultiSales = new frmMultiSales();
            frmMultiSales.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSalesChart frmSalesChart = new frmSalesChart();
            frmSalesChart.ShowDialog();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSalesChart frmSalesChart = new frmSalesChart();
            frmSalesChart.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProfitReport frmProfitReport = new frmProfitReport();
            frmProfitReport.ShowDialog();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductRecommendations frmProductRecommendations = new frmProductRecommendations();
            frmProductRecommendations.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRecommendation frmRecommendation = new frmRecommendation();
            frmRecommendation.ShowDialog();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProductShortagePredictor frmProductShortagePredictor = new frmProductShortagePredictor();
            frmProductShortagePredictor.ShowDialog();
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            RecommendationForm frmRecommendation = new RecommendationForm();
            frmRecommendation.ShowDialog();
        }
    }
}