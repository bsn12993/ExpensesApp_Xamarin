using ExpensesApp.Exceptions;
using ExpensesApp.Models;
using ExpensesApp.Models.Category;
using ExpensesApp.Services.Category;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoryItemViewModel : INotifyPropertyChanged
    {
        #region Properties
        public CategoryItem Category
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
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
        
        public bool IsEnable
        {
            get { return IsEnable; }
            set
            {
                if (isEnable != value)
                {
                    isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnable)));
                }
            }
        }
        #endregion

        #region Constructor
        public CategoryItemViewModel(CategoryItem category)
        {
            Category = category;
        }

        public CategoryItemViewModel()
        {
            Category = new CategoryItem();
        }
        #endregion

        #region Attributes
        private CategoryItem category;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Commands
        public ICommand SaveEditCommand
        {
            get { return new RelayCommand(SaveEditCategory); }
        }
        #endregion

        #region Methods
        public async void SaveEditCategory()
        {
            try
            {
                IsRunning = true;
                IsEnable = false;
                //Create
                if (category.Id == 0)
                {
                    var createCategory = new CategoryItem
                    {
                        Name = category.Name,
                        UserId = MainViewModel.GetInstance().GetUser.Id
                    };

                    var response = await CategoryService.GetInstance().Create(createCategory);
                    if (response.Code != (int)EnumCodeResponse.SUCCESS)
                    {
                        IsRunning = false;
                        await Application.Current.MainPage.DisplayAlert("Advertencia", response.Message, "Aceptar");
                        return;
                    }
                    await Application.Current.MainPage.DisplayAlert("Exito", response.Message, "Aceptar");
                }
                //Edit
                else
                {
                    var updateCategory = new CategoryItem
                    {
                        Id = category.Id,
                        Name = category.Name,
                        UserId = MainViewModel.GetInstance().GetUser.Id
                    };

                    var response = await CategoryService.GetInstance().Update(updateCategory);
                    if (response.Code != (int)EnumCodeResponse.SUCCESS)
                    {
                        IsRunning = false;
                        await Application.Current.MainPage.DisplayAlert("Advertencia", response.Message, "Aceptar");
                        return;
                    }
                    await Application.Current.MainPage.DisplayAlert("Exito", response.Message, "Aceptar");
                }

                IsRunning = false;
                IsEnable = true;
                Category.Name = string.Empty;
                if (MainViewModel.GetInstance().CategoryListViewModel == null)
                    MainViewModel.GetInstance().CategoryListViewModel = new CategoryListViewModel();
                MainViewModel.GetInstance().CategoryListViewModel.LoadCategories();
                await App.Navigator.PopAsync();
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
        #endregion
    }
}
