using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Services
{
    public class StoreService : IStoreService
    {
        private readonly TalentDbContext _context;
        private readonly IMapper _mapper;

        public StoreService(TalentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // get all stores
        public async Task<IEnumerable<StoreViewModel>> GetAllStores()
        {
            var stores = await _context.Stores.ToListAsync();
            
            return _mapper.Map<List<StoreViewModel>>(stores);
        }

        //get store by id
        public async Task<StoreViewModel> GetStore(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(store =>
                store.Id == id);

            if (store == null)
            {
                throw new Exception("Store not found");
            }
            return _mapper.Map<StoreViewModel>(store);
        }

        //create store
        public async Task<StoreViewModel> CreateStore(StoreRequest request)
        {
            var store = new Store
            {
                Name = request.Name,
                Address = request.Address
            };

            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
            return _mapper.Map<StoreViewModel>(store);
        }

        //edit store
        public async Task<StoreViewModel> UpdateStore(EditStoreRequest storeRequest)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(store =>
                store.Id == storeRequest.Id);
            if (store == null)
            {
                throw new Exception("Store Not Found");
            }
            store.Name = storeRequest.Name;
            store.Address = storeRequest.Address;

            try
            {
                _context.Update(store);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(store.Id))
                {
                    throw new Exception("Store Not Found");
                }
                else
                {
                    throw;
                }
            }
            return _mapper.Map<StoreViewModel>(store);
        }

        private bool StoreExists(int id)
        {
            return (_context.Stores?.Any(store => store.Id == id)).GetValueOrDefault();
        }

        //delete store
        public async Task DeleteStore(int id)
        {
            var store = await _context.Stores.FirstOrDefaultAsync(store =>
            store.Id == id);
            if (store != null)
            {
                _context.Stores.Remove(store);
            }
            await _context.SaveChangesAsync();
        }
    }
}
