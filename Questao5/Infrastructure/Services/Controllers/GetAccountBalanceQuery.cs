namespace Questao5.Infrastructure.Services.Controllers
{
    internal class GetAccountBalanceQuery
    {
        private Guid accountId;

        public GetAccountBalanceQuery(Guid accountId)
        {
            this.accountId = accountId;
        }
    }
}