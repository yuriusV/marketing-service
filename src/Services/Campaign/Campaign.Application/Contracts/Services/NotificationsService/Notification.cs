namespace Campaign.Application.Contracts.Services.NotificationsService;

public class Notification
{
    public Notification()
    {
    }

    public Notification(Guid targetId, string contents)
    {
        TargetId = targetId;
        Contents = contents;
    }

    public Guid TargetId { get; set; }

    public string Contents { get; set; }
}
