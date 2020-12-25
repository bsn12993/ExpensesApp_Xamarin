using ExpensesApp.Models;
using ExpensesApp.Models.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesApp.Services.Category
{
    public class CategoryService 
    {
        #region Constructor
        private CategoryService()
        {

        }
        #endregion

        #region Attributes
        private static CategoryService instance;
        #endregion

        #region Methods
        public static CategoryService GetInstance()
        {
            if (instance == null) instance = new CategoryService();
            return instance;
        } 

        public async Task<List<CategoryItem>> FindAllByUser(int userId)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Get<List<CategoryItem>>($"api/category/byuser/{userId}");
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Create(CategoryItem categoryItem)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Create("api/category/create", categoryItem);
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Update(CategoryItem categoryItem)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Update<CategoryItem>("api/category/update", categoryItem, categoryItem.Id);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
