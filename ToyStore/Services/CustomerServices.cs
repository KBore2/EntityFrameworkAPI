using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ToyStore.Models;
using ToyStore.Data;
using Microsoft.EntityFrameworkCore;

namespace ToyStore.Services
{
    
    public class CustomerServices
    {

        private readonly DataContext context;

        public CustomerServices(DataContext context)
        {
            this.context = context;
        }
        
        public async Task<ActionResult<List<Customer>>> Get()
        {

            return await context.Customers.ToListAsync();
            
        }
        public async Task<ActionResult<Customer>> Get(int id)
        {
           
            var customer = await context.Customers.FindAsync(id);

            if (customer == null)
                throw new NullReferenceException("Customer not found");

            return customer;

        }

        public async Task<ActionResult<List<AbstractToy>>> Toys(int id)
        {

            var toys = await context.Toys.Where(x => x.CustomerID == id).ToListAsync();

            if (toys == null)
                throw new NullReferenceException("Toys not found");

            return toys;

        }

        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer)
        {
            var updatedCustomer = await context.Customers.FindAsync(customer.Id);

            if (updatedCustomer == null)
                throw new NullReferenceException("Customer not found");

            updatedCustomer.FirstName = customer.FirstName;
            updatedCustomer.LastName = customer.LastName;

            await context.SaveChangesAsync();

            return await context.Customers.ToListAsync();

        }

        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var customer = await context.Customers.FindAsync(id);

            if (customer == null)
                throw new NullReferenceException();

            context.Customers.Remove(customer);
            await context.SaveChangesAsync();

            return await context.Customers.ToListAsync();
        }
    }
}
