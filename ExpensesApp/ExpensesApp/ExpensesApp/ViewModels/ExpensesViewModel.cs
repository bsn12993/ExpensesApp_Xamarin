using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        public ObservableCollection<ExpenseItemViewModel> Expenses { get; set; }

        public ExpensesViewModel()
        {
            this.Expenses = new ObservableCollection<ExpenseItemViewModel>();
            this.Expenses.Add(new ExpenseItemViewModel
            {
                Category = new Category { Id_Category = 1, Name = "Gasolina" },
                id_Expense = 1,
                Mount = 11M,
                Date = DateTime.Now.Date.ToShortDateString()
            });
        }
    }
}
