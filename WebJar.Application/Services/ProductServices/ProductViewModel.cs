using Microsoft.AspNetCore.Http;
using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices
{
    public record class ProductViewModel(string Name,
        IEnumerable<IFormFile>? Images, float Price,
        IEnumerable<PropertyViewModel> PropertyViewModels,
        IEnumerable<AddOnViewModel> AddOnViewModels, DiscountViewModel Discount,
        string PriceType = "CONSTANT");
}
