using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ToyStore.Models;
using ToyStore.Data;
using Microsoft.EntityFrameworkCore;
using ToyStore.Services;

namespace ToyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerServices services;

        public CustomerController(DataContext context)
        {
            services = new CustomerServices(context); 
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(services.Get().Result.Value);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {

            return Ok(services.Get(id).Result.Value);

        }

        [HttpGet("{id}/toys")]
        public async Task<ActionResult<List<AbstractToy>>> Toys(int id)
        {

            return Ok(services.Toys(id).Result.Value);

        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                services?.AddCustomer(customer);
                return NoContent();

                
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {

            return Ok(services.UpdateCustomer(customer).Result.Value);

        }

        [HttpDelete]

        public async Task<ActionResult> DeleteCustomer(int id)
        {

            return Ok(services.DeleteCustomer(id).Result.Value);
        }
    }
}
