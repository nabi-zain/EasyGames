using Dapper;
using EasyGames.Interface;
using EasyGames.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.BusinessLogic
{
    public class TransactionBL : ITransaction
    {
        private readonly IConfiguration _config;
        public TransactionBL(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<Transaction> GetTransactionById(int transactionID)
        {
            const string sql = "spGETTransactions";
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<Transaction>(sql, new { transactionID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public async Task<bool> Put(Transaction transaction)
        {
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<bool>("[dbZainNabiEasyGames].[dbo].[spUpdateComment]",
            new
            {
                transaction.TransactionID,
                transaction.Comment
            },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public async Task<bool> Post(TranscationTypeViewModel transaction)
        {
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<bool>("[dbZainNabiEasyGames].[dbo].[spUpdateClientBalance]",
            new
            {
                transaction.ClientID,
                transaction.Amount
            },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public async Task<bool> InsertNewTransaction(TranscationTypeViewModel transaction)
        {
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<bool>("[dbZainNabiEasyGames].[dbo].[InsertNewTransaction]",
            new
            {
                transaction.Transaction.Amount,
                transaction.TransactionTypeID,
                transaction.ClientID,
            },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
