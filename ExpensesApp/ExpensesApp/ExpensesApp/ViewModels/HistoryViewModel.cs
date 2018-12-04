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
    public class HistoryViewModel : INotifyPropertyChanged
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
        #endregion

        #region Attributes
        public ObservableCollection<Expense> expenses;
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #endregion

        #region Constructors
        public HistoryViewModel()
        {
            LoadExpensesHistory();
        }
        #endregion

        #region Methods
        public async void LoadExpensesHistory()
        {
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            var expenses = await ApiServices.GetInstance().GetList<Expense>($"api/expenses/history/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!expenses.IsSuccess)
            {
                return;
            }
            var lstExpenses = ((List<Expense>)expenses.Result).Select(x => new Expense
            {
                Date = x.Date.Split('T')[0],
                Amount = x.Amount,
                Category = x.Category
            });
            this.Expenses = new ObservableCollection<Expense>((IEnumerable<Expense>)lstExpenses);
        }
        #endregion
    }
}
