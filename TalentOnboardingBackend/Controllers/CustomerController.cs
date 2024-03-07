using Microsoft.AspNetCore.Mvc;
using TalentOnboardingBackend.Models;
using TalentOnboardingBackend.Services;
using TalentOnboardingBackend.ViewModels;

namespace TalentOnboardingBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly TalentDbContext _context;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, TalentDbContext context)
        {
            _logger = logger;
            _customerService = customerService;
            _context = context;
        }

        //GET
        [HttpGet("/GetCustomers")]
        [ProducesResponseType(typeof(IEnumerable<CustomerViewModel>), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> CustomersIndex()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        //GET
        [HttpGet("/GetCustomerDetails")]
       [ProducesResponseType(typeof(CustomerViewModel), StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [Produces("application/json")]
       public async Task<IActionResult> CustomerDetails(int? id)
       {
           if (id == null || _context.Customers == null)
           {
               return NotFound();
           }
           var customer = await _customerService.GetCustomer(id.Value);
           return Ok(customer);
       }

       //POST create
       [HttpPost("/CreateCustomer")]
       [ProducesResponseType(typeof(CustomerViewModel), StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       [Produces("application/json")]
       public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequest customerRequest)
       {
           if (!ModelState.IsValid)
           {
               return BadRequest();
           }
           var customer = await _customerService.CreateCustomer(customerRequest);
           return Ok(customer);
       }

       //PUT edit
       [HttpPut("/EditCustomer")]
       [ProducesResponseType(typeof(CustomerViewModel), StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       [Produces("application/json")]
       public async Task<IActionResult> EditCustomer(int id, [FromBody] EditCustomerRequest customerRequest)
       {
           if (!ModelState.IsValid || customerRequest == null)
           {
               return BadRequest();
           }
           if (_context.Customers == null)
           {
               return NotFound();
           }
           var customer = await _customerService.UpdateCustomer(customerRequest);
           return Ok(customer);
       }


       //DELETE customer
       [HttpDelete("/DeleteCustomer")]
       [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       [ProducesResponseType(StatusCodes.Status404NotFound)]
       public async Task<IActionResult> DeleteCustomer(int id)
       {
           if (_context.Customers == null)
           {
               throw new Exception("No Customers present !");
           }
           await _customerService.DeleteCustomer(id);
           return Ok("Customer deleted successfully !");
       }
    }
}
