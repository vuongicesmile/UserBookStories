namespace UsedBookStore.DataAccess.Entities
{
    public class PaymentInfo
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
