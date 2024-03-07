using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.Services;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly ISalesService _salesService;
        private readonly TalentDbContext _context;

        public SalesController(ILogger<SalesController> logger, ISalesService salesService, TalentDbContext context)
        {
            _logger = logger;
            _salesService = salesService;
            _context = context;
        }

        //GET
        [HttpGet("/GetSales")]
        [ProducesResponseType(typeof(IEnumerable<SalesViewModel>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> SalesIndex()
        {
            var sales = await _salesService.GetAllSales();
            return Ok(sales);
        }

        //GET sales details my id
        [HttpGet("/GetSalesDetails")]
        [ProducesResponseType(typeof(SalesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> SalesDetails(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }
            var sales = await _salesService.GetSales(id.Value);
            return Ok(sales);
        }

        //POST create sales
        [HttpPost("/CreateSales")]
        [ProducesResponseType(typeof(SalesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> CreateSales([FromBody] SalesRequest salesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var sales = await _salesService.CreateSales(salesRequest);
            return Ok(sales);
        }


        //PUT edit sales
        [HttpPut("/EditSales")]
        [ProducesResponseType(typeof(SalesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<IActionResult> EditSales(int id,
            [FromBody] EditSalesRequest salesRequest)
        {
            if (!ModelState.IsValid || salesRequest == null)
            {
                return BadRequest();
            }
            if (_context.Sales == null)
            {
                return NotFound();
            }

            var sales = await _salesService.UpdateSales(salesRequest);
            return Ok(sales);
        }

        //DELETE sales
        [HttpDelete("/DeleteSales")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSales(int id)
        {
            if (_context.Sales == null)
            {
                throw new Exception("No Sales present !");
            }
            await _salesService.DeleteSales(id);
            return Ok("Sales deleted successfully !");
        }   
    }
}
