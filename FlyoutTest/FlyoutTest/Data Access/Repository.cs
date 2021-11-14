using MvvmHelpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyoutTest.Data_Access
{
    public class Repository<T> : IRepository<T> where T : IDatabaseItem, new ()
    {

        readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() => {

            return new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        
        });

        private SQLiteAsyncConnection Database => lazyInitializer.Value;

        public Repository()
        {
            InitializeAsync().SafeFireAndForget();
        }

        async Task InitializeAsync()
        {
           if(!Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                await Database.CreateTableAsync(typeof(T)).ConfigureAwait(false);
            }
        }

        public Task<int> DeleteAsysnc(T item)
        {
            return Database.DeleteAsync(item);
        }

        public Task<List<T>> GetAllAsync()
        {
            return Database.Table<T>().ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return Database.Table<T>().Where(X => X.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAsync(T item)
        {
            if(item.Id != 0)
            {
                return Database.UpdateAsync(item);
            } else
            {
                return Database.InsertAsync(item);
            }
        }
    }
}
