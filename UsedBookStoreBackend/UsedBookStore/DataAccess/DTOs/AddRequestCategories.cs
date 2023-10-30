using System.ComponentModel.DataAnnotations;
using UsedBookStore.DataAccess.Entities;

namespace UsedBookStore.DataAccess.DTOs
{
    public class AddRequestCategories
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minium of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        public string Name { get; set; }
    }
    
}
