using CastroProgetto.Domain.Entities;

namespace CastroProgetto.Application.DTO
{
    public class ProductOutput
    {
        public string Sku { get; }

        public string Name { get; }

        public string Category { get; }

        public ProductPriceOutput Price { get; }

        private ProductOutput(string sku, string name, string category, ProductPriceOutput price)
        {
            Sku = sku;
            Name = name;
            Category = category;
            Price = price;
        }

        public static ProductOutput Create(Product p, int final, string discountPercentage, string currency)
            => new ProductOutput(
                    p.Sku,
                    p.Name,
                    p.Category,
                    new ProductPriceOutput(
                            p.Price,
                            final,
                            discountPercentage,
                            currency
                        )
                );
    }
}
