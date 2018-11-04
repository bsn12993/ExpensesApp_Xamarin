using ExpensesApp.Interfaces;
using ExpensesApp.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ExpensesApp.Helpers
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            this.connection = new SQLiteConnection(config.Platform, Path.Combine(config.DirectoryDB, "Expenses.db3"));
            this.connection.CreateTable<UserLocal>();
        }

        public void Insert<T>(T model)
        {
            this.connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            this.connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            this.connection.Delete(model);
        }

        public T First<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return this.connection.GetAllWithChildren<T>().FirstOrDefault();
            }
            else
            {
                return this.connection.Table<T>().FirstOrDefault();
            }
        }

        public List<T> GetList<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return this.connection.GetAllWithChildren<T>().ToList();
            }
            else
            {
                return this.connection.Table<T>().ToList();
            }
        }

        public T Find<T>(int pk,bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return this.connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return this.connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }
    }
}
