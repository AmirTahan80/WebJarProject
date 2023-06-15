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
        /// For sorting:
        ///     0. Cheapest
        ///     1. Expensive
        ///     2. Name
        /// Note: You can pass three of them for sorting, but don't sor by 1 and 0 together :) 
        /// </summary>
        /// <response code="200">If response is null or not null</response>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]IList<int>? sortings,
            string searh="")
        {
            if (sortings.Count > Enum.GetValues<SortingProductsOrder>().Length )
                return BadRequest("You can sort by "+ Enum.GetValues<SortingProductsOrder>().Length + " parameter not more");
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
