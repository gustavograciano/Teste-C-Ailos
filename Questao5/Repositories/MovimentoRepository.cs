using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using System.Data.SqlClient;

namespace Questao5.Repositories
{
    public class MovimentoRepository : IMovimentoContaCorrenteRepository
    {
        private readonly string _connectionString;

        public MovimentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Inserir(MovimentacaoContaCorrente movimento)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(@"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) 
                                                VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)",
                                                new
                                                {
                                                    IdMovimento = movimento.IdMovimento,
                                                    IdContaCorrente = movimento.IdContaCorrente,
                                                    DataMovimento = movimento.DataMovimento,
                                                    TipoMovimento = movimento.TipoMovimento,
                                                    Valor = movimento.Valor
                                                });
            }
        }

        public async Task<IEnumerable<MovimentacaoContaCorrente>> ObterMovimentosPorContaCorrente(string idContaCorrente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<MovimentacaoContaCorrente>("SELECT * FROM movimento WHERE idcontacorrente = @IdContaCorrente", new { IdContaCorrente = idContaCorrente });
            }
        }
    }
}
