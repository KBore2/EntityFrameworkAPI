using MediatR;
using ToyStore.Command.ToyCommand;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler.ToyHandler
{
    public class DeleteToyHandler : IRequestHandler<DeleteToyCommand,List<AbstractToy>>
    {
        private readonly DataContext context;

        public DeleteToyHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<AbstractToy>> Handle(DeleteToyCommand request,CancellationToken cancellationToken)
        {
            var response = await context.Toys.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("Toy not found");

            context.Toys.Remove(response);
            context.SaveChanges();
            return context.Toys.ToList();
        }
    }
}
