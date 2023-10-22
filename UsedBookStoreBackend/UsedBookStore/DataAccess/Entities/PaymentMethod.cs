namespace UsedBookStore.DataAccess.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public int PaymentId { get; set; }
    }
}
