using MediatR;
using ToyStore.Models;

namespace ToyStore.Command
{
    public class UpdateCustomerCommand: IRequest<Customer>
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public UpdateCustomerCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
