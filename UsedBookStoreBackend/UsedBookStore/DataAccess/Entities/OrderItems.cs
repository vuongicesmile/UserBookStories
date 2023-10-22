namespace UsedBookStore.DataAccess.Entities
{
    public class OrderItems
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
