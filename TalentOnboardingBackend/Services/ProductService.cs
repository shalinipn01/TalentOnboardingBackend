using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly TalentDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(TalentDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;           
        }
        //get all products
        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            
            return _mapper.Map<List<ProductViewModel>>(products);
        }

        //get product by id
        public async Task<ProductViewModel> GetProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(prod =>
                prod.Id == id);

            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return _mapper.Map<ProductViewModel>(product);
        }

        //create product
        public async Task<ProductViewModel> CreateProduct(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductViewModel>(product);
        }

        //edit product
        public async Task<ProductViewModel> UpdateProduct(EditProductRequest productRequest)
        {
            var product = await _context.Products.FirstOrDefaultAsync(prod =>
                prod.Id == productRequest.Id);
            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            product.Name = productRequest.Name;
            product.Price = productRequest.Price;

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    throw new Exception("Product Not Found");
                }
                else
                {
                    throw;
                }
            }
            return _mapper.Map<ProductViewModel>(product);
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(prod => prod.Id == id))
                .GetValueOrDefault();
        }

        //delete product
        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(prod =>
            prod.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
        }
    }
}
