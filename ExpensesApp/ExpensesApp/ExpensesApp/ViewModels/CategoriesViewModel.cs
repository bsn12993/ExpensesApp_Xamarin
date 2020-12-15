using ExpensesApp.Models;
using ExpensesApp.Services;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<CategoryItemViewModel> Categories
        {
            get { return this.categories; }
            set
            {
                if (this.categories != value)
                {
                    this.categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Categories)));
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
            /*
            this.IsRunning = true;
            this.Categories = new ObservableCollection<CategoryItemViewModel>();
            this.Categories.Clear();
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }
            var categories = await ApiServices.GetInstance()
                .GetList<CategoryItemViewModel>($"api/category/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!categories.IsSuccess)
            {
                this.IsRunning = false;
                return;
            }

            this.IsRunning = false;
            this.Categories = 
                new ObservableCollection<CategoryItemViewModel>((IEnumerable<CategoryItemViewModel>)categories.Result);
            */
            this.Categories = new ObservableCollection<CategoryItemViewModel>();
            for (int i = 1; i <= 20; i++)
            {
                this.Categories.Add(new CategoryItemViewModel
                {
                    Id = i,
                    Name = $"Cat {i}",
                    UserId = 1,
                });
            }
        }

        private void AddCategory()
        {
            if (MainViewModel.GetInstance().Expense == null)
                MainViewModel.GetInstance().Expense = new ExpenseViewModel();
            MainViewModel.GetInstance().CategoryItem = new CategoryViewModel();
            MainViewModel.GetInstance().Expense.LoadCategories();
            App.Navigator.PushAsync(new AddCategoryPage());
        }
        #endregion
    }
}
