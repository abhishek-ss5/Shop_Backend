using System.ComponentModel.DataAnnotations;

namespace ShopManagement.DTO
{
    public class SaleResponseDTO
    {
        public int Sale_Id { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public DateTime Sale_Date { get; set; }
    }
}
