using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices.Queries
{
    public interface IGetProductServices
    {
        Task<ResultViewModel> Execute();
    }

}
