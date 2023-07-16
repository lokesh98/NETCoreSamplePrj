using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test_Core3.BusinessLayer.Utility;

namespace Test_Core3.BusinessLayer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000.99)]
        public decimal Price { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        public bool IsDiscontinued { get; set; }
        [ForeignKey("Category")]
        [Required(ErrorMessage ="Please select category")]
        //[MustBeSelectedAttribute]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
