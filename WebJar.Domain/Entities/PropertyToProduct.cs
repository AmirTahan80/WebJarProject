namespace WebJar.Domain.Entities
{
    public class PropertyToProduct
    {
        public int PropertyId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Property Property { get; set; }
    }
}
