using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Application.Contracts.Services.NotificationsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Aggregates.CampaignActivity
{
    public class CampaignActivity: IAggregateRoot, ICampaignActivity
    {
        private readonly ICampaignRepository campaignRepository;
        private readonly ITemplateRepository templateRepository;
        private readonly ICustomersService customersService;
        private readonly INotificationsService notificationsService;

        public CampaignActivity(
            ICampaignRepository campaignRepository,
            ITemplateRepository templateRepository,
            ICustomersService customersService,
            INotificationsService notificationsService)
        {
            this.campaignRepository = campaignRepository;
            this.templateRepository = templateRepository;
            this.customersService = customersService;
            this.notificationsService = notificationsService;
        }

        public async Task CreateAsync(Guid campaignId)
        {
            
        }
    }
}
