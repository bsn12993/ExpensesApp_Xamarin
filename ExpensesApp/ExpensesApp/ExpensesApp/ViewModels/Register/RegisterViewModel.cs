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
