using ExpensesApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpensesApp.ViewModels
{
    public class IncomeListViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<IncomeItem> Incomes
        {
            get { return incomes; }
            set
            {
                if (incomes != value)
                {
                    incomes = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Incomes)));
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
        private ObservableCollection<IncomeItem> incomes;
        private decimal total;
        private bool isRunning;
        #endregion

        #region Constructors
        public IncomeListViewModel()
        {
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public async void LoadIncomesHistory()
        {
            /*
            this.IsRunning = true;
            this.Incomes = new ObservableCollection<Income>();
            this.Incomes.Clear();
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            var incomes = await ApiServices.GetInstance().GetList<Income>($"api/incomes/history/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!incomes.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            var expenses = await ApiServices.GetInstance().GetList<Expense>($"api/expenses/history/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!expenses.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            var lstIncomes = ((List<Income>)incomes.Result).Select(x => new Income
            {
                Date = x.Date.Split('T')[0],
                Amount = x.Amount
            });

            this.IsRunning = false;
            this.Incomes = new ObservableCollection<Income>((IEnumerable<Income>)lstIncomes);
            var totalExpenses = ((List<Expense>)expenses.Result).Sum(x => x.Amount);
            this.Total = this.Incomes.Sum(x => x.Amount) - totalExpenses;
            */
            this.Incomes = new ObservableCollection<IncomeItem>();
            for (var i = 1; i <= 20; i++)
            {
                this.Incomes.Add(new IncomeItem
                {
                    Amount = i,
                    Date = DateTime.Now.ToShortDateString(),
                    Income_Id = 1,
                    User_Id = 1
                });
            }

        }
        #endregion
    }
}
