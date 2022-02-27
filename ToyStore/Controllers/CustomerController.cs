using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ToyStore.Models;
using ToyStore.Data;
using Microsoft.EntityFrameworkCore;
using ToyStore.Services;
using MediatR;
using ToyStore.Queries;
using ToyStore.Command;

namespace ToyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator mediator;
        //private readonly CustomerServices services;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
            //this.services = services;
            //return BadRequest();
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            //return Ok(services.Get().Result.Value);
            var response = await mediator.Send(new GetCustomersQuery());
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {

            //return Ok(services.Get(id).Result.Value);

            var response = await mediator.Send(new GetCustomerByIDQuery(id));
            return Ok(response);

        }

        [HttpGet("{id}/toys")]
        public async Task<ActionResult<List<AbstractToy>>> Toys(int id)
        {

            var response = await mediator.Send(new GetCustomerToysQuery(id));
            return response;

        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                AddCustomerCommand command = new AddCustomerCommand();
                command.FirstName = customer.FirstName;
                command.LastName = customer.LastName;
                command.DateOfBirth = customer.DateOfBirth;
                await mediator.Send(command);
                return NoContent();

            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {

            UpdateCustomerCommand command = new UpdateCustomerCommand(customer.Id);
            command.FirstName = customer.FirstName;
            command.LastName = customer.LastName;
            var response = await mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete]

        public async Task<ActionResult> DeleteCustomer(int id)
        {

            var response = await mediator.Send(new DeleteCustomerCommand(id));
            return Ok(response);
        }
    }
}
