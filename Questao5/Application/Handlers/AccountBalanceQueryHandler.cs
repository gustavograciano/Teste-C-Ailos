using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database;
using System;

namespace Questao5.Application.Handlers
{
    public class AccountBalanceQueryHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMovementRepository _movementRepository;

        public AccountBalanceQueryHandler(IAccountRepository accountRepository, IMovementRepository movementRepository)
        {
            _accountRepository = accountRepository;
            _movementRepository = movementRepository;
        }

        public async Task<Account> HandleAsync(Guid accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
                throw new Exception("Invalid account.");

            if (!account.IsActive)
                throw new Exception("Inactive account.");

            var movements = await _movementRepository.GetMovementsByAccountIdAsync(accountId);
            decimal balance = 0;
            foreach (var movement in movements)
            {
                balance += movement.Type == MovementType.Credit ? movement.Value : -movement.Value;
            }

            return new Account
            {
           
            };
        }
    }
}
