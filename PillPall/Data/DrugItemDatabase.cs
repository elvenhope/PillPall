using System;
using PillPall.Models;
using SQLite;

namespace PillPall.Data
{
	public class DrugItemDatabase
	{
        SQLiteAsyncConnection Database;
        
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.EnableWriteAheadLoggingAsync();
            var result = await Database.CreateTableAsync<DrugItem>();
        }

        public async Task<List<DrugItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DrugItem>().ToListAsync();
        }

        //public async Task<List<DrugItem>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<DrugItem>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public async Task<DrugItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DrugItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DrugItem item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(DrugItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

        public DrugItemDatabase()
		{
		}
	}
}

