using ExpensesApp.Models;
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
        public ICommand SelectExpenseCommand
        {
            get { return new RelayCommand(SelectExpense); }
        }

        private void SelectExpense()
        {
            Application.Current.MainPage.DisplayAlert("aa", "aa", "Ok");
        }
    }
}
