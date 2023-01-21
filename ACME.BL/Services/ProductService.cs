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
            decimal margin = 0;
            try
            {
                if(product.Cost < 1) return margin = 100M;
                
                margin = (product.Price - product.Cost) / product.Price * 100M;

            } 
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            //return decimal.Round(margin, 2, MidpointRounding.AwayFromZero);
            return Math.Round(margin, 1);

        }
    }
}
