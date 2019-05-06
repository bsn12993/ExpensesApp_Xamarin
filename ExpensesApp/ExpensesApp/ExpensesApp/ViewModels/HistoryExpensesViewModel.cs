using ExpensesApp.Models;
using ExpensesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class HistoryExpensesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Expense> Expenses
        {
            get { return this.expenses; }
            set
            {
                if (this.expenses != value)
                {
                    this.expenses = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Expenses)));
                }
            }
        }

        public decimal Total
        {
            get { return this.total; }
            set
            {
                if (this.total != value)
                {
                    this.total = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Total)));
                }
            }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        private ObservableCollection<Expense> expenses;
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
        }
        #endregion
    }
}
