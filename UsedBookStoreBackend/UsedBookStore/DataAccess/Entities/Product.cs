namespace UsedBookStore.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Solid { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public string Desc { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Categories? Categories { get; set; }
    }
}
