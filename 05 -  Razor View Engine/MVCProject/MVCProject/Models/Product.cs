using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter your Name", AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [Range(0,99.99)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
