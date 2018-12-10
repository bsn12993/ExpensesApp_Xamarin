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
        #endregion

        #region Attributes
        public ObservableCollection<CategoryItemViewModel> categories;
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
                Category_Id = c.Category_Id,
                Name = c.Name
            });
        }

        public async void LoadCategories()
        {
            var connection = await ApiServices.GetInstance().CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                return;
            }
            var categories = await ApiServices.GetInstance().GetList<CategoryItemViewModel>("api/category/all");
            if (!categories.IsSuccess)
            {
                return;
            }

            this.Categories = 
                new ObservableCollection<CategoryItemViewModel>((IEnumerable<CategoryItemViewModel>)categories.Result);
        }

        private void AddCategory()
        {
            if (MainViewModel.GetInstance().Expense == null)
                MainViewModel.GetInstance().Expense = new ExpenseViewModel();
            MainViewModel.GetInstance().Expense.LoadCategories();
            App.Navigator.PushAsync(new AddCategoryPage());
        }
        #endregion
    }
}
