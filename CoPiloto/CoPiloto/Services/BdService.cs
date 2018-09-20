using CoPiloto.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoPiloto.Services
{
    class BdService
    {
        static Lazy<BdService> BdLazy = new Lazy<BdService>(() => new BdService());

        private SQLiteConnection Connection;

        public static BdService Current => BdLazy.Value;

        BdService()
        {
            var name   = "history.db3";
            name       = Path.Combine(Const.Root, name);
            Connection = new SQLiteConnection(name);
            Connection.CreateTable<AiportHistory>();
        }

        #region Queries
        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            var query = Connection.Table<T>().FirstOrDefault(c => c.Id == id);
            return query;
        }

        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            return (from i in Connection.Table<T>()
                    select i);
        }

        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            if (item.Id != 0)
            {
                Connection.Update(item);
                return item.Id;
            }
            return Connection.Insert(item);
        }

        public void SaveItens<T>(IEnumerable<T> items) where T : IBusinessEntity
        {
            Connection.BeginTransaction();

            foreach (T item in items)
            {
                SaveItem(item);
            }

            Connection.Commit();
        }

        public int DeleteItem<T>(T item) where T : IBusinessEntity, new()
        {
            return Connection.Delete(item);
        }

        public void Dispose()
        {
            Connection.Dispose();
        } 
        #endregion
    }
}
