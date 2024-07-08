using Newtonsoft.Json;

namespace P7.Models
{
    public class SaleItem
    {
        public string id { get; set; }

        [JsonProperty(PropertyName = "category_name")]
        public string categoryName { get; set; }

        public string name { get; set; }

        [JsonProperty(PropertyName = "img_url")]
        public string? imgUrl {  get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string categoryId { get; set; }

        [JsonProperty(PropertyName = "price_sale")]
        public float? priceSale { get; set; }

        [JsonProperty(PropertyName = "price_sale_rounded")]
        public float? priceSaleRounded { get; set; }

        [JsonProperty(PropertyName = "price_regular")]
        public float? priceRegular { get; set; }

        [JsonProperty(PropertyName = "price_regular_rounded")]
        public float? priceRegularRounded { get; set; }

        [JsonProperty(PropertyName = "price_per_unit_sale")]
        public float? pricePerUnitSale {  get; set; }

        [JsonProperty(PropertyName = "price_per_unit_sale_rounded")]
        public float? pricePerUnitSaleRounded { get; set; }

        [JsonProperty(PropertyName = "price_per_unit_regular")]
        public float? pricePerUnitRegular { get; set; }

        [JsonProperty(PropertyName = "price_per_unit_regular_rounded")]
        public float? pricePerUnitRegularRounded { get; set;}

        [JsonProperty(PropertyName = "discount_percentage")]
        public int? discountPercentage {  get; set; }

        public string? unit { get; set; }

        [JsonProperty(PropertyName = "sale_start_date")]
        public string saleStartDate { get; set; }

        [JsonProperty(PropertyName = "sale_end_date")]
        public string? saleEndDate { get; set; } 

        public string? note { get; set; }

        public string store {  get; set; }

        public string StoreLogo => $"logo_{store}.webp";

        public string DisplayPriceSale => FormatPrice(priceSale, unit);
        public string DisplayPriceRegular => FormatPrice(priceRegular, unit);

        private string FormatPrice(float? price, string? unit)
        {
            if (price == null) return string.Empty;
            return unit != null ? $"{price}/{unit}" : price.ToString();
        }

        public bool recommended {  get; set; }
    }
}
