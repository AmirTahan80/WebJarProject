using Microsoft.AspNetCore.Http;
using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            PropertyViewModels = new List<PropertyViewModel>();
            AddOnViewModels = new List<AddOnViewModel>();
        }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string PriceType { get; set; } = "CONSTANT";
        public string? Images { get; set; }
        public IList<PropertyViewModel> PropertyViewModels { get; set; }
        public IList<AddOnViewModel> AddOnViewModels { get; set; }
        public DiscountViewModel Discount { get; set; }
    }
}
