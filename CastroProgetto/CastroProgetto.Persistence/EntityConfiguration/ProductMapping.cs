using CastroProgetto.Domain.Entities;
using CastroProgetto.Persistence.Constants;
using RepoDb;
using RepoDb.Interfaces;
using System.Data.Common;

namespace CastroProgetto.Persistence.EntityConfiguration
{
    internal static class ProductMapping
    {
        internal static void Map()
        {
            var productMappingDefinition = FluentMapper.Entity<Product>();

            productMappingDefinition
                .Table($"public.{DbConstants.Product.TableName}")
                .Primary(e => e.Sku)
                .Column(e => e.Sku, DbConstants.Product.Sku)
                .Column(e => e.Name, DbConstants.Product.Name)
                .Column(e => e.Category, DbConstants.Product.Category)
                .Column(e => e.Price, DbConstants.Product.Price);
        }
    }

    class ProductClassHandler : IClassHandler<Product>
    {
        public Product Get(Product entity, DbDataReader reader)
        {
            return entity;
        }

        public Product Set(Product entity)
        {
            return entity;
        }
    }
}
