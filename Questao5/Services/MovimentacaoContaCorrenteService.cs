using Questao5.Domain.Entities;
using Questao5.Repositories;

namespace Questao5.Services
{
    public class MovimentacaoContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentoContaCorrenteRepository _movimentoRepository;

        public MovimentacaoContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository, IMovimentoContaCorrenteRepository movimentoRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _movimentoRepository = movimentoRepository;
        }

        public async Task<MovimentacaoContaCorrente> MovimentarContaCorrente(string idContaCorrente, decimal valor, char tipoMovimento)
        {
            // Obter conta corrente
            var contaCorrente = await _contaCorrenteRepository.ObterPorId(idContaCorrente);
            if (contaCorrente == null)
                throw new ArgumentException("Conta corrente não encontrada", nameof(idContaCorrente));

            // Validar conta corrente ativa
            if (!contaCorrente.IsActive)
                throw new InvalidOperationException("Conta corrente está inativa");

            // Validar tipo de movimento
            if (tipoMovimento != 'C' && tipoMovimento != 'D')
                throw new ArgumentException("Tipo de movimento inválido", nameof(tipoMovimento));

            // Validar valor positivo
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser positivo", nameof(valor));

            // Registrar movimento
            var movimento = new MovimentacaoContaCorrente
            {
                IdMovimento = Guid.NewGuid().ToString(),
                IdContaCorrente = idContaCorrente,
                DataMovimento = DateTime.Now,
                TipoMovimento = tipoMovimento,
                Valor = valor
            };
            await _movimentoRepository.Inserir(movimento);

            return movimento;
        }
    }
}
