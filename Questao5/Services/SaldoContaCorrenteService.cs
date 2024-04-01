using Questao5.Repositories;

namespace Questao5.Services
{
    public class SaldoContaCorrenteService
    {
        private readonly IMovimentoContaCorrenteRepository _movimentoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public SaldoContaCorrenteService(IMovimentoContaCorrenteRepository movimentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<decimal> ConsultarSaldoContaCorrente(string idContaCorrente)
        {
            // Obter conta corrente
            var contaCorrente = await _contaCorrenteRepository.ObterPorId(idContaCorrente);
            if (contaCorrente == null)
                throw new ArgumentException("Conta corrente não encontrada", nameof(idContaCorrente));

            // Validar conta corrente ativa
            if (!contaCorrente.IsActive)
                throw new InvalidOperationException("Conta corrente está inativa");

            // Obter movimentos da conta corrente
            var movimentos = await _movimentoRepository.ObterMovimentosPorContaCorrente(idContaCorrente);

            // Calcular saldo
            var saldo = movimentos.Sum(m => m.TipoMovimento == 'C' ? m.Valor : -m.Valor);
            return saldo;
        }
    }
}
