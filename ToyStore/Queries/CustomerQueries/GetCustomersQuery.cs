using MediatR;
using ToyStore.Models;
using ToyStore.Response;

namespace ToyStore.Queries
{
    public class GetCustomersQuery : IRequest<List<Customer>>
    {
    }
}
