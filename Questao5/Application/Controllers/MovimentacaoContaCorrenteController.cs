using Microsoft.AspNetCore.Mvc;
using Questao5.Services;

namespace Questao5.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoContaCorrenteController : ControllerBase
    {
        private readonly MovimentacaoContaCorrenteService _movimentacaoService;

        public MovimentacaoContaCorrenteController(MovimentacaoContaCorrenteService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string idContaCorrente, decimal valor, char tipoMovimento)
        {
            var result = await _movimentacaoService.MovimentarContaCorrente( idContaCorrente,  valor,  tipoMovimento);
            return Ok(result);
        }
    }
}
