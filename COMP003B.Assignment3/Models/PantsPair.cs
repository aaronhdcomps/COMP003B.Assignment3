using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
    public class PantsPair
    {

        [Required]
        [Range(1,99)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
        
    }
}
