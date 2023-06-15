using System.ComponentModel.DataAnnotations;

namespace WebJar.Domain.Entities
{
    public class Product : Field
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImagesPath { get; set; }
        [Required]
        public decimal Price { get; set; }


        public IEnumerable<Property> Properties { get; set; }
        public Discount Discount { get; set; }
        public IEnumerable<AddOn> AddOns { get; set; }
    }
}
