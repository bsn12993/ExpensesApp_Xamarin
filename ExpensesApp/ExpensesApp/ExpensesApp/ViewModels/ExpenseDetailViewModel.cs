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
    public class ExpenseDetailViewModel : INotifyPropertyChanged
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

        public string Category
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Category)));
                }
            }
        }

        public string Date
        {
            get { return this.date; }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Date)));
                }
            }
        }
        #endregion

        #region Attributes
        public ObservableCollection<Category> Categories { get; set; }
        private string amount;
        private string category;
        private string date;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public ExpenseDetailViewModel()
        {
            LoadCategories();
        }

        public ExpenseDetailViewModel(Expense expense)
        {
            //MainViewModel.GetInstance().LoadCategories();
            //this.Categories = MainViewModel.GetInstance().Categories;
            this.Category = expense.Category.Name;
            this.Date = expense.Date;
            this.Amount = expense.Amount.ToString();
        }
        #endregion

        #region Command
        //public ICommand SaveExpenseCommand
        //{
        //    get { return new RelayCommand(SaveExpense); }
        //}
        #endregion

        #region Methods
        private async void LoadCategories()
        {
            var category = await ApiServices.GetInstance().GetList<Category>("api/category/all");
            if (!category.IsSuccess)
            {
                return;
            }
            this.Categories = new ObservableCollection<Category>((IEnumerable<Category>)category.Result);
        }

        //private async void SaveExpense()
        //{
        //    if(!string.IsNullOrEmpty(this.Amount) && !string.IsNullOrEmpty(this.Categoy.Name))
        //    {
        //        var expense = new Expense
        //        {
        //            Amount = Convert.ToDecimal(this.Amount),
        //            Date = DateTime.Now.ToShortDateString(),
        //            Category_Id = this.Categoy.Category_Id,
        //            User_Id = MainViewModel.GetInstance().GetUser.User_Id
        //        };
        //        var registrarExpense = await ApiServices.GetInstance().PostItem("api/expenses/create", expense);
        //        if (!registrarExpense.IsSuccess)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Error", registrarExpense.Message, "Accept");
        //            return;
        //        }
        //        await Application.Current.MainPage.DisplayAlert("OK", "se agrego un nuevo gasto", "Accept");
        //        this.Amount = string.Empty;
        //        this.Categoy.Name = string.Empty;
        //        MainViewModel.GetInstance().Expenses.LoadExpenses();
        //    }
        //    else
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error", "No se permiten campos vacios", "Accept");
        //    }
        //}
        #endregion
    }
}
