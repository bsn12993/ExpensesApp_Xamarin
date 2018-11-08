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
        public HomeViewModel Categories { get; set; }

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }

        public MainViewModel()
        {
            instance = this;
            Login = new LoginViewModel();
            Register = new RegisterViewModel();
            Categories = new HomeViewModel();
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
            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "",
                PageName = "CategoryPage",
                Title = "Categorias"
            });
        }

  
    }
}
