using MediatR;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries.ToyQueries;

namespace ToyStore.Handler.ToyHandler
{
    public class GetToyByIdHandler : IRequestHandler<GetToyByIdQuery, AbstractToy>
    {
        private readonly DataContext context;

        public GetToyByIdHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<AbstractToy> Handle(GetToyByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await context.Toys.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("No Toy found");

            return response;
        }
     }
}
