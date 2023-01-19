using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.BL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product(decimal price, decimal cost)
        {
            ProductId = ++this.ProductId;
            Price = price;
            Cost = cost;
            CreatedDate = DateTime.Now;
        }
    }
}
