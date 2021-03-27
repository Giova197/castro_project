namespace CastroProgetto.Domain.Entities
{
    public class Product
    {
        public string Sku { get; }

        public string Name { get; }

        public string Category { get; }

        public int Price { get; }

        public Product(
            string sku,
            string name,
            string category,
            int price)
        {
            Sku = sku;
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
