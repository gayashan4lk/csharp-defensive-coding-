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
            decimal margin = (product.Price - product.Cost) / product.Price * 100M;
            return margin;
        }
    }
}
