using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        [Column(TypeName = "text")] // PostgreSQL uses "text" instead of nvarchar
        public string Product_Name { get; set; }

        [Required]
        public int Product_Quantity { get; set; }

        public List<Sale>? Sales { get; set; }
    }
}










//using System.ComponentModel.DataAnnotations;

//namespace ShopManagement.Entities
//{
//    public class Product
//    {
//        [Key]
//        public int Product_Id { get; set; }

//        [Required]
//        public string Product_Name { get; set; }

//        [Required]
//        public int Product_Quantity { get; set; }

//        public List<Sale>? Sales { get; set; }
//    }
//}
