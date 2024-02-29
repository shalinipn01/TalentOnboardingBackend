using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<StoreViewModel>> GetAllStores();

        Task<StoreViewModel> GetStore(int id);

        Task<StoreViewModel> CreateStore(StoreRequest request);

        Task<StoreViewModel> UpdateStore(EditStoreRequest request);

        Task DeleteStore(int id);
    }
}
