using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Data;
using ShopManagement.DTO;
using ShopManagement.Entities;


namespace ShopManagement.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext Db;

        public ProductsController(AppDbContext context) => Db = context;











        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await Db.Products
                .Select(p => new ProductResponseDTO
                {
                    Product_Id = p.Product_Id,
                    Product_Name = p.Product_Name,
                    Product_Quantity = p.Product_Quantity
                }).ToListAsync();

            return Ok(products);
        }
















        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO request)
        {
            var product = new Product
            {
                Product_Name = request.Product_Name,
                Product_Quantity = request.Product_Quantity
            };

            Db.Products.Add(product);
            await Db.SaveChangesAsync();

            var response = new ProductResponseDTO
            {
                Product_Id = product.Product_Id,
                Product_Name = product.Product_Name,
                Product_Quantity = product.Product_Quantity
            };

            return Ok(response);
        }













        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestDTO request)
        {
            var product = await Db.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Product_Name = request.Product_Name;
            product.Product_Quantity = request.Product_Quantity;

            await Db.SaveChangesAsync();

            return Ok(new ProductResponseDTO
            {
                Product_Id = product.Product_Id,
                Product_Name = product.Product_Name,
                Product_Quantity = product.Product_Quantity
            });
        }












        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await Db.Products.FindAsync(id);
            if (product == null) return NotFound();

            Db.Products.Remove(product);
            await Db.SaveChangesAsync();

            return Ok("Deleted Successfully");
        }
    }
}
