using ExpensesApp.Models;
using ExpensesApp.Services;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ExpenseItemViewModel> Expenses
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
        public string NoData
        {
            get { return this.noData; }
            set
            {
                if (this.noData != value)
                {
                    this.noData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.NoData)));
                }
            }
        }
        #endregion

        #region Attributes
        private bool isRunning;
        private string noData;
        private ObservableCollection<ExpenseItemViewModel> expenses;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ExpensesViewModel()
        {
            this.NoData = string.Empty;
            this.LoadExpenses();
        }
        #endregion

        #region Commands
        public ICommand AddExpenseCommand
        {
            get { return new RelayCommand(AddExpense); }
        }
        #endregion

        #region Methods
        public async void LoadExpenses()
        {
            this.IsRunning = true;
            this.Expenses = new ObservableCollection<ExpenseItemViewModel>();
            this.Expenses.Clear();
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            var expenses = await ApiServices.GetInstance().GetList<ExpenseItemViewModel>($"api/expenses/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!expenses.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            this.IsRunning = false;
            var lstExpenses = ((List<ExpenseItemViewModel>)expenses.Result).Select(x => new ExpenseItemViewModel
            {
                Amount = x.Amount,
                Date = x.Date.Split('T')[0],
                Category = x.Category
            });
            this.Expenses = new ObservableCollection<ExpenseItemViewModel>(lstExpenses);
            this.NoData = (this.Expenses.Count == 0) ? "No data" : "";
        }

        private void AddExpense()
        {
            if (MainViewModel.GetInstance().Expense == null)
                MainViewModel.GetInstance().Expense = new ExpenseViewModel();
            MainViewModel.GetInstance().Expense.LoadCategories();
            App.Navigator.PushAsync(new AddExpensePage());
        }
        #endregion
    }
}
