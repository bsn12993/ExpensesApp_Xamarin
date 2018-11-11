using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Category> Categories
        {
            get { return this.categories; }
            set
            {
                if (this.categories != value)
                {
                    this.categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Categories)));
                }
            }
        }

        public ObservableCollection<Category> categories;

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoryViewModel()
        {
            MainViewModel.GetInstance().LoadCategories();
            this.Categories = MainViewModel.GetInstance().Categories;
        }
    }
}
