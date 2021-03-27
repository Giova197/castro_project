using CastroProgetto.Domain.Entities;
using CastroProgetto.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace CastroProgetto.Application.Extensions
{
    public static class IHostExtension
    {
        private static readonly Product[] _products = new Product[] {
            new Product("000001", "BV Lean leather ankle boots", "boots", 89000),
            new Product("000002", "BV Lean leather ankle boots", "boots", 99000),
            new Product("000003", "Ashlington leather ankle boots", "boots", 71000),
            new Product("000004", "Naima embellished suede sandals", "sandals", 79500),
            new Product("000005", "Nathane leather sneakers", "sneakers", 59000)
        };


        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();
                SeedProducts(productRepository).GetAwaiter().GetResult();
            }
            return host;
        }

        private static async Task SeedProducts(IProductRepository productRepository)
        {
            var skuProductsInserted = (await productRepository.GetProductsAsync(_products.Select(x => x.Sku))
                .ConfigureAwait(false))
                .Select(x => x.Sku);

            var t = _products.Where(x => !skuProductsInserted.Contains(x.Sku));
            foreach (var product in t)
            {
                await productRepository.InserProductAsync(product).ConfigureAwait(false);
            }
        }
    }
}
