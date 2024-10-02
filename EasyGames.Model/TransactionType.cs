using System.ComponentModel.DataAnnotations;

namespace EasyGames.Model
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
    }
}