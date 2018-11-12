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
    public class RegisterViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
                }
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.LastName)));
                }
            }
        }

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

        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Email)));
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

        public bool IsVisible
        {
            get { return this.isVisible; }
            set
            {
                if (this.isVisible != value)
                {
                    this.isVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsVisible)));
                }
            }
        }
        #endregion

        #region Attributes
        private string name;
        private string lastName;
        private string user;
        private string email;
        private string password;
        private bool isRunning;
        private bool isVisible;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand SaveUserCommand
        {
            get
            {
                return new RelayCommand(SaveUser);
            }
        }

        private void SaveUser()
        {
            if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.lastName) && !string.IsNullOrEmpty(this.User)
                && !string.IsNullOrEmpty(this.Password) && !string.IsNullOrEmpty(this.Email))
            {

                //var insert = new DataService().Insert(new UserLocal
                //{
                //    Name = this.Name,
                //    LastName = this.LastName,
                //    User = this.User,
                //    Password = this.Password,
                //    Email = this.Email
                //});
                this.IsRunning = true;
                this.IsVisible = true;
                Application.Current.MainPage.DisplayAlert("Success", "Se ha registrado ", "Ok");
                this.Name = string.Empty;
                this.LastName = string.Empty;
                this.Email = string.Empty;
                this.Password = string.Empty;
            }
            else Application.Current.MainPage.DisplayAlert("Error", "Campos vacios", "Ok");
            this.IsRunning = false;
            this.IsVisible = false;
        }
        #endregion
    }
}
