using CastroProgetto.Domain.Entities;
using CastroProgetto.Domain.Repositories;
using CastroProgetto.Persistence.Constants;
using CastroProgetto.Persistence.Options;
using Microsoft.Extensions.Options;
using Npgsql;
using RepoDb;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastroProgetto.Persistence.Repositories
{
    class ProductRepository : BaseRepository<Product, NpgsqlConnection>, IProductRepository
    {
        public ProductRepository(IOptions<DbOptions> options)
            : base(options.Value.ConnectionString)
        {

        }

        public Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<string> skus)
            => QueryAsync(p => skus.Contains(p.Sku));

        public async Task<IEnumerable<Product>> GetProductsAsync(string category, int? priceLessThan)
        {
            var where = new List<QueryField>();
            if (!string.IsNullOrWhiteSpace(category))
                where.Add(new QueryField(DbConstants.Product.Category, RepoDb.Enumerations.Operation.Equal, category));

            if (priceLessThan.HasValue)
                where.Add(new QueryField(DbConstants.Product.Price, RepoDb.Enumerations.Operation.LessThanOrEqual, priceLessThan.Value));

            var t  = await QueryAsync(where);
            return t;
        }

        public Task InserProductAsync(Product product)
            => InsertAsync(product);
    }
}
