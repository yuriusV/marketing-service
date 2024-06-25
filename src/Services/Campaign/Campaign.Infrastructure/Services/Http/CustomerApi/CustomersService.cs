using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Campaign.Infrastructure.Services.Http.CustomerApi;

public class CustomersService : ICustomersService
{
    private const string FindCustomersEndpoint = "/api/v1/CustomersSearches";
    private const string MediaType = "application/json";
    private readonly HttpClient _client;
    private readonly ILogger<CustomersService> logger;
    private readonly string _baseUrl;

    public CustomersService(HttpClient client, IOptions<CustomerApiSettings> options, ILogger<CustomersService> logger)
    {
        _client = client;
        this.logger = logger;
        _baseUrl = options.Value.BaseUrl;
        _client.BaseAddress = new Uri(_baseUrl);
        _client.Timeout = TimeSpan.FromSeconds(options.Value.TimeoutSeconds);
    }
    public async Task<IReadOnlyList<CustomerDto>> GetCustomersAsync(CustomerQuery query)
    {
        var json = JsonSerializer.Serialize(query);
        var content = new StringContent(json, Encoding.UTF8, MediaType);
        var response = await _client.PostAsync(FindCustomersEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            logger.LogInformation("Customers response: {content}", responseContent);
            var apiResponse = JsonSerializer.Deserialize<List<CustomerDto>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return apiResponse;
        }
        else
        {
            logger.LogError("Url: {Url}, Status: {StatusCode}, Response: {Response}", FindCustomersEndpoint, response.StatusCode, response.ReasonPhrase);
            throw new HttpRequestException($"POST request failed with status code: {response.StatusCode}");
        }
    }
}
