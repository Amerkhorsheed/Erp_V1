﻿using DevExpress.XtraEditors;
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
    public partial class FrmAddStock : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddStock()
        {
            InitializeComponent();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FrmAddStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

            if(dto.Categories.Count>0)
                combofull = true;
        }

        bool combofull = false;
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list=list.Where(x=>x.CategoryID==Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource=list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }
            }
        }

        ProductDetailDTO detail = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtProductName.Text = detail.ProductName;
            detail.price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.price.ToString();
            detail.stockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Please Select A Product From Table");
            else if (txtStock.Text.Trim() == "")
                MessageBox.Show("Please Give A Stock Amount");
            else
            {
                int sumstock = detail.stockAmount;
                sumstock += Convert.ToInt32(txtStock.Text);
                detail.stockAmount = sumstock;
                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock Was Added");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Products;
                    txtStock.Clear();
                }
            }
        }
    }
}