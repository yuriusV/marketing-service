using Notification.Domain.Common;

namespace Notification.Domain.Entities;

public class Notification : EntityBase
{
    public Notification()
    {

    }

    public Guid TargetId { get; set; }
    public string Contents { get; set; }
}
