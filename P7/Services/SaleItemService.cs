using Newtonsoft.Json;
using P7.Models;

namespace P7.Services
{
    public class SaleItemService
    {
        private readonly HttpClient _httpClient;

        public SaleItemService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<SaleItemsResponse> getSaleItemsAsync(string storeName, string sorting, bool isRecommended, int currentPage)
        {
            var response = await _httpClient.GetStringAsync($"https://p7.veiledbit.xyz/saleItems/{storeName}/?page={currentPage}&sort={sorting}&recommended={isRecommended}");
            var saleItemsResponse = JsonConvert.DeserializeObject<SaleItemsResponse>(response);
            return saleItemsResponse;
        }
    }
}
