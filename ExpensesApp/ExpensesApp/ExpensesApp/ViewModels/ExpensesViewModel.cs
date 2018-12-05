using ExpensesApp.Models;
using ExpensesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

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

        }
        #endregion

        #region Methods
        public async void LoadExpenses()
        {
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

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
