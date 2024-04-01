using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database
{
    public interface IMovementRepository
    {
        Task AddAsync(Movement movement);
        Task<List<Movement>> GetMovementsByAccountIdAsync(Guid accountId);
    }
}