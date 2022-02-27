using MediatR;
using ToyStore.Models;

namespace ToyStore.Queries.ToyQueries
{
    public class GetToysQuery : IRequest<List<AbstractToy>>
    {
    }
}
