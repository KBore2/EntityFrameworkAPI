using System.ComponentModel.DataAnnotations;

namespace ToyStore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;


        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<AbstractToy> Toys { get; set; } = null!;






    }
}
