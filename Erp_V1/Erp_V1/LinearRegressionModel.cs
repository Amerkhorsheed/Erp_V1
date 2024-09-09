using Erp_V1.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Erp_V1.BLL
{
    public class LinearRegressionModel
    {
        private List<ProductDetailDTO> trainingData;

        public void Train(List<ProductDetailDTO> products)
        {
            trainingData = products;
        }

        public int Predict(ProductDetailDTO product)
        {
            // Calculate the average stock amount of the product
            int averageStockAmount = (int)trainingData.Where(p => p.ProductID == product.ProductID).Average(p => p.stockAmount);

            // Calculate the predicted stock amount using linear regression
            int predictedStockAmount = (int)(averageStockAmount + (product.price * 0.1));

            return predictedStockAmount;
        }
    }
}