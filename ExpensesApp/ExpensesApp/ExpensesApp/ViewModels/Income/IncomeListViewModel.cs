using ExpensesApp.Exceptions;
using ExpensesApp.Helpers;
using ExpensesApp.Services.Income;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class IncomeListViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<IncomeItemSelectedViewModel> Incomes
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
        private ObservableCollection<IncomeItemSelectedViewModel> incomes;
        private decimal total;
        private bool isRunning;
        #endregion

        #region Constructors
        public IncomeListViewModel()
        {
            LoadIncomeList();
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        public async void LoadIncomeList()
        {
            try
            {
                InternetConnectionHelper.GetInstance().CheckConnection();
                IsRunning = true;
                var user = MainViewModel.GetInstance().GetUser;
                var incomes = await IncomeService
                    .GetInstance()
                    .FindAllByUser(user.Id);

                var incomes_aux = incomes
                    .Select(x => new IncomeItemSelectedViewModel
                    {
                        Id = x.Id,
                        Amount = x.Amount,
                        Date = x.Date
                    });
                Incomes =
                new ObservableCollection<IncomeItemSelectedViewModel>(incomes_aux);
                IsRunning = false;
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
                IsRunning = false;
            }
        }

        public ICommand GoToAddIncomePageCommand
        {
            get { return new RelayCommand(GoToAddPage); }
        }

        private void GoToAddPage()
        {
            MainViewModel.GetInstance().IncomeItemViewModel = new IncomeItemViewModel();
            App.Navigator.PushAsync(new IncomeItemPage());
        }
        #endregion
    }
}
