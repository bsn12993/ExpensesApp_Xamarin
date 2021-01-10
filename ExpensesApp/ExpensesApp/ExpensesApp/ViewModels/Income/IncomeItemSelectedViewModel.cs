using ExpensesApp.Models;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class IncomeItemSelectedViewModel : IncomeItem
    {
        #region Properties
        public ICommand GoToEditItemPageCommand
        {
            get { return new RelayCommand(GoToEditPage); }
        }
        #endregion

        #region Methods
        private void GoToEditPage()
        {
            IncomeItem income = this;
            MainViewModel.GetInstance().IncomeItemViewModel = new IncomeItemViewModel(income);
            App.Navigator.PushAsync(new IncomeItemPage());
        }
        #endregion
    }
}
