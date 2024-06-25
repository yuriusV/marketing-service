using Customer.Application.Features.Customers.Queries.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CustomersSearchesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersSearchesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> SearchCustomers([FromBody]CustomerQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
