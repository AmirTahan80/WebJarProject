using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebJar.Domain.Entities
{
    public class PropertyValue : Field
    {
        [Required]
        public string Value { get; set; }
        [Required]
        public long Price { get; set; }

        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
