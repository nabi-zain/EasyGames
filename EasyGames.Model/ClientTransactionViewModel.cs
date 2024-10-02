using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.Model
{
    public class ClientTransactionViewModel
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal ClientBalance { get; set; }
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string transactiontypename { get; set; }
        public string? Comment { get; set; }
    }

    public class TranscationTypeViewModel
    {

        public IEnumerable<SelectListItem> TransactionTypes { get; set; }
        public int TransactionTypeID { get; set; }
        public Transaction Transaction { get; set; }
        public int ClientID { get; set; }
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
