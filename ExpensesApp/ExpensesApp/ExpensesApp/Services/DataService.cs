using ExpensesApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpensesApp.Services
{
    public class DataService
    {
        public bool DeleteAll<T>() where T : class
        {
            try
            {
                using(var data=new DataAccess())
                {
                    var oldRecords = data.GetList<T>(false);
                    foreach(var val in oldRecords)
                    {
                        data.Delete(val);
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public T DeleteAllAndInsert<T>(T model)where T : class
        {
            try
            {
                using(var data=new DataAccess())
                {
                    var oldRecords = data.GetList<T>(false);
                    foreach (var val in oldRecords)
                    {
                        data.Delete(val);
                    }
                    data.Insert(model);
                    return model;
                }
            }
            catch(Exception e)
            {
                e.ToString();
                return model;
            }
        }

        public T InsertOrUpdate<T>(T model) where T : class
        {
            try
            {
                using (var data = new DataAccess())
                {
                    var oldRecord = data.Find<T>(model.GetHashCode(), false);
                    if (oldRecord != null)
                    {
                        data.Update(model);
                    }
                    else
                    {
                        data.Insert(model);
                    }
                    return model;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return model;
            }
        }

        public T Insert<T>(T model)
        {
            using(var data = new DataAccess())
            {
                data.Insert(model);
                return model;
            }
        }

        public T Find<T>(int pk, bool withChildren) where T: class
        {
            using(var data=new DataAccess())
            {
                return data.Find<T>(pk, withChildren);
            }
        }

        public T First<T>(bool withChildren) where T : class
        {
            using (var data = new DataAccess())
            {
                return data.GetList<T>(withChildren).FirstOrDefault();
            }
        }

        public List<T> Get<T>(bool withChildren) where T : class
        {
            using(var data=new DataAccess())
            {
                return data.GetList<T>(withChildren).ToList();
            }
        }

        public void Update<T>(T model)
        {
            using(var data=new DataAccess())
            {
                data.Update(model);
            }
        }

        public void Delete<T>(T model)
        {
            using(var data=new DataAccess())
            {
                data.Delete(model);
            }
        }

        public void Save<T>(List<T> list) where T: class
        {
            using(var data =new DataAccess())
            {
                foreach(var val in list)
                {
                    InsertOrUpdate(val);
                }
            }
        }
    }
}
