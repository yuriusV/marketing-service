using Customer.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Guid Id { get; set; }

        public bool IsMale { get; set; }

        public string City { get; set; }

        public DateTime Birthdate { get; set; }

        public decimal Deposit { get; set; }

        public bool IsNewCustomer { get; set; }
    }
}
