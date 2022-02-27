using MediatR;
using ToyStore.Models;

namespace ToyStore.Command.ToyCommand
{
    public class DeleteToyCommand : IRequest<List<AbstractToy>>
    {
        public int Id { get; set; }

        public DeleteToyCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
