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
    public class CategoryViewModel : INotifyPropertyChanged
    {
        #region Properties
        public Category Category
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Category)));
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
        #endregion

        #region Constructor
        public CategoryViewModel(Category category)
        {
            this.Category = category;
        }

        public CategoryViewModel()
        {
            this.Category = new Category();
        }
        #endregion

        #region Attributes
        private Category category;
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
            this.IsRunning = true;
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }

            if (MainViewModel.GetInstance().GetUser != null)
            {
                category.User = MainViewModel.GetInstance().GetUser;
            }

            if (category.Category_Id == 0)
            {
                var userCategory = new UserCategory
                {
                    Category = category,
                    User = category.User
                };
                var registerCategory = await ApiServices.GetInstance().PostItem("api/category/create", userCategory);
                if (!registerCategory.IsSuccess)
                {
                    this.IsRunning = false;
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("Success", registerCategory.Message, "Ok");
            }
            else
            {
                var editCategory = await ApiServices.GetInstance().PutItem($"api/category/update", category, category.Category_Id);
                if (!editCategory.IsSuccess)
                {
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Error", editCategory.Message, "Ok");
                    return;
                }
                await Application.Current.MainPage.DisplayAlert("Success", editCategory.Message, "Ok");
            }

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
