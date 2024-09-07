using Microsoft.AspNetCore.Mvc;
using ProdAPI.BL;
using ProdAPI.DB.CodeFirstMigration.Context;

namespace ProdAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
 

        private readonly IGenericBL<Product> _productBL;

        public ProductController(IGenericBL<Product> productBL)
        {
           _productBL = productBL;
        }

        [HttpGet]
        [Route("")]
        [Route("{id}")]
        public async Task<IActionResult> Get(long? id)
        {
            if (id > 0)
                return Ok(await _productBL.GetById(id ?? 0));
            else
                return Ok(await _productBL.GetAll());
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(Product product)
        {
            bool result = await _productBL.Add(product);
            return result ? Ok("Product Added successfully.") : BadRequest("Error occured while adding the product");
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put(Product product)
        {
            bool result = await _productBL.Update(product);
            return result ? Ok("Product updated successfully.") : BadRequest("Error occured while updating the product");
        }

        [HttpPut]
        [Route("add-to-stock/{id}/{quantity}")]
        public async Task<IActionResult> IncrementStock(long id, long quantity)
        {
            bool result = await _productBL.StockUpdate(id, quantity);
            return result ? Ok("Stock added.") : BadRequest("Error occured while updating the stock.");
        }

        [HttpPut]
        [Route("decrement-stock/{id}/{quantity}")]
        public async Task<IActionResult> DecrementStock(long id, long quantity)
        {
            bool result = await _productBL.StockUpdate(id,-quantity);
            return result ? Ok("Stock removed") : BadRequest("Error occured while updating the stock.");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool result = await _productBL.Delete(id);
            return result ? Ok("Product Removed") : BadRequest("Error occured while removing the product.");
        }
    }
}
