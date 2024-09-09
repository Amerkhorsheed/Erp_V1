using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp_V1.DAL.DTO
{
    public class ProductDetailDTO
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int stockAmount { get; set; }
        public int price { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

    }
}
