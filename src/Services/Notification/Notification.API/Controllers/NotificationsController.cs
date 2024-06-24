
using Notification.Application.Features.Notifications.Commands.CreateNotification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create([FromBody] CreateNotificationCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
