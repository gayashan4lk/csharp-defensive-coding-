using ACME.BL.Models;
using ACME.BL.Services;
using ACME.WEB.ControllerServices;
using ACME.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACME.WEB.Controllers
{
    public class ProductController : Controller
    {
        ProductControllerService service;
        public ProductController()
        {
            service = new ProductControllerService();
        }
        // GET action: Product
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(ProductViewModel productVm)
        {
            try
            {
                var calculatedMargine = service.CalculateMargin(productVm.Price, productVm.Cost);
                ViewBag.CalculatedMargin = calculatedMargine;
                ViewBag.IsAcceptable = calculatedMargine >= 40;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

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
