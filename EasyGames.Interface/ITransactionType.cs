using EasyGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.Interface
{
    public interface ITransactionType
    {
        Task<List<TransactionType>> GetAllTransaction();
    }
}
