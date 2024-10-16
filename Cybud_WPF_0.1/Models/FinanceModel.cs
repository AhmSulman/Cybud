using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybud_WPF_0._1.Models
{
    [AddINotifyPropertyChangedInterface] // This adds automatic property change notification (Fody)
    public class FinanceTransaction
    {
        // The unique ID of the transaction
        public Guid Id { get; set; }

        // The amount of money involved in the transaction
        public decimal Amount { get; set; }

        // The type of transaction (Income or Expense)
        public string TransactionType { get; set; }

        // A short description of the transaction (e.g., "Salary", "Rent")
        public string Description { get; set; }

        // Constructor for initializing the FinanceTransaction object with default values
        public FinanceTransaction()
        {
            Id = Guid.NewGuid(); // Assigns a unique ID to each transaction
        }
    }
}