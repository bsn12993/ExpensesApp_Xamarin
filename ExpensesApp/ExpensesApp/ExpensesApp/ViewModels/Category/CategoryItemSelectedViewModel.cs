﻿using ExpensesApp.Models.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class CategoryItemSelectedViewModel : CategoryItem
    {
        #region Properties
        public ICommand GoToEditCategoryPageCommand
        {
            get { return new RelayCommand(GoToEditPage); }
        }
        #endregion

        #region Methods
        private void GoToEditPage()
        {
            CategoryItem category = this;
            MainViewModel.GetInstance().CategoryItemViewModel = new CategoryItemViewModel(category);
            App.Navigator.PushAsync(new CategoryItemPage());
        }
        #endregion
    }
}
