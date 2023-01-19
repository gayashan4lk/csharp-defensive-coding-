using ACME.BL.Models;
using ACME.BL.Services;
using ACME.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACME.WEB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(ProductViewModel productVm)
        {
            var priceInput = productVm.Price;
            var costInput = productVm.Cost;

            var priceSuccess = decimal.TryParse(priceInput, out decimal price);
            var costSuccess = decimal.TryParse(costInput, out decimal cost);

            if (!priceSuccess && !costSuccess)
            {
                var product = new Product(price, cost);
                var calculatedMargine = ProductService.calculateMargin(product);

                ViewBag.CalculatedMargin = calculatedMargine;
                ViewBag.IsAcceptable = calculatedMargine >= 40;
            }

            return View();
        }
    }
}
