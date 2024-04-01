using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database
{
    public interface IAccountRepository
    {
        Task <Account> GetByIdAsync(Guid accountId);
    }
}