using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly TalentDbContext _context;
        private readonly IMapper _mapper;
        public CustomerService(TalentDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        // get all customers
        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            
            return _mapper.Map<List<CustomerViewModel>>(customers);
        }

        //get customer by id
        public async Task<CustomerViewModel> GetCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.Id == id);

            if (customer == null)
            {
                throw new Exception("Customer Not Found");
            }
            return _mapper.Map<CustomerViewModel>(customer);
        }

        //create customer
        public async Task<CustomerViewModel> CreateCustomer(CustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Address = request.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }

        //edit customer
        public async Task<CustomerViewModel> UpdateCustomer(EditCustomerRequest customerRequest)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cust =>
                cust.Id == customerRequest.Id);
            if (customer == null)
            {
                throw new Exception("Customer Not Found");
            }
            customer.Name = customerRequest.Name;
            customer.Address = customerRequest.Address;

            try
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.Id))
                {
                    throw new Exception("Customer Not Found");
                }
                else
                {
                    throw;
                }
            }
            return _mapper.Map<CustomerViewModel>(customer);

        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(cust => cust.Id == id)).GetValueOrDefault();
        }

        //delete customer
        public async Task DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cust =>
            cust.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
