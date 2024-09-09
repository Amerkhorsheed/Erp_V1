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
    public partial class FrmCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        CustomerBLL bll = new CustomerBLL();
        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("Customer Name Is Empty");
            else
            {
                CustomerDetailDTO customer = new CustomerDetailDTO();
                customer.CustomerName = txtCustomerName.Text;
                if (bll.Insert(customer))
                {
                    MessageBox.Show("Customer Was Added");
                    txtCustomerName.Clear();
                }
            }
        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the 'ding' sound when Enter is pressed
                btnSave_Click(sender, e);
            }
        }
    }
}