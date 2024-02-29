using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public class SalesService : ISalesService
    {
        private readonly TalentDbContext _context;
        private readonly IMapper _mapper;

        public SalesService(TalentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //get all sales
        public async Task<IEnumerable<SalesViewModel>> GetAllSales()
        {
            var sales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Include(s => s.Store)
                .ToListAsync();

            return _mapper.Map<List<SalesViewModel>>(sales);
        }

        //get sales by id
        public async Task<SalesViewModel> GetSales(int id)
        {
            var sales = await _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Include(s => s.Store).FirstOrDefaultAsync(sale =>
                sale.Id == id);

            if (sales == null)
            {
                throw new Exception("Sales not found");
            }
            return _mapper.Map<SalesViewModel>(sales);
        }

        //create sales
        public async Task<SalesViewModel> CreateSales(SalesRequest request)
        {
            var sales = new Sale
            {
                ProductId = request.ProductId,
                CustomerId = request.CustomerId,
                StoreId = request.StoreId,
                DateSold = request.DateSold
            };

            _context.Sales.Add(sales);
            await _context.SaveChangesAsync();
            return _mapper.Map<SalesViewModel>(sales);
        }

        //edit sales
        public async Task<SalesViewModel> UpdateSales(EditSalesRequest salesRequest)
        {
            var sales = await _context.Sales.FirstOrDefaultAsync(sale =>
                sale.Id == salesRequest.Id);
            if (sales == null)
            {
                throw new Exception("Sales Not Found");
            }
            //converting string date from request to datetime
            var parsedDateSold=new DateTime();
            try { 
                parsedDateSold = DateTime.Parse(salesRequest.DateSold); }
            catch (FormatException ex)
            {
                throw new Exception(ex.Message);
            }
            
            sales.ProductId = salesRequest.ProductId;
            sales.CustomerId = salesRequest.CustomerId;
            sales.StoreId = salesRequest.StoreId;
            sales.DateSold = parsedDateSold;

            try
            {
                _context.Update(sales);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesExists(sales.Id))
                {
                    throw new Exception("Sales Not Found");
                }
                else
                {
                    throw;
                }
            }
            return _mapper.Map<SalesViewModel>(sales);
        }

        private bool SalesExists(int id)
        {
            return (_context.Sales?.Any(sales => sales.Id == id))
                .GetValueOrDefault();
        }

        public async Task DeleteSales(int id)
        {
            var sales = await _context.Sales.FirstOrDefaultAsync(sale =>
            sale.Id == id);
            if (sales != null)
            {
                _context.Sales.Remove(sales);
            }
            await _context.SaveChangesAsync();
        }
    }
}
