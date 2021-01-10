using ExpensesApp.Models.Expense;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class HistoryExpensesViewModel : INotifyPropertyChanged
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

        public decimal Total
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
        private decimal total;
        private bool isRunning;
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #endregion

        #region Constructors
        public HistoryExpensesViewModel()
        {
        }
        #endregion

        #region Methods
        public async void LoadExpensesHistory()
        {
            /*
            this.IsRunning = true;
            this.Expenses = new ObservableCollection<Expense>();
            this.Expenses.Clear();
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            var expenses = await ApiServices.GetInstance().GetList<Expense>($"api/expenses/history/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!expenses.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }
            var lstExpenses = ((List<Expense>)expenses.Result).Select(x => new Expense
            {
                Date = x.Date.Split('T')[0],
                Amount = x.Amount,
                Category = x.Category
            });
            this.IsRunning = false;
            this.Expenses = new ObservableCollection<Expense>((IEnumerable<Expense>)lstExpenses);
            this.Total = Expenses.Sum(x => x.Amount);
            */
            this.Expenses = new ObservableCollection<ExpenseItem>();
            for (var i = 1; i <= 20; i++)
            {
                this.Expenses.Add(new ExpenseItemSelectedViewModel
                {
                    Amount = i,
                    Date = DateTime.Now.ToShortDateString(),
                    Category = "Transporte"
                });
            }
        }
        #endregion
    }
}
