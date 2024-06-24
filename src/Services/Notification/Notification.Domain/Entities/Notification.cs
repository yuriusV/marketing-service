using Notification.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities
{
    public class Notification : EntityBase
    {
        public Notification()
        {

        }

        public Guid TargetId { get; set; }
        public string Contents { get; set; }
    }
}
