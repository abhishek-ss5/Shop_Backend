using ShopManagement.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopManagement.Entities
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int Sale_Id { get; set; }

        [Required]
        public int Product_Id { get; set; }

        [Required]
        public int Quantity_Sold { get; set; }

        [Required]
        public DateTime Sale_Date { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
            DateTime.UtcNow,
            TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")
        );

        [ForeignKey("Product_Id")]
        public Product? Product { get; set; }
    }
}


















//using ShopManagement.Entities;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//public class Sale
//{
//    [Key]
//    public int Sale_Id { get; set; }

//    [Required]
//    public int Product_Id { get; set; }

//    [Required]
//    public int Quantity_Sold { get; set; }

//    [Required]
//    public DateTime Sale_Date { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(
//        DateTime.UtcNow,
//        TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")
//    );


//    [ForeignKey("Product_Id")]
//    public Product? Product { get; set; }
//}
