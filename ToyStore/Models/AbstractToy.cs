using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyStore.Models
{
    public abstract class AbstractToy
    {

        public int Id { get; set; }

        [Required]
        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        [Required]
        public string Type { get; set; } = null!;

        public abstract string Play();
    }
}
