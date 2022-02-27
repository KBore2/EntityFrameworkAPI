using MediatR;
using ToyStore.Command;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler
{
    public class AddCustomerHandler: IRequestHandler<AddCustomerCommand,Customer>
    {
        private readonly DataContext context;

        public AddCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<Customer> Handle(AddCustomerCommand request,CancellationToken cancellationToken)
        {
            Customer customer = new Customer();
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.DateOfBirth = request.DateOfBirth;
            await context.Customers.AddAsync(customer);
            context.SaveChanges();
            return customer;
        }
     }
}
