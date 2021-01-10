using ExpensesApp.Models;
using ExpensesApp.Models.Income;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesApp.Services.Income
{
    public class IncomeService
    {
        #region Constructor
        private IncomeService()
        {

        }
        #endregion

        #region Attributes
        private static IncomeService instance;
        #endregion

        #region Methods
        public static IncomeService GetInstance()
        {
            if (instance == null) instance = new IncomeService();
            return instance;
        }

        public async Task<List<IncomeItem>> FindAllByUser(int userId)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Get<List<IncomeItem>>($"api/incomes/history/byuser/{userId}");
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Create(IncomeItem incomeItem)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Create("api/incomes/create", incomeItem);
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Response> Update(IncomeItem incomeItem)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Update("api/incomes/update", incomeItem, incomeItem.Id);
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
