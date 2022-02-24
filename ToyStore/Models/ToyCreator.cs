namespace ToyStore.Models
{
    public class ToyCreator
    {
        public AbstractToy Create(string type)
        {
            if (type == "bear")
                return new BearToy();
            else if (type == "car")
                return new CarToy();
            else
                throw new ArgumentNullException();
        }
    }
}
