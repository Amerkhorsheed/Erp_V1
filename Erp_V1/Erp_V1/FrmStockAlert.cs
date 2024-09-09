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

namespace Erp_V1
{
    public partial class FrmStockAlert : DevExpress.XtraEditors.XtraForm
    {
        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ProductBLL bll= new ProductBLL();
        ProductDTO dto= new ProductDTO();
        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products= dto.Products.Where(x => x.stockAmount <=10).ToList();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }
    }
}