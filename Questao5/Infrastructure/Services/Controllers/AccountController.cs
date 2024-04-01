using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries;
using System;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountId}/balance")]
        public async Task<IActionResult> GetAccountBalanceQuery(Guid accountId)
        {
            var query = new GetAccountBalanceQuery(accountId);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
