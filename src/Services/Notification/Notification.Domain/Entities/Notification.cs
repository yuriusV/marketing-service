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
        public Notification(Guid id, Guid customerId, decimal balance)
        {
            Id = id;
            CustomerId = customerId;
            Balance = balance;
        }

        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
