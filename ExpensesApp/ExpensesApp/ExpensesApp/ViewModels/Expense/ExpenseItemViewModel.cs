using ExpensesApp.Models.Expense;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class ExpenseItemViewModel : ExpenseItem
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
