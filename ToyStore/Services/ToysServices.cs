using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Services
{
    public class ToysServices
    {
        private readonly DataContext context;

        public ToysServices(DataContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<List<AbstractToy>>> Get()
        {
            return await context.Toys.ToListAsync();
        }

        public async Task<ActionResult<AbstractToy>> Get(int id)
        {
            var toy = await context.Toys.FindAsync(id);

            if (toy == null)
                throw new NullReferenceException("Toy not Found");

            return toy;

        }

        
        public async Task<ActionResult<string>> Play(int id)
        {
            var toy = await context.Toys.FindAsync(id);

            if (toy == null)
                throw new NullReferenceException("Toy not Found");

            string type = toy.Type; 
            AbstractToy playToy = new ToyCreator().Create(type);
            string message = playToy.Play();

            return message;

        }

        
        public async Task<ActionResult<AbstractToy>> Add(BearToy toy)
        {
            
            context.Toys.Add(toy);
            await context.SaveChangesAsync();
            return toy;
            

        }

        
        public async Task<ActionResult<AbstractToy>> Update(AbstractToy toy)
        {
            var updatedToy = await context.Toys.FindAsync(toy.Id);

            if(updatedToy == null)
                throw new NullReferenceException("Toy not Found");

            updatedToy.Name = toy.Name;

            await context.SaveChangesAsync();

            return updatedToy;

        }

        
        public async Task<ActionResult<List<AbstractToy>>> Delete(int id)
        {
            var updatedToy = await context.Toys.FindAsync(id);

            if (updatedToy == null)
                throw new NullReferenceException("Toy not Found");

            context.Toys.Remove(updatedToy);
            await context.SaveChangesAsync();
            return await context.Toys.ToListAsync();

        }

    }
}
