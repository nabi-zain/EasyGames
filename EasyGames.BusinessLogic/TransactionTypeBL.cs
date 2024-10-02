using EasyGames.Interface;
using EasyGames.Model;
using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace EasyGames.BusinessLogic
{
    public class TransactionTypeBL : ITransactionType
    {
        private readonly IConfiguration _config;
        public TransactionTypeBL(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<TransactionType>> GetAllTransaction()
        {
            const string sql = @"SELECT * FROM [dbZainNabiEasyGames].[dbo].[TransactionType]";
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<TransactionType>(sql, "").ToList();

        }
    }
}