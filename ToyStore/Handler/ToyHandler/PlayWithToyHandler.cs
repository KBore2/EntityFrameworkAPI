using MediatR;
using ToyStore.Command;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Handler.ToyHandler
{
    public class PlayWithToyHandler : IRequestHandler<PlayWithToyCommand,string>
    {
        private readonly DataContext context;

        public PlayWithToyHandler(DataContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(PlayWithToyCommand request, CancellationToken cancellationToken)
        {
            var response = await context.Toys.FindAsync(request.Id);
            if (response == null)
                throw new NullReferenceException("Toy not found");

            string type = response.Type;
            AbstractToy playToy = new ToyCreator().Create(type);
            string message = playToy.Play();

            return message;
        }
    }
}
