using Microsoft.Extensions.Options;
using Notification.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private string _path;
        public NotificationRepository(IOptions<FileSettings> options)
        {
            _path = options.Value.FilePath;
        }

        public async Task<string> CreateNotificationAsync(Domain.Entities.Notification notification)
        {
            await File.AppendAllTextAsync(_path, $"Customer: {notification.TargetId}, data: {notification.Contents}{Environment.NewLine}");
            
            return Guid.NewGuid().ToString();
        }
    }
}
