using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllCustomers();

        Task<CustomerViewModel> GetCustomer(int id);

        Task<CustomerViewModel> CreateCustomer(CustomerRequest request);

        Task<CustomerViewModel> UpdateCustomer(EditCustomerRequest request);

        Task DeleteCustomer(int id);
    }
}
