using System.ComponentModel.DataAnnotations;

namespace ShopManagement.DTO
{
    public class SaleRequestDTO
    {
        [Required (ErrorMessage = "Product Id required !!")]
        public int Product_Id { get; set; }

        [Required (ErrorMessage = "Product quantity required !!")]
        public int Quantity { get; set; }
    }
}

