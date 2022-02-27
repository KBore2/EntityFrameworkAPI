using MediatR;
using ToyStore.Models;

namespace ToyStore.Command
{
    public class DeleteCustomerCommand : IRequest<List<Customer>>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
