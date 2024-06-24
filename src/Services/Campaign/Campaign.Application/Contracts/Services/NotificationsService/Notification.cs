namespace Campaign.Application.Contracts.Services.NotificationsService
{
    public class Notification
    {
        public Guid TargetId { get; set; }

        public string Contents { get; set; }
    }
}
