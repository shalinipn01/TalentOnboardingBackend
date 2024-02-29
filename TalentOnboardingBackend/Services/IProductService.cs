using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts();

        Task<ProductViewModel> GetProduct(int id);

        Task<ProductViewModel> CreateProduct(ProductRequest request);

        Task<ProductViewModel> UpdateProduct(EditProductRequest request);

        Task DeleteProduct(int id);
    }
}
