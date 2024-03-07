using Microsoft.AspNetCore.Mvc;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.Services;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IStoreService _storeService;
        private readonly TalentDbContext _context;

        public StoreController(ILogger<StoreController> logger, IStoreService storeService, TalentDbContext context)
        {
            _logger = logger;
            _storeService = storeService;
            _context = context;
        }

        //GET
        [HttpGet("/GetStores")]
        [ProducesResponseType(typeof(IEnumerable<StoreViewModel>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> StoresIndex()
        {
            var stores = await _storeService.GetAllStores();
            return Ok(stores);
        }

        //GET
        [HttpGet("/GetStoreDetails")]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> StoreDetails(int? id)
        {
            if (id == null || _context.Stores == null)
            {
                return NotFound();
            }
            var store = await _storeService.GetStore(id.Value);
            return Ok(store);
        }

        //POST create store
        [HttpPost("/CreateStore")]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateStore([FromBody] StoreRequest storeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var store = await _storeService.CreateStore(storeRequest);
            return Ok(store);
        }

        //PUT edit store
        [HttpPut("/EditStore")]
        [ProducesResponseType(typeof(StoreViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> EditStore(int id, [FromBody] EditStoreRequest storeRequest)
        {
            if (!ModelState.IsValid || storeRequest == null)
            {
                return BadRequest();
            }
            if (_context.Stores == null)
            {
                return NotFound();
            }
            var store = await _storeService.UpdateStore(storeRequest);
            return Ok(store);
        }

        //DELETE store
        [HttpDelete("/DeleteStore")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStore(int id)
        {
            if (_context.Stores == null)
            {
                throw new Exception("No Stores present !");
            }
            await _storeService.DeleteStore(id);
            return Ok("Store deleted successfully !");
        }
    }
}
