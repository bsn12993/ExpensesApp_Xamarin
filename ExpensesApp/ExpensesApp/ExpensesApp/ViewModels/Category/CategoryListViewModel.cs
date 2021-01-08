using ExpensesApp.Exceptions;
using ExpensesApp.Helpers;
using ExpensesApp.Services.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class CategoryListViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<CategoryItemSelectedViewModel> Categories
        {
            get { return categories; }
            set
            {
                if (categories != value)
                {
                    categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categories)));
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
        private ObservableCollection<CategoryItemSelectedViewModel> categories;
        private bool isRunning;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public CategoryListViewModel()
        {
        }
        #endregion

        #region Commands
        public ICommand AddCategoryCommand
        {
            get { return new RelayCommand(AddCategory); }
        }
        #endregion

        #region Methods
        /**
        public IEnumerable<CategoryItemViewModel> ToCategoryItemViewModel()
        {
            return MainViewModel.GetInstance().Categories.Select(c => new CategoryItemViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
        }
        **/

        public async void LoadCategories()
        {
            try
            {
                InternetConnectionHelper.GetInstance().CheckConnection();
                IsRunning = true;
                var user = MainViewModel.GetInstance().GetUser;
                var categories = await CategoryService
                    .GetInstance()
                    .FindAllByUser(user.Id);

                var categories_aux = categories
                    .Select(x => new CategoryItemSelectedViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UserId = x.UserId
                    });
                Categories =
                new ObservableCollection<CategoryItemSelectedViewModel>(categories_aux);
                IsRunning = false;
            }
            catch(ErrorResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch(WarningResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch (NoInternetConnectionException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
                IsRunning = false;
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
                IsRunning = false;
            }
        }

        private void AddCategory()
        {
            MainViewModel.GetInstance().CategoryItemViewModel = new CategoryItemViewModel();
            App.Navigator.PushAsync(new AddCategoryPage());
        }
        #endregion
    }
}
