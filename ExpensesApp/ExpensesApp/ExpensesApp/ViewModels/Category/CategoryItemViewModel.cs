using ExpensesApp.Models.Category;
using ExpensesApp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace ExpensesApp.ViewModels
{
    public class CategoryItemViewModel : CategoryList
    {
        #region Properties
        public ICommand SelectCategoryCommand
        {
            get { return new RelayCommand(SelectCategory); }
        }
        #endregion

        #region Methods
        private void SelectCategory()
        {
            CategoryList category = this;
            MainViewModel.GetInstance().CategoryItem = new CategoryViewModel(category);
            App.Navigator.PushAsync(new EditCategoryPage());
            //App.Current.MainPage.Navigation.PushAsync(new CategoryPage());
        }
        #endregion
    }
}
