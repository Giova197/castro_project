using CastroProgetto.Application.DTO;
using CastroProgetto.Domain.Entities;
using System;
using System.Linq;

namespace CastroProgetto.Application.Factories
{
    internal static class ProductFactory
    {
        private const string BOOTS_CATEGORY = "boots";
        private static readonly string[] PRODUCTS_WITH_DISCOUNT_OF_15 = new string[] { "000003" };

        public static ProductOutput Create(Product product)
        {
            var discountPercent = 0;
            if (product.Category == BOOTS_CATEGORY)
                discountPercent = 30;

            if (PRODUCTS_WITH_DISCOUNT_OF_15.Contains(product.Sku))
                discountPercent = 15;

            return ProductOutput.Create(
                    product,
                    ((100 - discountPercent) * product.Price) / 100,
                    discountPercent > 0 ? $"{discountPercent}%" : null,
                    "EUR"
                );
        }
    }
}
