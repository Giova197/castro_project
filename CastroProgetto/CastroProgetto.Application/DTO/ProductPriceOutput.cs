using Newtonsoft.Json;

namespace CastroProgetto.Application.DTO
{
    public class ProductPriceOutput
    {
        public int Original { get; }

        public int Final { get; }

        [JsonProperty("discount_percentage")]
        public string DiscountPercentage { get; }

        public string Currency { get; }

        internal ProductPriceOutput(int original, int final, string discountPercentage, string currency)
        {
            Original = original;
            Final = final;
            DiscountPercentage = discountPercentage;
            Currency = currency;
        }
    }
}
