using MediatR;
using ToyStore.Models;

namespace ToyStore.Command.ToyCommand
{
    public class AddToyCommand : IRequest<AbstractToy>
    {
        public int CustomerID { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string Type { get; set; } = null!;
    }
}
