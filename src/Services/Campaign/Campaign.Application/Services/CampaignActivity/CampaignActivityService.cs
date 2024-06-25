using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services;
using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Application.Contracts.Services.NotificationsService;
using Campaign.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Campaign.Application.Aggregates.CampaignActivity;

public class CampaignActivityService: ICampaignActivityService
{
    private readonly ICampaignRepository campaignRepository;
    private readonly ITemplateRepository templateRepository;
    private readonly ICustomersService customersService;
    private readonly ICampaignActivityRepository campaignActivityRepository;
    private readonly INotificationsService notificationsService;
    private readonly IDateTimeService dateTimeService;
    private readonly ILogger<ICampaignActivityService> logger;

    public CampaignActivityService(
        ICampaignRepository campaignRepository,
        ITemplateRepository templateRepository,
        ICustomersService customersService,
        ICampaignActivityRepository campaignActivityRepository,
        INotificationsService notificationsService,
        IDateTimeService dateTimeService,
        ILogger<ICampaignActivityService> logger)
    {
        this.campaignRepository = campaignRepository;
        this.templateRepository = templateRepository;
        this.customersService = customersService;
        this.campaignActivityRepository = campaignActivityRepository;
        this.notificationsService = notificationsService;
        this.dateTimeService = dateTimeService;
        this.logger = logger;
    }

    public async Task CreateAsync(Guid campaignId)
    {
        logger.LogInformation($"Running {nameof(CampaignActivityService)} {{campaignId}}", campaignId);

        var allCampaigns = await campaignRepository.GetCampaignsWithTemplatesAsync();
        var currentCampaign = allCampaigns.FirstOrDefault(x => x.Id == campaignId);
        if (currentCampaign is null)
        {
            logger.LogError("Campaign {campaignId} does not exist at execution time", campaignId);
            return;
        }

        logger.LogInformation("Processing campaign {campaignId}", campaignId);

        var applicableCustomers = await customersService.GetCustomersAsync(currentCampaign.Query);
        applicableCustomers = await FilterApplicableCustomersAsync(allCampaigns, currentCampaign, applicableCustomers);

        logger.LogInformation("Evaluated customers to send notifications: {customers}", applicableCustomers.Select(x => x.Id).ToArray());

        await Task.WhenAll(
            applicableCustomers.Select(
                async c => await notificationsService.NotifyAsync(
                    new Notification(c.Id, Encoding.UTF8.GetString(currentCampaign.Template.Contents)))));

        logger.LogInformation($"Notifications are sent");
    }

    private async Task<IReadOnlyList<CustomerDto>> FilterApplicableCustomersAsync(IReadOnlyList<Domain.Entities.Campaign> allCampaigns, Domain.Entities.Campaign? currentCampaign, IReadOnlyList<CustomerDto> applicableCustomers)
    {
        var applicableCustomersIds = applicableCustomers.Select(x => x.Id).ToArray();
        logger.LogInformation("Received {customers} that match the campaign query", applicableCustomersIds);
        var todaySentCustomers = await campaignActivityRepository.GetAsync(
            x => applicableCustomersIds.Contains(x.TargetId) && x.CreatedDate.Date == dateTimeService.DateTime.Date);

        applicableCustomers = applicableCustomers.Where(c => !todaySentCustomers.Any(t => t.TargetId == c.Id)).ToList();
        applicableCustomers = applicableCustomers.Where(
            c => !allCampaigns.Any(x => x.DoesCustomerCorrespond(c) && x.IsMorePriorityThan(currentCampaign)))
            .ToList();
        return applicableCustomers;
    }
}
