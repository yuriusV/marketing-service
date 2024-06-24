using Campaign.Application.Contracts.Services.CustomersService;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Campaign.Infrastructure.Services.Http.CustomerApi
{
    public class CustomersService : ICustomersService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public CustomersService(HttpClient client, IOptions<CustomerApiSettings> options)
        {
            _client = client;
            _baseUrl = options.Value.BaseUrl;
            _client.BaseAddress = new Uri(_baseUrl);
            _client.Timeout = TimeSpan.FromSeconds(options.Value.TimeoutSeconds);
        }
        public async Task<IReadOnlyList<CustomerDto>> GetCustomersAsync(CustomersQuery query)
        {
            var json = JsonSerializer.Serialize(query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/v1/Customers", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<IReadOnlyList<CustomerDto>>(responseContent);
                return apiResponse;
            }
            else
            {
                throw new HttpRequestException($"POST request failed with status code: {response.StatusCode}");
            }
        }
    }
}
