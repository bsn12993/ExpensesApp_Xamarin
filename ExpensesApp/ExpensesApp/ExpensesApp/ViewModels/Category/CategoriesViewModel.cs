using ExpensesApp.Exceptions;
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
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<CategoryItemViewModel> Categories
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
        private ObservableCollection<CategoryItemViewModel> categories;
        private bool isRunning;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public CategoriesViewModel()
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
        public IEnumerable<CategoryItemViewModel> ToCategoryItemViewModel()
        {
            return MainViewModel.GetInstance().Categories.Select(c => new CategoryItemViewModel
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async void LoadCategories()
        {
            try
            {
                var user = MainViewModel.GetInstance().GetUser;
                var categories = await CategoryService
                    .GetInstance()
                    .FindAllByUser(user.Id);

                var categories_aux = categories
                    .Select(x => new CategoryItemViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        UserId = x.UserId
                    });
                Categories =
               new ObservableCollection<CategoryItemViewModel>(categories_aux);
            }
            catch(ErrorResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
            }
            catch(WarningResponseServerException e)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", e.Message, "Aceptar");
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
            }
        }

        private void AddCategory()
        {
            MainViewModel.GetInstance().CategoryItem = new CategoryViewModel();
            App.Navigator.PushAsync(new AddCategoryPage());
        }
        #endregion
    }
}
