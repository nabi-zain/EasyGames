using EasyGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.Interface
{
    public  interface IClient
    {
        Task<List<ClientTransactionViewModel>> GetClientById(int ClientID);
        Task<List<Client>> GetAllClients();
    }
}
