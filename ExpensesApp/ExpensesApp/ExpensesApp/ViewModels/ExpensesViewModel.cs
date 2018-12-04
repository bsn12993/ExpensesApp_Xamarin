using ExpensesApp.Models;
using ExpensesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel
    {
        #region Properties
        public ObservableCollection<ExpenseItemViewModel> Expenses { get; set; }
        #endregion

        #region Constructor
        public ExpensesViewModel()
        {
            //this.Expenses = new ObservableCollection<ExpenseItemViewModel>();
            //this.Expenses.Add(new ExpenseItemViewModel
            //{
            //    Category = new Category { Category_Id = 1, Name = "Gasolina" },
            //    id_Expense = 1,
            //    Amount = 11M,
            //    Date = DateTime.Now.Date.ToShortDateString()
            //});
            LoadExpenses();
        }
        #endregion

        #region Methods
        public async void LoadExpenses()
        {
            var expenses = await ApiServices.GetInstance().GetList<ExpenseItemViewModel>("api/expenses/all");
            if (!expenses.IsSuccess)
            {
                return;
            }
            var lstExpenses = ((List<ExpenseItemViewModel>)expenses.Result).Select(x => new ExpenseItemViewModel
            {
                Amount = x.Amount,
                Date = x.Date.Split('T')[0],
                Category = x.Category
            });
            this.Expenses = new ObservableCollection<ExpenseItemViewModel>(lstExpenses);
        }
        #endregion
    }
}
