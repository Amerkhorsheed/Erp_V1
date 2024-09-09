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
    public partial class FrmProduct : DevExpress.XtraEditors.XtraForm
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }
        public ProductDTO dto=new ProductDTO();
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
        }
        ProductBLL bll= new ProductBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Product Name Is Empty");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Please Select A Category");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Price Is Empty");
            else
            {
                ProductDetailDTO product = new ProductDetailDTO();
                product.ProductName = txtProductName.Text;
                product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                product.price=Convert.ToInt32(txtPrice.Text);
                if (bll.Insert(product))
                {
                    MessageBox.Show("Product Was Added");
                    txtPrice.Clear();
                    txtProductName.Clear();
                    cmbCategory.SelectedIndex = -1;
                }
            }
        }
    }
}