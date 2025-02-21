
namespace Resources.Api.Resources.Services;

public class SecurityApi : INotifytheSecurityReviewTeam
{
    private HttpClient _httpClient;

    public SecurityApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> NotifyForSecurityReview(Guid id)
    {
        var response = await _httpClient.PostAsJsonAsync("/locations-notifications", new SoftwareTeamNotification(id));

        // Throw exception if response code doesn't indicate success
        // Can be manipulated to do some retries if that makes sense
        response.EnsureSuccessStatusCode();

        var responseMessage = await response.Content.ReadFromJsonAsync<SoftwareTeamNotificationResponse>();

        return responseMessage is null
            ? throw new NullReferenceException("Software Team Messed Up")
            : responseMessage.NotificationId.ToString();
    }
}

public record SoftwareTeamNotification(Guid ResourceId);

public record SoftwareTeamNotificationResponse(Guid NotificationId, Guid ResourceId);
