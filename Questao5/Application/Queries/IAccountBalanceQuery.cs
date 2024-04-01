using Questao5.Domain.Entities;

namespace Questao5.Application.Queries
{
    public interface IAccountBalanceQuery
    {
        Task<Account> ExecuteAsync(Guid accountId);
    }
}
