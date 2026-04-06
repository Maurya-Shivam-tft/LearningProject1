namespace CQRS_Pattern.Dtos
{
    public record ProductDto(Guid id, string name, string Description, Decimal price);
}
