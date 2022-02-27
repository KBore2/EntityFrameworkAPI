using MediatR;
using ToyStore.Command;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler
{
    public class UpdateCustomerHandler: IRequestHandler<UpdateCustomerCommand,Customer>
    {
        private readonly DataContext context;

        public UpdateCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request,CancellationToken cancellationToken)
        {
            var response = await context.Customers.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("Customer not Found");

            response.FirstName = request.FirstName;
            response.LastName = request.LastName;

            context.SaveChanges();
            return response;
        }


     }
}
