namespace UsedBookStore.DataAccess.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    }
}

