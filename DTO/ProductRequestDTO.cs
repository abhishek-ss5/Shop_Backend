using System.ComponentModel.DataAnnotations;

namespace ShopManagement.DTO
{
    public class ProductRequestDTO
    {
        [Required(ErrorMessage = "Product Name is required !!")]
        public string Product_Name { get; set; }
        
        [Required(ErrorMessage = "Product Quantity is required !!")]
        public int Product_Quantity { get; set; }
    }
}