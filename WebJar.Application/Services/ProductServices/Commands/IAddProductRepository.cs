using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices.Commands
{
    public interface IAddProductRepository
    {
        Task<ResultViewModel> Execute(ProductViewModel addProduct);
    }
}
