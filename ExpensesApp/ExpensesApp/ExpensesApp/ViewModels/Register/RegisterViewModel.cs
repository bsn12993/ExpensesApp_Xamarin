using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                }
            }
        }

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

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
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

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsVisible)));
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

        public RegisterViewModel()
        {
        }

        #region Commands
        public ICommand SaveUserCommand
        {
            get
            {
                return new RelayCommand(SaveUser);
            }
        }
        #endregion

        #region Methods
        private async void SaveUser()
        {
            /*
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo Name esta vacio", "Ok");
                this.IsRunning = false;
                this.IsVisible = false;
                return;
            }
            if (string.IsNullOrEmpty(this.lastName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo LastName esta vacio", "Ok");
                this.IsRunning = false;
                this.IsVisible = false;
                return;
            }

            if (string.IsNullOrEmpty(this.User))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo User esta vacio", "Ok");
                this.IsRunning = false;
                this.IsVisible = false;
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo Password esta vacio", "Ok");
                this.IsRunning = false;
                this.IsVisible = false;
                return;
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El campo Email esta vacio", "Ok");
                this.IsRunning = false;
                this.IsVisible = false;
                return;
            }

            var user = new User
            {
                Name = this.Name,
                LastName = this.LastName,
                Password = this.Password,
                Email = this.Email
            };

            var connectivity = await ApiServices.GetInstance().CheckConnection();
            if (!connectivity.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Configura el acceso a internet", "Ok");
                this.IsRunning = false;
                return;
            }

            var registerUser = await ApiServices.GetInstance().PostItem($"api/users/create/", user);
            if (!registerUser.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", registerUser.Message, "Ok");
                return;
            }

            this.IsRunning = true;
            this.IsVisible = true;
            await Application.Current.MainPage.DisplayAlert("Success", "Se ha registrado ", "Ok");
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            */

        }
        #endregion
    }
}
