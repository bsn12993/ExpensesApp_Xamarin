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
            if (this.PageName.Equals("LoginPage"))
            {
                MainViewModel.GetInstance().GetUser = null;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (this.PageName.Equals("CategoriesPage")) 
            {
                if(MainViewModel.GetInstance().Category==null)
                    MainViewModel.GetInstance().Category = new CategoriesViewModel();
                MainViewModel.GetInstance().Category.LoadCategories();
                App.Navigator.PushAsync(new CategoriesPage());
            }
            else if (this.PageName.Equals("AddCategoryPage"))
            {
                MainViewModel.GetInstance().CategoryItem = new CategoryViewModel(new CategoryItem());
                App.Navigator.PushAsync(new AddCategoryPage());
            }
            else if (this.PageName.Equals("AddExpensePage"))
            {
                if (MainViewModel.GetInstance().Expense == null)
                    MainViewModel.GetInstance().Expense = new ExpenseViewModel();
                MainViewModel.GetInstance().Expense.LoadCategories();
                App.Navigator.PushAsync(new AddExpensePage());
            }
            else if (this.PageName.Equals("HistoryExpensesPage"))
            {
                if (MainViewModel.GetInstance().HistoryExpenses == null)
                    MainViewModel.GetInstance().HistoryExpenses = new HistoryExpensesViewModel();
                MainViewModel.GetInstance().HistoryExpenses.LoadExpensesHistory();
                App.Navigator.PushAsync(new HistoryExpensesPage());
            }
            else if (this.PageName.Equals("HistoryIncomesPage"))
            {
                App.Navigator.PushAsync(new HistoryIncomesPage());
            }
            else if (this.PageName.Equals("ProfilePage"))
            {
                MainViewModel.GetInstance().Profile = new ProfileViewModel(MainViewModel.GetInstance().GetUser);
                App.Navigator.PushAsync(new ProfilePage());
            }
            else if (this.PageName.Equals("ExpensesPage"))
            {
                if (MainViewModel.GetInstance().Expenses == null)
                    MainViewModel.GetInstance().Expenses = new ExpensesViewModel();
                MainViewModel.GetInstance().Expenses.LoadExpenses();
                App.Navigator.PushAsync(new EditExpensesPage());
            }
        }
        #endregion
    }
}
