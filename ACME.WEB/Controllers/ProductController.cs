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
            var p = new Product(150, 80);
            var myProductVm = new ProductViewModel()
            {
                Id = p.ProductId,
                Price = p.Price.ToString(),
                Cost = p.Cost.ToString(),
            };
            return View(myProductVm);
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

        public IActionResult PriceUpdate()
        {
            var productVm = new ProductViewModel();
            productVm.Price = 399.ToString();
            productVm.Cost = 250.ToString();
            productVm.CreatedDate = DateTime.Now;

            ViewBag.IsAcceptable = false;

            return View(productVm);
        }

        public IActionResult ProductInfo()
        {
            var productVm = new ProductViewModel();
            productVm.Price = 399.ToString();
            productVm.Cost = 250.ToString();
            productVm.CreatedDate = DateTime.Now;
            productVm.Name = "Test Product";
            productVm.Category = "Test Category";

            return View(productVm);
        }
    }
}
