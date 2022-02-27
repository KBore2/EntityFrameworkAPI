using MediatR;
using ToyStore.Command.ToyCommand;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler.ToyHandler
{
    public class AddToyHandler : IRequestHandler<AddToyCommand,AbstractToy>
    {
        private readonly DataContext context;

        public AddToyHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<AbstractToy> Handle(AddToyCommand request, CancellationToken cancellationToken)
        {
            AbstractToy toy = new BearToy();
            toy.Name = request.Name;
            toy.Type = request.Type;
            toy.CustomerID = request.CustomerID;
            toy.DateCreated = request.DateCreated;

            var response = await context.Toys.AddAsync(toy);
            context.SaveChanges();
            return toy;
        }
    }
}
