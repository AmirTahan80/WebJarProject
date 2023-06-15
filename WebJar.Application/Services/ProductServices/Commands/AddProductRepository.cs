using Microsoft.Extensions.Configuration;
using System.Net;
using WebJar.Application.Extention;
using WebJar.Application.ViewModel;
using WebJar.Domain.Entities;
using Context = WebJar.Persistence.Data.AppContext;

namespace WebJar.Application.Services.ProductServices.Commands
{
    public class AddProductRepository : IAddProductRepository
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        public AddProductRepository(Context context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ResultViewModel> Execute(ProductViewModel addProduct)
        {
            try
            {
                if (addProduct.Images == null || addProduct.Images.Count() == 0)
                    return new(addProduct, false,
                        HttpStatusCode.BadRequest, "Images can't be null.");

                var createProduct = new Product()
                {
                    Name = addProduct.Name,
                    Price = CalculatePrice(addProduct.PriceType, addProduct.Price),
                    ImagesPath = addProduct.Images,
                    AddOns = addProduct.AddOnViewModels?.Select(p =>
                    new AddOn()
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToList(),
                    Discount = new()
                    {
                        Amount = addProduct.Discount?.Amount,
                        ExpireDate = addProduct.Discount?.ExpireDate
                    },
                    Properties = addProduct.PropertyViewModels.Select(p =>
                    new Property()
                    {
                        Name = p.Name,
                        PropertyValues = p.PropertyValueViewModels.Select(
                            c =>
                            new PropertyValue()
                            {
                                Price = CalculatePrice(c.PriceType, c.Price),
                                Value = c.Value
                            }).ToList()
                    }).ToList()
                };
                await _context.Products.AddAsync(createProduct);
                var res = await _context.SaveChangesAsync();
                if (res > 0)
                    return new ResultViewModel(addProduct, true, HttpStatusCode.OK, "Product Added.");
                return new ResultViewModel(addProduct, false, HttpStatusCode.BadRequest, "Have error to add product, try again.");
            }
            catch (Exception ex)
            {
                return new ResultViewModel(ex, false, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private decimal CalculatePrice(string priceType, decimal price)
        {
            if (priceType.ToUpper() == "CONSTANT")
                return price;
            var dollor = int.Parse(_configuration["DollarInToman"]);
            return price * dollor;
        }

    }
}
