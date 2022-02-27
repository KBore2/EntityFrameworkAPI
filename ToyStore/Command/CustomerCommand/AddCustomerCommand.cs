using MediatR;
using ToyStore.Models;

namespace ToyStore.Command
{
    public class AddCustomerCommand : IRequest<Customer>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
    }
}
