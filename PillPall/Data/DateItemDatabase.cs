using System;
using PillPall.Models;
using SQLite;

namespace PillPall.Data
{
	public class DateItemDatabase
	{
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.EnableWriteAheadLoggingAsync();
            var result = await Database.CreateTableAsync<DateItem>();
        }

        public async Task<List<DateItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<DateItem>().ToListAsync();
        }

        //public async Task<List<DrugItem>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<DrugItem>().Where(t => t.Done).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public async Task<DateItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<DateItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(DateItem item)
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

        public async Task<int> DeleteItemAsync(DateItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

        public DateItemDatabase()
		{
		}
	}
}

