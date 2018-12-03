using ExpensesApp.Models;
using ExpensesApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class IncomeViewModel : INotifyPropertyChanged
    {
        public string Income
        {
            get { return this.income; }
            set
            {
                if (this.income != value)
                {
                    this.income = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Income)));
                }
            }
        }

        private string income;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveIncomeCommand
        {
            get { return new RelayCommand(SaveIncome); }
        }

        private async void SaveIncome()
        {
            var income = new Income
            {
                Amount = Convert.ToDecimal(this.Income),
                Date = DateTime.Now,
                User_Id = MainViewModel.GetInstance().GetUser.User_Id
            };
            var registerIncome = await ApiServices.GetInstance().PostItem("api/incomes/create", income);
            if (!registerIncome.IsSuccess)
            {
                return;
            }
            MainViewModel.GetInstance().Home.LoadTotal();
            await Application.Current.MainPage.DisplayAlert("Ok", "Income", "Accept");
            this.Income = string.Empty;
        }
    }
}
