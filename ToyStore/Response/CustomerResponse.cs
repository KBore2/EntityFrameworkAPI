using MediatR;

namespace ToyStore.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
    }
}
