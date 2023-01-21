using ACME.BL.Models;
using ACME.BL.Services;

namespace ACME.WEB.ControllerServices
{
    public class ProductControllerService
    {
        public decimal CalculateMargin(string priceInput, string costInput)
        {
            var priceSuccess = decimal.TryParse(priceInput, out decimal price);
            if (!priceSuccess) throw new ArgumentException("The value must be a number");

            var costSuccess = decimal.TryParse(costInput, out decimal cost);
            if (costSuccess) throw new ArgumentException("The value must be a number");

            if (price < 0 || cost < 0) throw new ArgumentException("Value must be equal or greater than zero.");

            var product = new Product(price, cost);
            return ProductService.calculateMargin(product);
        }
    }
}
