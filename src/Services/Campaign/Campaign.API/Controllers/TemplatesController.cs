using Campaign.Application.Features.Campaigns.Queries.GetCampaigns;
using Campaign.Application.Features.Templates.Commands.CreateTemplate;
using Campaign.Application.Features.Templates.Commands.DeleteTemplate;
using Campaign.Application.Features.Templates.Queries.GetTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class TemplatesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TemplatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> GetTemplates()
    {
        var result = await _mediator.Send(new TemplateQuery());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CreateTemplate([FromBody] CreateTemplateCommand data)
    {
        var result = await _mediator.Send(data);
        return Ok(result);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(CampaignDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteTemplate(Guid id)
    {
        var result = await _mediator.Send(new DeleteTemplateCommand { Id = id });
        return Ok(result);
    }
}
