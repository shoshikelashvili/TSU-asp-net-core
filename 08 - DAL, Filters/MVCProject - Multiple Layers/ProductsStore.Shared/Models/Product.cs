using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your Name", AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [Range(0, 99.99)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
