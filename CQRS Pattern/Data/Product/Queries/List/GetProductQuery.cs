using CQRS_Pattern.Dtos;
using MediatR;

namespace CQRS_Pattern.Data.Product.Queries.List
{
    public record GetProductQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
    
}
