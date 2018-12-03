using ExpensesApp.Models;
using ExpensesApp.Services;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<ExpensesEnc> Expenses
        {
            get { return this.expenses; }
            set
            {
                if (this.expenses != value)
                {
                    this.expenses = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Expenses)));
                }
            }
        }

        public string Total
        {
            get { return this.total; }
            set
            {
                if (this.total != value)
                {
                    this.total = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Total)));
                }
            }
        }
        #endregion

        #region Attributes
        public ObservableCollection<ExpensesEnc> expenses;
        public string total;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            //MainViewModel.GetInstance().LoadCategories();
            this.Expenses = new ObservableCollection<ExpensesEnc>();
            foreach(var i in MainViewModel.GetInstance().Categories)
            {
                this.Expenses.Add(new Models.ExpensesEnc
                {
                    Category = new Category { Name = i.Name },
                    Total = 11M
                });
            }
            LoadTotal();
        }
        #endregion

        #region Methods
        public async void LoadTotal()
        {
            var total = await ApiServices.GetInstance().GetItem<Income>
                ($"api/incomes/total/byuser/{MainViewModel.GetInstance().GetUser.User_Id}");
            if (!total.IsSuccess)
            {
                return;
            }

            this.Total = ((Income)total.Result).Amount.ToString();

        }
        #endregion
    }
}
