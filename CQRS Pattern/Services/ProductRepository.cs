using CQRS_Pattern.Data;
using CQRS_Pattern.Dtos;
using CQRS_Pattern.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Pattern.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dbContext;

        public ProductRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.Where(prd => prd.Id == id).Select(prd => new ProductDto(prd.Id, prd.Name, prd.Description, prd.Price)).FirstOrDefaultAsync();

        }

        public async Task<List<ProductDto>> GetProductListAsync()
        {
            return await _dbContext.Products.Select(prd => new ProductDto(prd.Id, prd.Name, prd.Description, prd.Price)).ToListAsync();
        }
    }

}
