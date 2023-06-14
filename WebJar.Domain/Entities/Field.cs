using System.ComponentModel.DataAnnotations;

namespace WebJar.Domain.Entities
{
    /// <summary>
    /// This class is used for inject the properties that reapet in all the entities
    /// </summary>
    public class Field
    {
        [Key]
        public int Id { get; set; }
    }
}
