namespace UsedBookStore.DataAccess.Entities
{
    public class ProductProducer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProducerId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Product Products { get; set; }
        public Producers Producers { get; set; }
        public ProductProducer() {}
    }
}
