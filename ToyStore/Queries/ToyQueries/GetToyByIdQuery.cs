using MediatR;
using ToyStore.Models;

namespace ToyStore.Queries.ToyQueries
{
    public class GetToyByIdQuery : IRequest<AbstractToy>
    {
        public int Id { get; set; }

        public GetToyByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
