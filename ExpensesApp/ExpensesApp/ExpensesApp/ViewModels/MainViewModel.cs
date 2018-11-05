using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public MainViewModel()
        {
            Login = new LoginViewModel();
            Register = new RegisterViewModel();
            this.LoadMenu();
        }

        public void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "",
                Title = "Dashboard"
            });
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "",
                Title = "Agregar Gastos"
            });
        }
    }
}
