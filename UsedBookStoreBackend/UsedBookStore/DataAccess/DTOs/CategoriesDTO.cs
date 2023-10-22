using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.DTOs
{
    public class CategoriesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IList<Product> Products { get; set; }
    }
}
