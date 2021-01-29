using ExpensesApp.Models;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public ObservableCollection<MenuItemViewModel> MenuItemView { get; set; }

        #region Category
        public CategoryItemViewModel CategoryItemViewModel { get; set; }
        public CategoryListViewModel CategoryListViewModel { get; set; }
        #endregion

        #region Expense
        public ExpenseDetailViewModel ExpenseDetailViewModel { get; set; }
        public ExpenseListViewModel ExpenseListViewModel { get; set; }
        public ExpenseItemViewModel ExpenseItemViewModel { get; set; }
        #endregion

        #region Income
        public IncomeItemViewModel IncomeItemViewModel { get; set; }
        public IncomeListViewModel IncomeListViewModel { get; set; }
        #endregion

        public HomeViewModel HomeViewModel { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }
        public HistoryExpensesViewModel HistoryExpenses { get; set; }
         
        public FindUser GetUser
        {
            get { return getUser; }
            set
            {
                if (getUser != value)
                {
                    getUser = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GetUser)));
                }
            }
        }
        #endregion

        private FindUser getUser;

        #region Singleton
        private static MainViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainViewModel GetInstance()
        {
            if (instance == null) return new MainViewModel();
            else return instance;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            LoginViewModel = new LoginViewModel();
            RegisterViewModel = new RegisterViewModel();
            ProfileViewModel = new ProfileViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods
        public void LoadMenu()
        {
            MenuItemView = new ObservableCollection<MenuItemViewModel>();
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_home",
                PageName = "HomePage",
                Title = "Inicio"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_list",
                PageName = "CategoryListPage",
                Title = "Categoias"
            });
            MenuItemView.Add(new MenuItemViewModel
            {
                Icon = "ic_close",
                PageName = "LoginPage",
                Title = "Salir"
            });
        }

        public ICommand GoToProfilePage
        {
            get { return new RelayCommand(GoToPage); }
        }

        private void GoToPage()
        {
            GetInstance().ProfileViewModel = new ProfileViewModel(GetInstance().GetUser);
            App.Navigator.PushAsync(new ProfilePage());
        }


        #endregion
    }
}
