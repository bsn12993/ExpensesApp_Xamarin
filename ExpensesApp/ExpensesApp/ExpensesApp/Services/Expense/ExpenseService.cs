using ExpensesApp.Models.Expense;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesApp.Services.Expense
{
    public class ExpenseService
    {
        #region Constructor
        private ExpenseService()
        {

        }
        #endregion

        #region Atttributes
        private static ExpenseService instance;
        #endregion

        #region Methods
        public static ExpenseService GetInstance()
        {
            if (instance == null) instance = new ExpenseService();
            return instance;
        }

        public async Task<List<ExpenseItem>> FindAllByUser(int userId)
        {
            try
            {
                var response = await ApiService
                    .GetInstance()
                    .Get<List<ExpenseItem>>($"api/expenses/history/byuser/{userId}");
                return response;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
