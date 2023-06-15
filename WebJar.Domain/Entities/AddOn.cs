using System.ComponentModel.DataAnnotations;

namespace WebJar.Domain.Entities
{
    public class AddOn : Field
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
