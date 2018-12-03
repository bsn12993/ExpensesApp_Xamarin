using ExpensesApp.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
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

        #region Constructor
        public ProfileViewModel()
        {
        }

        public ProfileViewModel(User user)
        {
            user = (user == null) ? MainViewModel.GetInstance().GetUser : user;
            this.Email = user.Email;
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Password = user.Password;
        }

        #endregion

        public ICommand UpdateUserCommand
        {
            get { return new RelayCommand(UpdateUser); }
        }

        private void UpdateUser()
        {
            var id = MainViewModel.GetInstance().GetUser.User_Id;
            var name = MainViewModel.GetInstance().GetUser.Name;


        }
    }
}
