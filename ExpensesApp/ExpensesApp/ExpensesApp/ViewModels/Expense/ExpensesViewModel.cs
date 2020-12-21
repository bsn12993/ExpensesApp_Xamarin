using ExpensesApp.Services.Expense;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class ExpensesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ExpenseItemViewModel> Expenses
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
        public string NoData
        {
            get { return noData; }
            set
            {
                if (noData != value)
                {
                    noData = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoData)));
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
        public void LoadExpenses()
        {
            var expenses = ExpenseService.GetInstance().FindAll();
            var expenses_aux = expenses.Select(x => new ExpenseItemViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                Category = x.Category,
                Date = x.Date,
                Description = x.Description
            });
            Expenses = new ObservableCollection<ExpenseItemViewModel>(expenses_aux);
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
