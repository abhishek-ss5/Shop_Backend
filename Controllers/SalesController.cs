using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Data;
using ShopManagement.DTO;
using ShopManagement.Entities;

namespace ShopManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly AppDbContext Db;

        public SalesController(AppDbContext context) => Db = context;









        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var sales = await Db.Sales.Include(s => s.Product)
                .Select(s => new SaleResponseDTO
                {
                    Sale_Id = s.Sale_Id,
                    Product_Id = s.Product_Id,
                    Product_Name = s.Product.Product_Name,
                    Product_Quantity = s.Quantity_Sold,
                    Sale_Date = s.Sale_Date
                }).ToListAsync();

            return Ok(sales);
        }









        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] SaleRequestDTO request)
        {
            var product = await Db.Products.FindAsync(request.Product_Id);
            if (product == null)
                return NotFound("Product not found");

            if (product.Product_Quantity < request.Quantity)
                return BadRequest("Insufficient stock");

            product.Product_Quantity -= request.Quantity;

            var sale = new Sale
            {
                Product_Id = request.Product_Id,
                Quantity_Sold = request.Quantity
            };

            Db.Sales.Add(sale);
            await Db.SaveChangesAsync();

            return Ok(new SaleResponseDTO
            {
                Sale_Id = sale.Sale_Id,
                Product_Id = product.Product_Id,
                Product_Name = product.Product_Name,
                Product_Quantity = product.Product_Quantity
            });
        }
    }
}
