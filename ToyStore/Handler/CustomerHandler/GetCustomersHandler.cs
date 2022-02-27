using MediatR;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries;
using ToyStore.Response;

namespace ToyStore.Handler
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery,List<Customer>>
    {
        private readonly DataContext context;

        public GetCustomersHandler(DataContext context)
        {
            this.context = context;
        }
        public async Task<List<Customer>> Handle(GetCustomersQuery request,CancellationToken cancellationToken)
        {
            var customers = await context.Customers.ToListAsync();
            if (customers == null)
                throw new NullReferenceException("Customers not found");

            return customers;

        }


    }
}
