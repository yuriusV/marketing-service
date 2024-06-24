using Campaign.Application.Contracts.Services.NotificationsService;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Campaign.Infrastructure.Services.Http.NotificationApi;

public class NotificationService : INotificationsService
{
    private readonly HttpClient _client;
    private readonly string _baseUrl;

    public NotificationService(HttpClient client, IOptions<NotificationApiSettings> options)
    {
        _client = client;
        _baseUrl = options.Value.BaseUrl;
        _client.BaseAddress = new Uri(_baseUrl);
        _client.Timeout = TimeSpan.FromSeconds(options.Value.TimeoutSeconds);
    }

    public async Task<NotificationResponse> NotifyAsync(Notification notification)
    {
        var json = JsonSerializer.Serialize(notification);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/v1/Notifications", content);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<NotificationResponse>(responseContent);
            return apiResponse;
        }
        else
        {
            throw new HttpRequestException($"POST request failed with status code: {response.StatusCode}");
        }
    }
}
