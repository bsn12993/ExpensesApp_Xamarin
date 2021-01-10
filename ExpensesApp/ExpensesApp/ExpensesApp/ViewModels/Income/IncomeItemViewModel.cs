using ExpensesApp.Exceptions;
using ExpensesApp.Models;
using ExpensesApp.Services.Income;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class IncomeItemViewModel : INotifyPropertyChanged
    {
        #region Properties
        public IncomeItem Income
        {
            get { return income; }
            set
            {
                if (income != value)
                {
                    income = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Income)));
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

        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                if (isEnable != value)
                {
                    isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnable)));
                }
            }
        }
        #endregion

        #region Attributes
        private IncomeItem income;
        private bool isRunning;
        private bool isEnable;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand IncomeCommand
        {
            get { return new RelayCommand(IncomeMethod); }
        }
        #endregion

        #region Constructor
        public IncomeItemViewModel()
        {
            Income = new IncomeItem();
        }

        public IncomeItemViewModel(IncomeItem income)
        {
            Income = income;
        }
        #endregion

        #region Methods
        private async void IncomeMethod()
        {
            try
            {
                IsRunning = true;
                IsEnable = false;
                //Create
                if (Income.Id == 0)
                {
                    var incomeItem = new IncomeItem
                    {
                        Date = Income.Date,
                        Amount=Income.Amount,
                        UserId = MainViewModel.GetInstance().GetUser.Id
                    };

                    var response = await IncomeService.GetInstance().Create(incomeItem);
                    if (response.Code != (int)EnumCodeResponse.SUCCESS)
                    {
                        IsRunning = false;
                        await Application.Current.MainPage.DisplayAlert("Advertencia", response.Message, "Aceptar");
                        return;
                    }
                    await Application.Current.MainPage.DisplayAlert("Exito", response.Message, "Aceptar");
                }
                //Edit
                else
                {
                    var incomeItem = new IncomeItem
                    {
                        Id = income.Id,
                        Date = Income.Date,
                        Amount = Income.Amount,
                        UserId = MainViewModel.GetInstance().GetUser.Id
                    };

                    var response = await IncomeService.GetInstance().Update(incomeItem);
                    if (response.Code != (int)EnumCodeResponse.SUCCESS)
                    {
                        IsRunning = false;
                        await Application.Current.MainPage.DisplayAlert("Advertencia", response.Message, "Aceptar");
                        return;
                    }
                    await Application.Current.MainPage.DisplayAlert("Exito", response.Message, "Aceptar");
                }

                IsRunning = false;
                IsEnable = true;
                Income.Amount = 0;
                income.Date = DateTime.Now;
                if (MainViewModel.GetInstance().IncomeListViewModel == null)
                    MainViewModel.GetInstance().IncomeListViewModel = new IncomeListViewModel();
                MainViewModel.GetInstance().IncomeListViewModel.LoadIncomeList();
                await App.Navigator.PopAsync();
            }
            catch (ErrorResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
            catch (WarningResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
        }
        #endregion
    }
}
