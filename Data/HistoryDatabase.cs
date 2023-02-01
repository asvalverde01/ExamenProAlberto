using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProAlberto.Data
{
    public class HistoryDatabase
    {
        private SQLiteAsyncConnection _database;

        public HistoryDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<History>().Wait();
        }

        public Task<List<History>> GetHistoryAsync()
        {
            return _database.Table<History>().ToListAsync();
        }

        public Task<int> SaveHistoryAsync(History history)
        {
            return _database.InsertAsync(history);
        }
    }

}
