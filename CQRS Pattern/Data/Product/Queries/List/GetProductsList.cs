using CQRS_Pattern.Dtos;
using MediatR;

namespace CQRS_Pattern.Data.Product.Queries.List
{
    public record GetProductsListQuery : IRequest<List<ProductDto>>;
    
    
}
