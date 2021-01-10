using ExpensesApp.Models.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get { return new RelayCommand(Navigate); }
        }
        #endregion

        #region Methods
        private void Navigate()
        {
            App.Master.IsPresented = false;
            if (PageName.Equals("LoginPage"))
            {
                MainViewModel.GetInstance().GetUser = null;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (PageName.Equals("CategoryListPage")) 
            {
                if(MainViewModel.GetInstance().CategoryListViewModel == null)
                    MainViewModel.GetInstance().CategoryListViewModel = new CategoryListViewModel();
                MainViewModel.GetInstance().CategoryListViewModel.LoadCategoryList();
                App.Navigator.PushAsync(new CategoryListPage());
            }
        }
        #endregion
    }
}
