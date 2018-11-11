using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Expenses> Expenses
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

        public ObservableCollection<Expenses> expenses;

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Expenses = new ObservableCollection<Expenses>();
            foreach(var i in MainViewModel.GetInstance().Categories)
            {
                this.Expenses.Add(new Models.Expenses
                {
                    Category = new Category { Name = i.Name },
                    Total = 11M
                });
            }
        }
    }
}
