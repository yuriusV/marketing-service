using Campaign.Application.Contracts.Services.NotificationsService;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Campaign.Infrastructure.Services.Http.NotificationApi;

public class NotificationService : INotificationsService
{
    private const string NotificationsEndpoint = "/api/v1/Notifications";
    private readonly HttpClient _client;
    private readonly ILogger<NotificationService> logger;
    private readonly string _baseUrl;

    public NotificationService(
        HttpClient client,
        IOptions<NotificationApiSettings> options,
        ILogger<NotificationService> logger)
    {
        _client = client;
        this.logger = logger;
        _baseUrl = options.Value.BaseUrl;
        _client.BaseAddress = new Uri(_baseUrl);
        _client.Timeout = TimeSpan.FromSeconds(options.Value.TimeoutSeconds);
    }

    public async Task<NotificationResponse> NotifyAsync(Notification notification)
    {
        var json = JsonSerializer.Serialize(notification);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(NotificationsEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<NotificationResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return apiResponse;
        }
        else
        {
            logger.LogError("Url: {Url}, Status: {StatusCode}, Response: {Response}", NotificationsEndpoint, response.StatusCode, response.ReasonPhrase);
            throw new HttpRequestException($"POST request failed with status code: {response.StatusCode}");
        }
    }
}
