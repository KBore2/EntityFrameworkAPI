using MediatR;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries.ToyQueries;

namespace ToyStore.Handler.ToyHandler
{
    public class GetToysHandler : IRequestHandler<GetToysQuery,List<AbstractToy>>
    {
        private readonly DataContext context;

        public GetToysHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<AbstractToy>> Handle(GetToysQuery request,CancellationToken cancellationToken)
        {
            var response = await context.Toys.ToListAsync();
            return response;
        }
     }
}
