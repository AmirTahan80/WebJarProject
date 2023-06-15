using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using WebJar.Application.Extention;
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
        public async Task<IActionResult> Create(ProductViewModel model)
        {   
            var response = await _addProduct.Execute(model);

            if (response.IsSuccess)
                return Ok(response);
            
            return BadRequest(response); 
        }

        [HttpPost("UploadImages")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> images, string placeHolder)
        {
            return Ok(FileUpload.UploadImages(images, placeHolder));
        }
    }
}
