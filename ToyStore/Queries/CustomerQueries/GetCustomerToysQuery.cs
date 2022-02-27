using MediatR;
using ToyStore.Models;

namespace ToyStore.Queries
{
    public class GetCustomerToysQuery : IRequest<List<AbstractToy>>
    {
        public int Id { get; set; }

        public GetCustomerToysQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
