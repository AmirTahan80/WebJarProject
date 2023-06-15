using System.ComponentModel.DataAnnotations.Schema;

namespace WebJar.Domain.Entities
{
    public class Discount : Field
    {
        public decimal? Amount { get; set; }
        public DateTime? ExpireDate { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
