using AutoFixture;
using NSubstitute;
using AutoFixture.AutoNSubstitute;
using Campaign.Application.Aggregates.CampaignActivity;
using Campaign.Application.Contracts.Persistence;
using Campaign.Application.Contracts.Services;
using Campaign.Application.Contracts.Services.CustomersService;
using Campaign.Application.Contracts.Services.NotificationsService;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Linq.Expressions;

namespace Campaign.Application.Tests.Services.CampaignActivity
{
    [TestFixture]
    public class CampaignActivityServiceTests
    {
        private IFixture _fixture;
        private CampaignActivityService _sut;

        private ICampaignRepository _mockCampaignRepository;
        private ITemplateRepository _mockTemplateRepository;
        private ICustomersService _mockCustomersService;
        private ICampaignActivityRepository _mockCampaignActivityRepository;
        private INotificationsService _mockNotificationsService;
        private IDateTimeService _mockDateTimeService;
        private ILogger<ICampaignActivityService> _mockLogger;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());

            _mockCampaignRepository = _fixture.Freeze<ICampaignRepository>();
            _mockTemplateRepository = _fixture.Freeze<ITemplateRepository>();
            _mockCustomersService = _fixture.Freeze<ICustomersService>();
            _mockCampaignActivityRepository = _fixture.Freeze<ICampaignActivityRepository>();
            _mockNotificationsService = _fixture.Freeze<INotificationsService>();
            _mockDateTimeService = _fixture.Freeze<IDateTimeService>();
            _mockLogger = _fixture.Freeze<ILogger<ICampaignActivityService>>();

            _sut = _fixture.Create<CampaignActivityService>();
        }

        [Test]
        public async Task CreateAsync_ShouldSendNotifications()
        {
            // Arrange
            var campaignId = _fixture.Create<Guid>();
            var campaign = _fixture.Build<Domain.Entities.Campaign>()
                .With(c => c.Id, campaignId)
                .With(c => c.Template, _fixture.Build<Domain.Entities.Template>()
                    .With(t => t.Contents, Encoding.UTF8.GetBytes("Test Message"))
                    .Create())
                .Create();
            var customers = _fixture.CreateMany<Domain.Entities.CustomerDto>(3).ToList();
            var emptyActivities = new List<Domain.Entities.CampaignActivity>();

            _mockCampaignRepository.GetCampaignsWithTemplatesAsync().Returns(new List<Domain.Entities.Campaign> { campaign });
            _mockCustomersService.GetCustomersAsync(campaign.Query).Returns(customers);
            _mockCampaignActivityRepository.GetAsync(Arg.Any<Expression<Func<Domain.Entities.CampaignActivity, bool>>>()).Returns(emptyActivities);

            // Act
            await _sut.CreateAsync(campaignId);

            // Assert
            await _mockNotificationsService.Received(customers.Count).NotifyAsync(Arg.Is<Notification>(n => customers.Any(c => c.Id == n.TargetId) && n.Contents == "Test Message"));
            _mockLogger.Received(1).LogInformation("Notifications are sent");
        }

        [Test]
        public async Task CreateAsync_ShouldNotSendNotifications_WhenHigherPriorityCampaignExists()
        {
            // Arrange
            var campaignId = _fixture.Create<Guid>();
            var campaign = _fixture.Build<Domain.Entities.Campaign>()
                .With(c => c.Id, campaignId)
                .With(c => c.Priority, 2)
                .With(c => c.Template, _fixture.Build<Domain.Entities.Template>()
                    .With(t => t.Contents, Encoding.UTF8.GetBytes("Test Message"))
                    .Create())
                .Create();

            var higherPriorityCampaign = _fixture.Build<Domain.Entities.Campaign>()
                    .With(c => c.Id, Guid.NewGuid())
                    .With(c => c.Priority, 1)
                    .With(c => c.Template, _fixture.Build<Domain.Entities.Template>()
                        .With(t => t.Contents, Encoding.UTF8.GetBytes("Higher Priority"))
                        .Create())
                    .Create();

            var customers = _fixture.CreateMany<Domain.Entities.CustomerDto>(3).ToList();
            var emptyActivities = new List<Domain.Entities.CampaignActivity>();

            _mockCampaignRepository.GetCampaignsWithTemplatesAsync().Returns(new List<Domain.Entities.Campaign> { campaign, higherPriorityCampaign });
            _mockCustomersService.GetCustomersAsync(campaign.Query).Returns(customers);
            _mockCampaignActivityRepository.GetAsync(Arg.Any<Expression<Func<Domain.Entities.CampaignActivity, bool>>>()).Returns(emptyActivities);

            // Act
            await _sut.CreateAsync(campaignId);

            // Assert
            await _mockNotificationsService.DidNotReceive().NotifyAsync(Arg.Any<Notification>());
        }

        [Test]
        public async Task CreateAsync_ShouldNotSendNotifications_WhenCampaignDoesNotExist()
        {
            // Arrange
            var campaignId = _fixture.Create<Guid>();
            var emptyCampaignList = new List<Domain.Entities.Campaign>();

            _mockCampaignRepository.GetCampaignsWithTemplatesAsync().Returns(emptyCampaignList);

            // Act
            await _sut.CreateAsync(campaignId);

            // Assert
            await _mockNotificationsService.DidNotReceive().NotifyAsync(Arg.Any<Notification>());
        }
    }
}