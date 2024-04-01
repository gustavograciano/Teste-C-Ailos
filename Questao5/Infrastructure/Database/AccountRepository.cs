using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Infrastructure.Database
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDbConnection _dbConnection;

        public AccountRepository(string connectionString)
        {
            _dbConnection = new SqliteConnection(connectionString);
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM contacorrente WHERE idcontacorrente = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Account>(sql, new { Id = id });
        }
    }
}
