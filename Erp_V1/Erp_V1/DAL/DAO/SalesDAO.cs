using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp_V1.DAL.DTO;
using Erp_V1.DAL;

namespace Erp_V1.DAL.DAO
{
    public class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join category in db.CATEGORies on s.CategoryID equals category.ID
                            select new
                            {
                                productname = p.ProductName,
                                customername = c.CustomerName,
                                categoryname = category.CategoryName,
                                productID = s.ProductID,
                                customerID = s.CustomerID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesprice = s.ProductSalesPrice,
                                salesamount = s.ProductSalesAmout,
                                salesdate = s.SalesDate
                            }).OrderBy(x => x.salesdate).ToList();

                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO()
                    {
                        ProductName = item.productname,
                        CustomerName = item.customername,
                        CategoryName = item.categoryname,
                        ProductID = item.productID,
                        CustomerID = item.customerID,
                        CategoryID = item.categoryID,
                        SalesID = item.salesID,
                        Price = item.salesprice,
                        SalesAmount = item.salesamount,
                        SalesDate = item.salesdate
                    };

                    sales.Add(dto);
                }

                return sales;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool Update(SALE entity)
        {
            throw new NotImplementedException();
        }
    }
}
