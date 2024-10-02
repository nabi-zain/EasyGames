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
    public class ClientBL : IClient
    {

        private readonly IConfiguration _config;
        public ClientBL(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Client>> GetAllClients()
        {
            string sql = @"SELECT * FROM [dbZainNabiEasyGames].[dbo].[Client]";
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<Client>(sql, "").ToList();
        }

        public async Task<List<ClientTransactionViewModel>> GetClientById(int ClientID)
        {
            const string sql = "spGETClientTransactions";
            await using var connection = DBConnection.GetOpenConnection(_config.GetConnectionString("dbZainNabiEasyGames"));
            return connection.Query<ClientTransactionViewModel>(sql, new { ClientID }, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
