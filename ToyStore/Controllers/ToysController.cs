using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore.Command;
using ToyStore.Command.ToyCommand;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries.ToyQueries;
using ToyStore.Services;

namespace ToyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToysController : Controller
    {
        
        private readonly IMediator mediator;

        public ToysController(IMediator mediator)
        {
            
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AbstractToy>>> Get()
        {
            var response = await mediator.Send(new GetToysQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbstractToy>> Get(int id)
        {
            var response = await mediator.Send(new GetToyByIdQuery(id));
            return Ok(response);

        }

        [HttpGet("{id}/play")]
        public async Task<ActionResult<string>> Play(int id)
        {

            var response = await mediator.Send(new PlayWithToyCommand(id));
            return Ok(response);



        }

        [HttpPost]
        public async Task<ActionResult<List<AbstractToy>>> Add(BearToy toy)
        {
            if (ModelState.IsValid)
            {
                AddToyCommand command = new AddToyCommand();
                command.Name = toy.Name;
                command.CustomerID = toy.CustomerID;
                command.DateCreated = toy.DateCreated;
                command.Type = toy.Type;
                await mediator.Send(command);
                return NoContent();
            }

            return BadRequest("invalid state");
            

        }

        [HttpPut]
        public async Task<ActionResult<AbstractToy>> Update(BearToy toy)
        {
            UpdateToyCommand command = new UpdateToyCommand(toy.Id);
            command.Name = toy.Name;
            var response = await mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete]
        public async Task<ActionResult<List<AbstractToy>>> Delete(int id)
        {

            var response = await mediator.Send(new DeleteToyCommand(id));
            return Ok(response);

        }

    }
}
