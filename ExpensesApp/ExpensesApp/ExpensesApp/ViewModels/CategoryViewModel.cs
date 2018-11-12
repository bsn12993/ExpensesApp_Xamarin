using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpensesApp.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public Category Category { get; set; }

        public CategoryViewModel(Category category)
        {
            this.Category = category;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
