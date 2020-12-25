using ExpensesApp.Models;
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
        private IncomeService instance;
        #endregion

        #region Methods
        public IncomeService GetInstance()
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
        #endregion
    }
}
