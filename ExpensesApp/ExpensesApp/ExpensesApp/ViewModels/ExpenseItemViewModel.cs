using ExpensesApp.Models;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpenseItemViewModel : Expense
    {
        #region Properties
        public ICommand SelectExpenseCommand
        {
            get { return new RelayCommand(SelectExpense); }
        }
        #endregion

        #region Methods
        private void SelectExpense()
        {
            MainViewModel.GetInstance().ExpenseDetail = new ExpenseDetailViewModel(this);
            App.Navigator.PushAsync(new ExpenseDetailPage());
        }
        #endregion
    }
}
