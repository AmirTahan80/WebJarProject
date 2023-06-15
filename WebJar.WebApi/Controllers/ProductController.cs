using Microsoft.AspNetCore.Mvc;
using WebJar.Application.Extention;
using WebJar.Application.Services.ProductServices;
using WebJar.Application.Services.ProductServices.Commands;
using WebJar.Application.Services.ProductServices.Queries;

namespace WebJar.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BasicController
    {
        private readonly IAddProductRepository _addProduct;
        private readonly IGetProductServices _getProduct;

        public ProductController(IAddProductRepository addProduct,
            IGetProductServices getProduct)
        {
            _addProduct = addProduct;
            _getProduct = getProduct;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            var response = await _addProduct.Execute(model);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
        /// <summary>
        /// Get All Products With Filter.
        /// </summary>
        /// <returns>
        ///     200 - If response not null or null
        /// </returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]IList<int>? sortings,
            string searh="")
        {
            var response = await _getProduct.Execute(sortings,searh);

            return Ok(response);
        }


        [HttpPost("UploadImages")]
        public async Task<IActionResult> UploadImages(IList<IFormFile> images, string placeHolder)
        {
            return Ok(FileUpload.UploadImages(images, placeHolder));
        }
    }
}
