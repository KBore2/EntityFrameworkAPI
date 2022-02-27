using MediatR;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries;
using ToyStore.Response;

namespace ToyStore.Handler
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIDQuery,Customer>
    {
        private readonly DataContext context;

        public GetCustomerByIdHandler(DataContext context)
        {
            this.context = context;
        }
        public async Task<Customer> Handle(GetCustomerByIDQuery request, CancellationToken cancellationToken)
        {
            var customer = await context.Customers.FindAsync(request.Id);

            if (customer == null)
                throw new NullReferenceException("Customer not found");

            return customer;
        }
    }
}
