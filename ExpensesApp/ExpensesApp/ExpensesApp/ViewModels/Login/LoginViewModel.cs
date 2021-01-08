using ExpensesApp.Exceptions;
using ExpensesApp.Helpers;
using ExpensesApp.Models;
using ExpensesApp.Services.User;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
                }
                
            }
        }
        public string Pass
        {
            get { return pass; }
            set
            {
                if (pass != value)
                {
                    pass = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pass)));
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
        private string user { get; set; }
        private string pass { get; set; }
        private bool isRunning { get; set; }       
        #endregion

        #region Contructor
        public LoginViewModel()
        {
            this.IsRunning = false;
            this.User = "app@gmail.com";
            this.Pass = "123456";
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
            try
            {
                InternetConnectionHelper.GetInstance().CheckConnection();

                IsRunning = true;
                if(string.IsNullOrEmpty(this.User) || string.IsNullOrEmpty(this.Pass))
                {
                    IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "login", "Accept");
                    return;
                }

                var validateUser = await UserService.GetInstance().Login(User, Pass);
                if (validateUser.Code != (int)EnumCodeResponse.SUCCESS)
                {
                    IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Error", validateUser.Message, "Ok");
                    return;
                }
            
                Pass = string.Empty;
                IsRunning = false;

                var findUser = JsonConvert.DeserializeObject<FindUser>(validateUser.Result.ToString());
                MainViewModel.GetInstance().GetUser = findUser;
                MainViewModel.GetInstance().ProfileViewModel = new ProfileViewModel(MainViewModel.GetInstance().GetUser);

                MainViewModel.GetInstance().HomeViewModel = new HomeViewModel();
                MainViewModel.GetInstance().HomeViewModel.LoadCategories();
                MainViewModel.GetInstance().HomeViewModel.LoadTotal();

                Application.Current.MainPage = new MasterPage();
            }
            catch (ErrorResponseServerException e)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
            }
            catch (WarningResponseServerException e)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
            }
            catch(NoInternetConnectionException e)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
            }
            catch (Exception e)
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
            }
        }


        private void Register()
        {
            Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        #endregion
    }
}
