using Microsoft.AspNetCore.Mvc;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.Services;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly TalentDbContext _context;

        public ProductController(ILogger<ProductController> logger, IProductService productService, TalentDbContext context)
        {
            this._logger = logger;
            this._productService = productService;
            this._context = context;
        }

        //GET
        [HttpGet("/GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> ProductsIndex()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        //GET
        [HttpGet("/GetProductDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Product))]
        public async Task<IActionResult> ProductDetails(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProduct(id.Value);
            return Ok(product);
        }

        //POST create product
        [HttpPost("/CreateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(Product))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = await _productService.CreateProduct(productRequest);
            return Ok(product);
        }

        //PUT edit product
        [HttpPut("/EditProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Product))]
        public async Task<IActionResult> EditProduct(int id, [FromBody] EditProductRequest productRequest)
        {
            if (!ModelState.IsValid || productRequest == null)
            {
                return BadRequest();
            }
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _productService.UpdateProduct(productRequest);
            return Ok(product);
        }

        //DELETE product
        [HttpDelete("/DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Product))]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                throw new Exception("No Products found");
            }
            await _productService.DeleteProduct(id);
            return Ok("Product deleted successfully !");
        }
    }
}
