using ExpensesApp.Helpers;
using ExpensesApp.Models;
using ExpensesApp.Services;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string User
        {
            get { return this.user; }
            set
            {
                if (this.user != value)
                {
                    this.user = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.User)));
                }
                
            }
        }
        public string Pass
        {
            get { return this.pass; }
            set
            {
                if (this.pass != value)
                {
                    this.pass = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Pass)));
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
        private string user { get; set; }
        private string pass { get; set; }
        private bool isRunning { get; set; }       
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRunning = false;
            this.User = "bsn_12903@hotmail.com";
            this.Pass = "bsn12993*";
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }
        #endregion

        #region Methods
        public async void Login()
        {
            this.IsRunning = true;
            if(string.IsNullOrEmpty(this.User) || string.IsNullOrEmpty(this.Pass))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "login", "Accept");
                this.IsRunning = false;
                return;
            }

            var connectivity = await ApiServices.GetInstance().CheckConnection();
            if (!connectivity.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Configura el acceso a internet", "Ok");
                this.IsRunning = false;
                return;
            }

            var validateUser = await ApiServices.GetInstance()
                .GetItem<User>($"api/users/validate/{this.User.Encrypt()}/{this.Pass.Encrypt()}");
            if (!validateUser.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", validateUser.Message, "Ok");
                this.IsRunning = false;
                return;
            }

            this.Pass = string.Empty;
            this.IsRunning = false;
            MainViewModel.GetInstance().GetUser = (User)validateUser.Result;
            MainViewModel.GetInstance().Profile = new ProfileViewModel(MainViewModel.GetInstance().GetUser);
            MainViewModel.GetInstance().Home = new HomeViewModel();
            //MainViewModel.GetInstance().ExpenseDetail = new ExpenseDetailViewModel();
            MainViewModel.GetInstance().History = new HistoryViewModel();
            //MainViewModel.GetInstance().Categories = new ObservableCollection<Category>((List<Category>)category.Result);
            MainViewModel.GetInstance().Category = new CategoriesViewModel();
            MainViewModel.GetInstance().Expenses = new ExpensesViewModel();
            Application.Current.MainPage = new MasterPage();
        }


        private void Register()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        #endregion
    }
}
