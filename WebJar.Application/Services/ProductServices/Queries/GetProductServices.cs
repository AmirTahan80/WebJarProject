using Microsoft.EntityFrameworkCore;
using System.Net;
using WebJar.Application.ViewModel;
using WebJar.Domain.Entities;
using Context = WebJar.Persistence.Data.AppContext;

namespace WebJar.Application.Services.ProductServices.Queries
{
    public class GetProductServices : IGetProductServices
    {
        private readonly Context _context;

        public GetProductServices(Context context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Execute()
        {
            try
            {
                var products = await _context.Products
                    .Include(p=> p.AddOns)
                    .Include(p=>p.Discount)
                    .Include(p=> p.Properties)
                    .ThenInclude(c=> c.PropertyValues)
                    .ToListAsync();

                if (products is null)
                    return new(null, true,
                       HttpStatusCode.NoContent,
                       "No content found");

                var returnProduct = products.Select(
                    p => new ProductViewModel()
                    {
                        Name = p.Name,
                        Price = CalculateProductPrice(p),
                        AddOnViewModels = p.AddOns.Select(c =>
                        new AddOnViewModel(c.Name, c.Price)).ToList(),
                        Images = p.ImagesPath.ToList(),
                        Discount=p.Discount is null? null : new DiscountViewModel(p.Discount.Amount,
                        p.Discount.ExpireDate),
                        PropertyViewModels = p.Properties.Select(c => new 
                        PropertyViewModel(c.Name,c.PropertyValues.Select(d => 
                        new PropertyValueViewModel(d.Value,d.Price)).ToList())).ToList()
                    }).ToList();

                return new(returnProduct, true,
                       System.Net.HttpStatusCode.OK,
                       "Products");
            }
            catch (Exception ex)
            {
                return new(ex, false, HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private long CalculateProductPrice(Product product)
        {
            long price = product.Price;

            if ((product.Discount is not null && product.Discount.Amount is not null) 
                &&
                (product.Discount.ExpireDate > DateTime.Now || product.Discount.ExpireDate is null))
            {
                price -= (long)product.Discount.Amount;
            }
            else if (product.Discount is not null)
            {
                _context.Discounts.Remove(product.Discount);
                _context.SaveChangesAsync();
            }

            return price < 0? 0: price;
        }
    }

}
