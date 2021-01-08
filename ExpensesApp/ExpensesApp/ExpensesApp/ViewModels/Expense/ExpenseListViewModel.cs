using ExpensesApp.Exceptions;
using ExpensesApp.Helpers;
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
    public class ExpenseListViewModel : INotifyPropertyChanged
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
        public ExpenseListViewModel()
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
            try
            {
                InternetConnectionHelper.GetInstance().CheckConnection();

                var user = MainViewModel.GetInstance().GetUser;
                IsRunning = true;
                var expenses = await ExpenseService
                    .GetInstance()
                    .FindAllByUser(user.Id);
                IsRunning = false;
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
            catch (ErrorResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch (WarningResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch (NoInternetConnectionException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
            } 
        }

        private void AddExpense()
        {
            if (MainViewModel.GetInstance().AddExpenseViewModel == null)
                MainViewModel.GetInstance().AddExpenseViewModel = new AddExpenseViewModel();
            MainViewModel.GetInstance().AddExpenseViewModel.LoadCategories();
            App.Navigator.PushAsync(new AddExpensePage());
        }
        #endregion
    }
}
