using Microsoft.AspNetCore.Mvc;
using Questao5.Services;

namespace Questao5.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoContaCorrenteController : ControllerBase
    {
        private readonly SaldoContaCorrenteService _saldoService;

        public SaldoContaCorrenteController(SaldoContaCorrenteService saldoService)
        {
            _saldoService = saldoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string idContaCorrente)
        {
            var result = await _saldoService.ConsultarSaldoContaCorrente(idContaCorrente);
            return Ok(result);
        }
    }
}
