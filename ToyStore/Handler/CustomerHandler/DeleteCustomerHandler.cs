using MediatR;
using ToyStore.Command;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand,List<Customer>>
    {
        private readonly DataContext context;
        
        public DeleteCustomerHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> Handle(DeleteCustomerCommand request,CancellationToken cancellationToken)
        {
            var response = await context.Customers.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("Customer not found");

            context.Customers.Remove(response);
            context.SaveChanges();
            return context.Customers.ToList();



        }
    }
}
