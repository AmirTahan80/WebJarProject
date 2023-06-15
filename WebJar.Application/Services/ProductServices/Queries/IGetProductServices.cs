using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJar.Application.ViewModel;

namespace WebJar.Application.Services.ProductServices.Queries
{
    public interface IGetProductServices
    {
        Task<ResultViewModel> Execute();
    }

}
