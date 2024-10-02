using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGames.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public int TransactionTypeID { get; set; }
        public int ClientID { get; set; }
        public string? Comment { get; set; }
    }
}
