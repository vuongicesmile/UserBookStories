namespace UsedBookStore.DataAccess.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IList<Product> Products { get; set; }

        public Categories() { 
            Products= new List<Product>();
        }
    }
}
