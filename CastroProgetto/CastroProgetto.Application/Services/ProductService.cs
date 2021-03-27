using CastroProgetto.Application.DTO;
using CastroProgetto.Application.Factories;
using CastroProgetto.Domain.Entities;
using CastroProgetto.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastroProgetto.Application.Services
{
    class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductOutput>> GetProductsAsync(string category, int? priceLessThan)
            => (await _productRepository.GetProductsAsync(category, priceLessThan).ConfigureAwait(false) ?? new List<Product> { })
                .Select(p => ProductFactory.Create(p));
    }
}
