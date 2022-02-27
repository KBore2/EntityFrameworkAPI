using MediatR;
using ToyStore.Models;

namespace ToyStore.Command.ToyCommand
{
    public class UpdateToyCommand : IRequest<AbstractToy>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public UpdateToyCommand(int id)
        {
            this.Id = id;
        }
    }
}
