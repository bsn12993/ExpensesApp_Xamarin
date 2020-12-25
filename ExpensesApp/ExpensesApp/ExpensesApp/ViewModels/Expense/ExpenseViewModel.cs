using ExpensesApp.Models.Category;
using ExpensesApp.Services.Category;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;

namespace ExpensesApp.ViewModels
{
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
                }
            }
        }

        public CategoryItem CategoySelected
        {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoySelected)));
                }
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        public string amount;
        public CategoryItem category;
        public ObservableCollection<CategoryItem> Categories { get; set; }
        public bool isRunning;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public ExpenseViewModel()
        {
        }
        #endregion

        #region Command
        public ICommand SaveExpenseCommand
        {
            get { return new RelayCommand(SaveExpense); }
        }
        #endregion

        #region Methods
        private async void SaveExpense()
        {
            /*
            this.IsRunning = true;
            if (!string.IsNullOrEmpty(this.Amount) && !string.IsNullOrEmpty(this.CategoySelected.Name))
            {
                var expense = new Expense
                {
                    Amount = Convert.ToDecimal(this.Amount),
                    Date = DateTime.Now.ToShortDateString(),
                    Category_Id = this.CategoySelected.Id,
                    User_Id = MainViewModel.GetInstance().GetUser.User_Id
                };

                var connection = await ApiServices.GetInstance().CheckConnection();
                if (!connection.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Ok");
                    return;
                }

                var registrarExpense = await ApiServices.GetInstance().PostItem("api/expenses/create", expense);
                if (!registrarExpense.IsSuccess)
                {
                    this.IsRunning = false;
                    await Application.Current.MainPage.DisplayAlert("Error", registrarExpense.Message, "Accept");
                    return;
                }
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("OK", "se agrego un nuevo gasto", "Accept");
                this.Amount = string.Empty;
                this.CategoySelected.Name = string.Empty;
                if (MainViewModel.GetInstance().Expenses == null)
                    MainViewModel.GetInstance().Expenses = new ExpensesViewModel();
                MainViewModel.GetInstance().Expenses.LoadExpenses();
                if (MainViewModel.GetInstance().HistoryExpenses == null)
                    MainViewModel.GetInstance().HistoryExpenses.LoadExpensesHistory();
                MainViewModel.GetInstance().HistoryExpenses.LoadExpensesHistory();
            }
            else
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", "No se permiten campos vacios", "Accept");
            }
            */
        }

        public async void LoadCategories()
        {
            var user = MainViewModel.GetInstance().GetUser;
            var categories = await CategoryService
                .GetInstance()
                .FindAllByUser(user.Id);
            var categories_aux = categories
                .Select(x => new CategoryItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UserId = x.UserId
                });
            Categories = new ObservableCollection<CategoryItem>(categories_aux);
        }
        #endregion
    }
}
