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
        public ICommand SelectCategoryCommand
        {
            get { return new RelayCommand(SelectCategory); }
        }

        private void SelectCategory()
        {
            Category category = this;
            MainViewModel.GetInstance().CategoryItem = new CategoryViewModel(category);
            App.Current.MainPage.Navigation.PushAsync(new CategoryPage());
        }
    }
}
