using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace mlekarna
{
    static class DB<T> where T : new()
    {
        static SQLiteConnection conn;

        static DB()
        {
            conn = new SQLiteConnection("db");
        }

        public static List<T> GetItems()
        {
            try
            {
                return conn.Table<T>().ToList();
            }
            catch (SQLiteException)
            {
                conn.CreateTable<T>();
                return conn.Table<T>().ToList();
            }
        }

        static public int AddItem(T item)
        {
            return conn.Insert(item);
        }

        static public int RemoveItem(T item)
        {
            return conn.Delete(item);
        }

        static public int RemoveWhere(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return conn.Table<T>().Delete(filter);
        }
    }
}
