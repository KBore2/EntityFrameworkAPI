using MediatR;

namespace ToyStore.Command
{
    public class PlayWithToyCommand : IRequest<string>
    {
        public int Id { get; set; }

        public PlayWithToyCommand(int Id)
        {
            this.Id = Id;
        }
    }
}
