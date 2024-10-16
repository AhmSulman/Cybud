using Cybud_WPF_0._1.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Cybud_WPF_0._1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class FinanceViewModel
    {
        public ObservableCollection<FinanceTransaction> Transactions { get; set; }

        // Properties for new transaction entry
        public string NewTransactionType { get; set; } // "Income" or "Expense"
        public decimal NewTransactionAmount { get; set; }
        public string NewTransactionDescription { get; set; }

        // Command to add a new transaction
        public ICommand AddTransactionCommand { get; }

        // Constructor to initialize properties and set up command
        public FinanceViewModel()
        {
            // Initialize collection of transactions
            Transactions = new ObservableCollection<FinanceTransaction>();

            // Set up command with the action to add a transaction
            AddTransactionCommand = new RelayCommand(AddTransaction);
        }

        // Method that adds a new transaction to the list
        private void AddTransaction()
        {
            var newTransaction = new FinanceTransaction
            {
                Amount = NewTransactionAmount,
                TransactionType = NewTransactionType,
                Description = NewTransactionDescription
            };

            // Add the new transaction to the ObservableCollection
            Transactions.Add(newTransaction);

            // Clear input fields after adding the transaction
            NewTransactionAmount = 0;
            NewTransactionType = string.Empty;
            NewTransactionDescription = string.Empty;
        }
    }
}
