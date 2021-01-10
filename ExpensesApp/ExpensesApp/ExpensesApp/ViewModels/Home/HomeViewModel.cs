using ExpensesApp.Models.Expense;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ExpenseItem> Expenses
        {
            get { return expenses; }
            set
            {
                if (expenses != value)
                {
                    expenses = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Expenses)));
                }
            }
        }

        public string Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                }
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        private ObservableCollection<ExpenseItem> expenses;
        private string total;
        private bool isRunning;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public HomeViewModel()
        {
        }
        #endregion

        #region Commands
        public ICommand GoToIncomeListPageCommand
        {
            get { return new RelayCommand(GoToIncomePage); }
        }

        public ICommand GoToProfilePageCommand
        {
            get { return new RelayCommand(GoToProfilePage); }
        }

        public ICommand GoToExpenseListPageCommand
        {
            get { return new RelayCommand(GoToExpensePage); }
        }
        #endregion

        #region Methods
        public async void LoadTotal()
        {
            this.Total = "11";
        }

        private void GoToIncomePage()
        {
            if (MainViewModel.GetInstance().IncomeListViewModel == null)
                MainViewModel.GetInstance().IncomeListViewModel = new IncomeListViewModel();
            MainViewModel.GetInstance().IncomeListViewModel.LoadIncomeList();
            App.Navigator.PushAsync(new IncomeListPage());
        }

        private void GoToProfilePage()
        {
            MainViewModel.GetInstance().ProfileViewModel = new ProfileViewModel(MainViewModel.GetInstance().GetUser);
            App.Navigator.PushAsync(new ProfilePage());
        }

        private void GoToExpensePage()
        {
            if (MainViewModel.GetInstance().ExpenseListViewModel == null)
                MainViewModel.GetInstance().ExpenseListViewModel = new ExpenseListViewModel();
            MainViewModel.GetInstance().ExpenseListViewModel.LoadExpenses();
            App.Navigator.PushAsync(new ExpenseListPage());
        }
        #endregion
    }
}
