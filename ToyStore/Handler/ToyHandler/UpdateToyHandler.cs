using MediatR;
using ToyStore.Command.ToyCommand;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler.ToyHandler
{
    public class UpdateToyHandler : IRequestHandler<UpdateToyCommand, AbstractToy>
    {
        private readonly DataContext context;

        public UpdateToyHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<AbstractToy> Handle(UpdateToyCommand request, CancellationToken cancellationToken)
        {
            var response = await context.Toys.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("Toy not found");

            response.Name = request.Name;

            context.SaveChanges();
            return response;
        }
    }
}
