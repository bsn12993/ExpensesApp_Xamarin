using ExpensesApp.Helpers;
using ExpensesApp.Models;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ImageSource = Xamarin.Forms.ImageSource;

namespace ExpensesApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private CameraHelper CameraHelper;
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

        public ImageSource Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
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
        private ImageSource image;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ProfileViewModel()
        {
            Image = "profile.png";
        }

        public ProfileViewModel(FindUser user)
        {
            user = (user == null) ? MainViewModel.GetInstance().GetUser : user;
            this.Email = user.Email;
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Image = "profile.png";
            CameraHelper = new CameraHelper();
        }

        #endregion

        public ICommand UpdateUserCommand
        {
            get { return new RelayCommand(UpdateUser); }
        }

        public ICommand TakePhotoCommand
        {
            get { return new RelayCommand(TakePhotoMethod); }
        }

        public ICommand ChoosePhotoCommand
        {
            get { return new RelayCommand(ChoosePhotoMethod); }
        }

        private async void ChoosePhotoMethod()
        {
            var file = await CameraHelper.ChoosePhoto();
            if (file != null)
            {
                Image = ImageSource.FromStream(() => file.GetStream());
            }
        }

        private async void TakePhotoMethod()
        {
            var file = await CameraHelper.TakePhoto();
            if (file != null)
            {
                Image = ImageSource.FromStream(() => file.GetStream());
            }
        }

        private async void UpdateUser()
        {
            /*
            var id = MainViewModel.GetInstance().GetUser.User_Id;
            var name = MainViewModel.GetInstance().GetUser.Name;
            this.IsRunning = true;
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess) 
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", "Configura el acceso a internet", "Ok");
                return;
            }

            var user = new User
            {
                User_Id = MainViewModel.GetInstance().GetUser.User_Id,
                Name = this.Name,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password
            };

            var updateUser = await ApiServices.GetInstance().PutItem("api/users/update/", user, MainViewModel.GetInstance().GetUser.User_Id);
            if (!updateUser.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", updateUser.Message, "Ok");
                return;
            }

            this.IsRunning = false;
            var getUser = await ApiServices.GetInstance().GetItem<User>($"api/users/byid/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!getUser.IsSuccess)
            {
                return;
            }

            MainViewModel.GetInstance().GetUser = (User)getUser.Result;
            await Application.Current.MainPage.DisplayAlert("Success", updateUser.Message, "Ok");
            this.Name = MainViewModel.GetInstance().GetUser.Name;
            this.LastName = MainViewModel.GetInstance().GetUser.LastName;
            this.Email = MainViewModel.GetInstance().GetUser.Email;
            this.Password = MainViewModel.GetInstance().GetUser.Password;
            */
        }

         
    }
}
