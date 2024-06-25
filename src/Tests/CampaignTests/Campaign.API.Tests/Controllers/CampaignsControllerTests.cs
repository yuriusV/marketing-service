using AutoFixture.AutoNSubstitute;
using AutoFixture;
using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Customer.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;

namespace Campaign.API.Tests.Controllers
{
    [TestFixture]
    public class CampaignsControllerTests
    {
        private IFixture _fixture;
        private IMediator _mediator;
        private CampaignsController _sut;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            _mediator = _fixture.Freeze<IMediator>();
            _sut = new CampaignsController(_mediator);
        }

        [Test]
        public async Task GetCampaigns_ShouldReturnOkResult_WithCampaignDto()
        {
            // Arrange
            var campaignDtos = _fixture.CreateMany<CampaignDto>(3);
            _mediator.Send(Arg.Any<CampaignQuery>()).Returns(campaignDtos.ToList());

            // Act
            var result = await _sut.GetCampaigns();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(campaignDtos);
        }

        [Test]
        public async Task CreateCampaign_ShouldReturnOkResult_WithCampaignDto()
        {
            // Arrange
            var createCommand = _fixture.Create<CreateCampaignCommand>();
            var campaignDto = _fixture.Create<CampaignDto>();
            _mediator.Send(createCommand).Returns(campaignDto);

            // Act
            var result = await _sut.CreateCampaign(createCommand);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(campaignDto);
        }

        [Test]
        public async Task DeleteCampaign_ShouldReturnOkResult_WithCampaignDto()
        {
            // Arrange
            var campaignId = _fixture.Create<Guid>();
            var campaignDto = _fixture.Create<CampaignDto>();
            _mediator.Send(Arg.Any<DeleteCampaignCommand>()).Returns(campaignDto);

            // Act
            var result = await _sut.DeleteCampaign(campaignId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            okResult.Value.Should().BeEquivalentTo(campaignDto);
        }
    }
}
