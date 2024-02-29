using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesViewModel>> GetAllSales();

        Task<SalesViewModel> GetSales(int id);

        Task<SalesViewModel> CreateSales(SalesRequest request);

        Task<SalesViewModel> UpdateSales(EditSalesRequest request);

        Task DeleteSales(int id);
    }
}
