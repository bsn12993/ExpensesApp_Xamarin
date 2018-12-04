using ExpensesApp.Models;
using ExpensesApp.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class ExpenseViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string Amount
        {
            get { return this.amount; }
            set
            {
                if (this.amount != value)
                {
                    this.amount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Amount)));
                }
            }
        }

        public Category CategoySelected
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CategoySelected)));
                }
            }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set
            {
                if (this.isRunning != value)
                {
                    this.isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunning)));
                }
            }
        }
        #endregion

        #region Attributes
        public string amount;
        public Category category;
        public ObservableCollection<Category> Categories { get; set; }
        public bool isRunning;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public ExpenseViewModel()
        {
            LoadCategories();
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
            this.IsRunning = true;
            if (!string.IsNullOrEmpty(this.Amount) && !string.IsNullOrEmpty(this.CategoySelected.Name))
            {
                var expense = new Expense
                {
                    Amount = Convert.ToDecimal(this.Amount),
                    Date = DateTime.Now.ToShortDateString(),
                    Category_Id = this.CategoySelected.Category_Id,
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
                MainViewModel.GetInstance().Expenses.LoadExpenses();
            }
            else
            {
                this.IsRunning = false;
                await Application.Current.MainPage.DisplayAlert("Error", "No se permiten campos vacios", "Accept");
            }
        }

        private async void LoadCategories()
        {
            var category = await ApiServices.GetInstance().GetList<Category>("api/category/all");
            if (!category.IsSuccess)
            {
                return;
            }
            this.Categories = new ObservableCollection<Category>((IEnumerable<Category>)category.Result);
        }
        #endregion
    }
}
