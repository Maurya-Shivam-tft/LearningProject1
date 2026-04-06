using CQRS_Pattern.Dtos;
using CQRS_Pattern.Model;

namespace CQRS_Pattern.Services
{
    public interface IProductRepository
    {
       public Task<List<ProductDto>> GetProductListAsync();
       public Task<ProductDto?> GetProductByIdAsync(Guid id);

    }
}
