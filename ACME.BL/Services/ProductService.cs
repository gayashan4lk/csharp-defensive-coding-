using ACME.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.BL.Services
{
    public class ProductService
    {
        public static decimal calculateMargin(Product product)
        {
            if(product.Price == 0) throw new DivideByZeroException("Price cannot be zero.");

            if (product.Cost < 1) return 100M;

            var margin = (product.Price - product.Cost) / product.Price * 100M;
            return Math.Round(margin, 1);
        }
    }
}
