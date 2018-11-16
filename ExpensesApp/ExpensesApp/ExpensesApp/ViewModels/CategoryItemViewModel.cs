using ExpensesApp.Models;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class CategoryItemViewModel : Category
    {
        #region Properties
        public ICommand SelectCategoryCommand
        {
            get { return new RelayCommand(SelectCategory); }
        }
        #endregion

        #region Methods
        private void SelectCategory()
        {
            Category category = this;
            MainViewModel.GetInstance().CategoryItem = new CategoryViewModel(category);
            App.Navigator.PushAsync(new CategoryPage());
            //App.Current.MainPage.Navigation.PushAsync(new CategoryPage());
        }
        #endregion
    }
}
