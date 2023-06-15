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
        public required long Price { get; set; }
        public string PriceType { get; set; } = "CONSTANT";
        public IList<string>? Images { get; set; }
        public IList<PropertyViewModel> PropertyViewModels { get; set; }
        public IList<AddOnViewModel> AddOnViewModels { get; set; }
        public DiscountViewModel Discount { get; set; }
    }
}
