using ExpensesApp.Models.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }
        #endregion

        #region Methods
        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (PageName.Equals("LoginPage"))
            {
                MainViewModel.GetInstance().GetUser = null;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (PageName.Equals("CategoryListPage")) 
            {
                if(MainViewModel.GetInstance().CategoryListViewModel == null)
                    MainViewModel.GetInstance().CategoryListViewModel = new CategoryListViewModel();
                MainViewModel.GetInstance().CategoryListViewModel.LoadCategoryList();
                App.Navigator.PushAsync(new CategoryListPage());
            }
            else if (PageName.Equals("HistoryExpensesPage"))
            {
                if (MainViewModel.GetInstance().HistoryExpenses == null)
                    MainViewModel.GetInstance().HistoryExpenses = new HistoryExpensesViewModel();
                MainViewModel.GetInstance().HistoryExpenses.LoadExpensesHistory();
                App.Navigator.PushAsync(new HistoryExpensesPage());
            }
            else if (PageName.Equals("IncomeListPage"))
            {
                if (MainViewModel.GetInstance().IncomeListViewModel == null)
                    MainViewModel.GetInstance().IncomeListViewModel = new IncomeListViewModel();
                MainViewModel.GetInstance().IncomeListViewModel.LoadIncomeList();
                App.Navigator.PushAsync(new IncomeListPage());
            }
            else if (PageName.Equals("ProfilePage"))
            {
                MainViewModel.GetInstance().ProfileViewModel = new ProfileViewModel(MainViewModel.GetInstance().GetUser);
                App.Navigator.PushAsync(new ProfilePage());
            }
            else if (PageName.Equals("ExpenseListPage"))
            {
                if (MainViewModel.GetInstance().ExpenseListViewModel == null)
                    MainViewModel.GetInstance().ExpenseListViewModel = new ExpenseListViewModel();
                MainViewModel.GetInstance().ExpenseListViewModel.LoadExpenses();
                App.Navigator.PushAsync(new ExpenseListPage());
            }
        }
        #endregion
    }
}
