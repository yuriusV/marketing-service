using Campaign.Application.Contracts.Services;

namespace Campaign.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime DateTime => DateTime.UtcNow;
    }
}
