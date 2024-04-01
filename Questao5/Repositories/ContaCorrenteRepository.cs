using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using System.Data.SqlClient;

namespace Questao5.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly string _connectionString;

        public ContaCorrenteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<ContaCorrente> ObterPorId(string idContaCorrente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var conta = await connection.QueryFirstOrDefaultAsync<ContaCorrente>("select * from contacorrente where idcontacorrente = @Id", new { Id = idContaCorrente });
                return conta;
            }
        }
    }
}
