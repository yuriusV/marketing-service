using Campaign.Application.Features.Campaigns.Commands.CreateCampaign;
using Campaign.Application.Features.Campaigns.Commands.DeleteCampaign;
using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CampaignsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CampaignsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetCampaigns()
    {
        var result = await _mediator.Send(new CampaignQuery());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CreateCampaign([FromBody] CreateCampaignCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteCampaign(Guid id)
    {
        var result = await _mediator.Send(new DeleteCampaignCommand { Id = id });
        return Ok(result);
    }
}
