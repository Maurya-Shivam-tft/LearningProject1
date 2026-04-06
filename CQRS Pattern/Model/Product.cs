namespace CQRS_Pattern.Model
{
    public class Product
    {
        public Guid Id { get; set; } =  Guid.NewGuid();

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal Price { get; set; } = 0;
    }
}
