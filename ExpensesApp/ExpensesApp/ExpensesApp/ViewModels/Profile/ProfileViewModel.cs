using ExpensesApp.Exceptions;
using ExpensesApp.Helpers;
using ExpensesApp.Models;
using ExpensesApp.Models.User;
using ExpensesApp.Services.User;
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

        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                if (isEnable != value)
                {
                    isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnable)));
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
        private bool isEnable;
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
            try
            {
                IsRunning = true;
                IsEnable = false;
                var updateUser = new UpdateUser
                {
                    Id = MainViewModel.GetInstance().GetUser.Id,
                    Email = Email,
                    Name = Name,
                    LastName = LastName,
                    Image = FileHelper.ImageSourceToBase64(Image)
                };

                var response = await UserService.GetInstance().Update(updateUser);
                if (response.Code != (int)EnumCodeResponse.SUCCESS)
                {
                    IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Advertencia", response.Message, "Aceptar");
                    return;
                }
                await Application.Current.MainPage.DisplayAlert("Exito", response.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
              
            }
            catch (ErrorResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
            catch (WarningResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
                IsRunning = false;
                IsEnable = true;
            }
        }

         
    }
}
