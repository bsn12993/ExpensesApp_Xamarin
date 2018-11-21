using ExpensesApp.Models;
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
        #endregion

        #region Attributes
        public ObservableCollection<ExpensesEnc> expenses;
        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Expenses = new ObservableCollection<ExpensesEnc>();
            foreach(var i in MainViewModel.GetInstance().Categories)
            {
                this.Expenses.Add(new Models.ExpensesEnc
                {
                    Category = new Category { Name = i.Name },
                    Total = 11M
                });
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
