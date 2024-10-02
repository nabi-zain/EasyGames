using EasyGames.BusinessLogic;
using EasyGames.Interface;
using EasyGames.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Transactions;
using Transaction = EasyGames.Model.Transaction;

namespace EasyGames.ClientTransactions.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClient _clientBl;
        private readonly ITransaction _transactionBL;
        private readonly ITransactionType _transactionTypeBL;

        public ClientController(IClient clientBL, ITransaction transaction, ITransactionType transactionType) {
            _clientBl = clientBL;
            _transactionBL  = transaction;
            _transactionTypeBL = transactionType;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _clientBl.GetAllClients());
        }

        [HttpGet]
        public async Task<IActionResult> Transactions(int ClientID)
        {
            return View(await _clientBl.GetClientById(ClientID));
        }

        [HttpGet]
        public async Task<IActionResult> Editcomment(int TransactionID)
        {
            return View(await _transactionBL.GetTransactionById(TransactionID));
        }

        [HttpPost]
        public async Task<IActionResult> Editcomment(Transaction transaction)
        {
            await _transactionBL.Put(transaction);
            return RedirectToAction("Transactions", "Client", new { ClientID = transaction.ClientID });
        }

        [HttpGet]
        public async Task<IActionResult> Newtransaction(int ClientID)
        {
              var Model = new TranscationTypeViewModel()
                {
                    ClientID = ClientID,
                    TransactionTypes = new SelectList(await _transactionTypeBL.GetAllTransaction(), "TransactionTypeID", "TransactionTypeName")
                    
                };
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Newtransaction(TranscationTypeViewModel model)
        {
            var clients = await _clientBl.GetAllClients();
            var selectedClientbalance = clients.Where(x => x.ClientID == model.ClientID).FirstOrDefault();
            selectedClientbalance.ClientBalance += model.Transaction.Amount;
            await _transactionBL.InsertNewTransaction(model);
            model.Amount = selectedClientbalance.ClientBalance;

            await _transactionBL.Post(model);
            return RedirectToAction("Index", "Client");
        }
    }
}
