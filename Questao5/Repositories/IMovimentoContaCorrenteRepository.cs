using Questao5.Domain.Entities;

namespace Questao5.Repositories
{
    public interface IMovimentoContaCorrenteRepository
    {
        Task Inserir(MovimentacaoContaCorrente movimentacao);

        Task<IEnumerable<MovimentacaoContaCorrente>> ObterMovimentosPorContaCorrente(string idContaCorrente);

    }
}
