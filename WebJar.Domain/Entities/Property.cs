using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJar.Domain.Entities
{
    public class Property:Field
    {
        [Required]
        public string Name { get; set; }



        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public IEnumerable<PropertyValue> PropertyValues { get; set; }

    }
}
