using CQRS_Pattern.Dtos;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Product.Queries.List
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsListQueryHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductListAsync();
        }
       
    }
}
