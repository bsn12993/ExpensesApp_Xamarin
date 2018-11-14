using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (this.PageName.Equals("LoginPage"))
            {
                Application.Current.MainPage = new LoginPage();
            }
            else if (this.PageName.Equals("CategoriesPage")) 
            {
                App.Navigator.PushAsync(new CategoriesPage());
            }
            else if (this.PageName.Equals("AddExpensePage"))
            {
                App.Navigator.PushAsync(new AddExpensePage());
            }
            else if (this.PageName.Equals("ProfilePage"))
            {
                App.Navigator.PushAsync(new ProfilePage());
            }
        }
    }
}
