using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices.Queries
{
    public enum SortingProductsOrder
    {
        Cheapest,
        Expensivest,
        Name
    }
    public interface IGetProductServices
    {
        Task<ResultViewModel> Execute(IList<int>? sortings,
                                      string search);
    }

}
