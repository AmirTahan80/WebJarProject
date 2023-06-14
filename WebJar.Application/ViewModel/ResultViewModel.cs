using System.Net;

namespace WebJar.Application.ViewModel
{
    public record class ResultViewModel(object? Data, bool IsSuccess, 
        HttpStatusCode StatusCode,string? Messa);
}
