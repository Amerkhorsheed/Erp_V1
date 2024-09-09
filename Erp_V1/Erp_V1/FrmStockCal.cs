using DevExpress.XtraEditors;
using Erp_V1.BLL;
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
    public partial class FrmStockCal : DevExpress.XtraEditors.XtraForm
    {
        public FrmStockCal()
        {
            InitializeComponent();
        }
        private void btnGetBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();

        private void FrmStockCal_Load(object sender, EventArgs e)
        {
            // Load the data when the form loads
            dto = bll.Select();

            // Populate the DataGridView with all products initially
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Get the stock level threshold from the user input
            int stockLevel;
            if (int.TryParse(txtStockLevel.Text, out stockLevel))
            {
                // Filter the products based on the user's input
                var filteredProducts = dto.Products.Where(x => x.stockAmount <= stockLevel).ToList();

                // Update the DataGridView with the filtered products
                dataGridView1.DataSource = filteredProducts;
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the stock level.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}