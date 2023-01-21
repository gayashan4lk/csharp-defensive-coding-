using ACME.BL.Models;
using ACME.BL.Services;
using ACME.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACME.WEB.Controllers
{
    public class ProductController : Controller
    {
        // GET action: Product
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(ProductViewModel productVm)
        {
            var priceInput = productVm.Price;
            var costInput = productVm.Cost;

            var priceSuccess = decimal.TryParse(priceInput, out decimal price);
            if(!priceSuccess) throw new ArgumentException("The value must be a number");
            
            var costSuccess = decimal.TryParse(costInput, out decimal cost);
            if (costSuccess) throw new ArgumentException("The value must be a number");

            if (price < 0 || cost < 0) throw new ArgumentException("Value must be equal or greater than zero.");

            var product = new Product(price, cost);
            var calculatedMargine = ProductService.calculateMargin(product);

            ViewBag.CalculatedMargin = calculatedMargine;
            ViewBag.IsAcceptable = calculatedMargine >= 40;

            return View(nameof(PriceUpdate),productVm);
        }

        // GET action
        // When navigating to the page.
        public IActionResult PriceUpdate()
        {
            // Create a sample product
            var productVm = new ProductViewModel()
            {
                Id = Guid.NewGuid(),
                Price = "399",
                Cost = "199",
                Name = "Bicycle",
                Category = "Transport",
            };
            
            ViewBag.IsAcceptable = false;

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PriceUpdate(ProductViewModel productVm)
        {
            
            return View(nameof(Index));
        }

        // Get Action
        // When navigate to page ProductInfo
        public IActionResult ProductInfo()
        {
            // Create a new product
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
