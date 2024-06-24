using Campaign.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Domain.Entities
{
    public class CampaignActivity : EntityBase
    {
        public CampaignActivity() { }

        public CampaignActivity(Guid id)
        {
            Id = id;
        }
        public Guid TargetId { get; set; }
    }
}
