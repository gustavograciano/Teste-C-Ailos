using Questao5.Domain.Entities;

namespace Questao5.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ObterPorId(string idContaCorrente);
    }
}
