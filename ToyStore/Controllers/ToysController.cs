using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Services;

namespace ToyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToysController : Controller
    {
        
        private readonly ToysServices services;

        public ToysController(DataContext context)
        {
            
            services = new ToysServices(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<AbstractToy>>> Get()
        {
            return Ok(services.Get().Result.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AbstractToy>> Get(int id)
        {
 

            return Ok(services.Get(id).Result.Value);

        }

        [HttpGet("{id}/play")]
        public async Task<ActionResult<string>> Play(int id)
        {
            
            var message = services.Play(id).Result.Value;
            return Content(message);

        }

        [HttpPost]
        public async Task<ActionResult<List<AbstractToy>>> Add(BearToy toy)
        {
            if (ModelState.IsValid)
            {
                await services.Add(toy);
                return NoContent();
            }

            return BadRequest("invalid state");
            

        }

        [HttpPut]
        public async Task<ActionResult<AbstractToy>> Update(AbstractToy toy)
        {

            return Ok(services.Update(toy).Result.Value);

        }

        [HttpDelete]
        public async Task<ActionResult<List<AbstractToy>>> Delete(int id)
        {
     
            return Ok(services.Delete(id).Result.Value);

        }

    }
}
