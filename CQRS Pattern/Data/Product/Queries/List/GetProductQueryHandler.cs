using CQRS_Pattern.Dtos;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Product.Queries.List
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
           _productRepository = productRepository; 
        }

        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product =  await _productRepository.GetProductByIdAsync(request.Id);
            if (product == null) { throw new KeyNotFoundException($"Product with id{request.Id} not found"); }
            return product;
        }
    }
}
