using MediatR;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;
using ToyStore.Queries;

namespace ToyStore.Handler
{
    public class GetCustomerToysHandler : IRequestHandler<GetCustomerToysQuery,List<AbstractToy>>
    {
        private readonly DataContext context;

        public GetCustomerToysHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<AbstractToy>> Handle(GetCustomerToysQuery request,CancellationToken cancellationToken)
        {
            var response = await context.Toys.Where(x => x.CustomerID == request.Id).ToListAsync();
            if (response == null)
                throw new NullReferenceException("toys not found");

            return response;

        }
    }
}
