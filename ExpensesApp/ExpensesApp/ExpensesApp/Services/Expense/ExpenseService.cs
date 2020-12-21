using ExpensesApp.Models.Expense;
using System;
using System.Collections.Generic;

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

        public List<ExpenseItem> FindAll()
        {
            var list = new List<ExpenseItem>();
            for (int i = 0; i < 15; i++)
            {
                list.Add(new ExpenseItem
                {
                    Id = i,
                    Amount = 10,
                    Category = $"Cateogía {i}",
                    Date = DateTime.Now.ToString(),
                    Description = "Descripción"
                });
            }
            return list;
        }
        #endregion
    }
}
