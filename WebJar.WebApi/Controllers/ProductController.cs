using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebJar.Application.Services.ProductServices;
using WebJar.Application.Services.ProductServices.Commands;

namespace WebJar.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BasicController
    {
        private readonly IAddProductRepository _addProduct;
        public ProductController(IAddProductRepository addProduct)
        {
            _addProduct = addProduct;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductViewModel model,
            IEnumerable<IFormFile>? Images)
        {
            model.Images = Images;
            var response = await _addProduct.Execute(model);

            if (response.IsSuccess)
                return Ok(response);
            
            return BadRequest(response);
        }
    }
}
