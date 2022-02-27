using MediatR;
using ToyStore.Models;
using ToyStore.Response;

namespace ToyStore.Queries
{
    public class GetCustomerByIDQuery : IRequest<Customer>
    {
        public int Id { get; set; }

        public GetCustomerByIDQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
