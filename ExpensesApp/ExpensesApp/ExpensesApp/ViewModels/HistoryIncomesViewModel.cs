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
    public class HistoryIncomesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Income> Incomes
        {
            get { return this.incomes; }
            set
            {
                if (this.incomes != value)
                {
                    this.incomes = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Incomes)));
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
        private ObservableCollection<Income> incomes;
        private decimal total;
        private bool isRunning;
        #endregion

        #region Constructors
        public HistoryIncomesViewModel()
        {
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public async void LoadIncomesHistory()
        {
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
        }
        #endregion
    }
}
