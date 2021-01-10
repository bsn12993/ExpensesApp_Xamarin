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
        public ObservableCollection<ExpenseItemSelectedViewModel> Expenses
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
        private ObservableCollection<ExpenseItemSelectedViewModel> expenses;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ExpenseListViewModel()
        {
            NoData = string.Empty;
            LoadExpenses();
        }
        #endregion

        #region Commands
        public ICommand GoToAddExpensePageCommand
        {
            get { return new RelayCommand(GoToAddPage); }
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
                var expenses_aux = expenses.Select(x => new ExpenseItemSelectedViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Category = x.Category,
                    Date = x.Date,
                    Description = x.Description
                });
                Expenses = new ObservableCollection<ExpenseItemSelectedViewModel>(expenses_aux);
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

        private void GoToAddPage()
        {
            if (MainViewModel.GetInstance().ExpenseItemViewModel == null)
                MainViewModel.GetInstance().ExpenseItemViewModel = new ExpenseItemViewModel();
            MainViewModel.GetInstance().ExpenseItemViewModel.LoadCategories();
            App.Navigator.PushAsync(new ExpenseItemPage());
        }
        #endregion
    }
}
