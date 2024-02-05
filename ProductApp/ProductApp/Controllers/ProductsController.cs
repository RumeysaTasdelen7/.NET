using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetActionResult()
        {
            var products = new List<Product>()
            {
                new Product() {Id=1, ProductName="Computer"},
                new Product() {Id=2, ProductName="Keyboard"},
                new Product() {Id=3, ProductName="Mouse"},
            };
            _logger.LogInformation("GetAllProduct action has been called.");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Products has been created.");
            return StatusCode(201);
        }

    }
}