using ExpensesApp.Models;
using ExpensesApp.Services;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
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
        private ApiServices ApiServices = null;
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRunning = false;
            this.User = "aa";
            this.Pass = "aa";
            ApiServices = new ApiServices();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

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
            if(string.IsNullOrEmpty(this.User) || string.IsNullOrEmpty(this.Pass))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "login", "Accept");
                return;
            }

            var connectivity = await ApiServices.CheckConnection();
            if (connectivity.IsSuccess)
            {

            }
            var api = ApiServices.GetList<object>("http://192.168.15.10:8082", "api/", "users/all");

            this.IsRunning = true;
            this.Pass = string.Empty;
            this.IsRunning = false;
            MainViewModel.GetInstance().LoadCategories();
            Application.Current.MainPage = new MasterPage();
        }


        private void Register()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        #endregion
    }
}
