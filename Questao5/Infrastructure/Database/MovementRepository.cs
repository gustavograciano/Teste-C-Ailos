using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using System.Data;

namespace Questao5.Infrastructure.Database
{
    public class MovementRepository : IMovementRepository
    {
        private readonly IDbConnection _dbConnection;

        public MovementRepository(string connectionString)
        {
            _dbConnection = new SqliteConnection(connectionString);
        }

        public async Task AddAsync(Movement movement)
        {
            var sql = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@Id, @AccountId, @Date, @Type, @Value)";
            await _dbConnection.ExecuteAsync(sql, movement);
        }

        public async Task<List<Movement>> GetMovementsByAccountIdAsync(Guid accountId)
        {
            var sql = "SELECT * FROM movimento WHERE idcontacorrente = @AccountId";
            return (await _dbConnection.QueryAsync<Movement>(sql, new { AccountId = accountId })).ToList();
        }
    }
}
