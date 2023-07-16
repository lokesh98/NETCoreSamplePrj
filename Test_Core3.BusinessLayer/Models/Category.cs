using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Core3.BusinessLayer.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName ="varchar(50)")]
        [Required]
        public string CategoryName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? CategoryDescription { get; set; }

        public ICollection<Product> Products { get; set;}
    }
}
