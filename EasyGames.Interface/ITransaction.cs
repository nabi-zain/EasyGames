using EasyGames.Model;
using System.Data.Common;
using System.Transactions;
using Transaction = EasyGames.Model.Transaction;

namespace EasyGames.Interface
{
    public interface ITransaction
    {
        Task<bool> Put(Transaction transaction);
        Task<Transaction> GetTransactionById(int Id);
        Task<bool> Post(TranscationTypeViewModel transaction);
        Task<bool> InsertNewTransaction(TranscationTypeViewModel transaction);
    }
}