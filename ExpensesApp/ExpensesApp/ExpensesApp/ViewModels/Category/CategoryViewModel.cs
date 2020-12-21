﻿using ExpensesApp.Models.Category;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
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
        #endregion

        #region Constructor
        public CategoryViewModel(CategoryItem category)
        {
            Category = category;
        }

        public CategoryViewModel()
        {
            Category = new CategoryItem();
        }
        #endregion

        #region Attributes
        private CategoryItem category;
        private bool isRunning;
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
            /*
            this.IsRunning = true;
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            if (category.Id == 0)
            {
                var createCategory = new Category
                {
                    Name = category.Name,
                    UserId = MainViewModel.GetInstance().GetUser.User_Id
                };
                var registerCategory = await ApiServices
                    .GetInstance()
                    .PostItem("api/category/create", createCategory);
                if (!registerCategory.IsSuccess)
                {
                    this.IsRunning = false;
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("Success", registerCategory.Message, "Ok");
            }
            else
            {
                var updateCategory = new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    UserId = MainViewModel.GetInstance().GetUser.User_Id
                };

                var editCategory = await ApiServices
                    .GetInstance()
                    .PutItem($"api/category/update", updateCategory, updateCategory.Id);
                if (!editCategory.IsSuccess)
                {
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Error", editCategory.Message, "Ok");
                    return;
                }
                await Application.Current.MainPage.DisplayAlert("Success", editCategory.Message, "Ok");
            }
            */
            this.IsRunning = false;
            this.Category.Name = string.Empty;
            if (MainViewModel.GetInstance().Category == null)
                MainViewModel.GetInstance().Category = new CategoriesViewModel();
            MainViewModel.GetInstance().Category.LoadCategories();
            if (MainViewModel.GetInstance().Expense == null)
                MainViewModel.GetInstance().Expense = new ExpenseViewModel();
            MainViewModel.GetInstance().Expense.LoadCategories();
        }
        #endregion
    }
}
