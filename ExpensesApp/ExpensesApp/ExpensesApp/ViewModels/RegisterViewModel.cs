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
        #endregion

        #region Attributes
        private string name;
        private string lastName;
        private string user;
        private string email;
        private string password;

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
            if(!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.lastName) && !string.IsNullOrEmpty(this.User)
                && !string.IsNullOrEmpty(this.Password) && !string.IsNullOrEmpty(this.Email))
            {
                var insert = new DataService().Insert(new UserLocal
                {
                    Name = this.Name,
                    LastName = this.LastName,
                    User = this.User,
                    Password = this.Password,
                    Email = this.Email
                });

                Application.Current.MainPage.DisplayAlert("Success", "Se ha registrado " + insert.FullName, "Ok");
            }
        }
        #endregion
    }
}
