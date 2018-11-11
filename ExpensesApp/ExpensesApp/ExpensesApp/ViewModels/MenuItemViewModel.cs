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
            else if (this.PageName.Equals("CategoryPage")) 
            {
                App.Navigator.PushAsync(new CategoryPage());
            }
            else if (this.PageName.Equals("AddExpensePage"))
            {
                App.Navigator.PushAsync(new AddExpensePage());
            }
        }
    }
}
