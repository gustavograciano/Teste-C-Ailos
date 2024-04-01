using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace Questao5.Application.Handlers
{
    public class MovementCommandHandler : IMovementCommandHandler
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IAccountRepository _accountRepository;

        public MovementCommandHandler(IMovementRepository movementRepository, IAccountRepository accountRepository)
        {
            _movementRepository = movementRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Guid> HandleAsync(PerformAccountMovementCommand command)
        {
            var account = await _accountRepository.GetByIdAsync(command.AccountId);
            if (account == null)
                throw new Exception("Invalid account.");

            if (!account.IsActive)
                throw new Exception("Inactive account.");

            if (command.Value <= 0)
                throw new Exception("Invalid value.");

            if (command.Type != MovementType.Credit && command.Type != MovementType.Debit)
                throw new Exception("Invalid movement type.");

            var movement = new Movement
            {
                Id = Guid.NewGuid(),
                AccountId = command.AccountId,
                Date = DateTime.UtcNow.ToString("dd/MM/yyyy"),
                Type = command.Type,
                Value = command.Type == MovementType.Credit ? command.Value : -command.Value
            };

            await _movementRepository.AddAsync(movement);
            return movement.Id;
        }
    }
}
