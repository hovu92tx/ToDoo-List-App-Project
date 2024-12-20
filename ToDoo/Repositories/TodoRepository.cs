using ToDoo.Models;
using SQLite;
using System.Diagnostics;
namespace ToDoo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public event EventHandler<TodoItem> OnItemAdded;
        public event EventHandler<TodoItem> OnItemUpdated;

        private SQLiteAsyncConnection connection;

        public async Task AddedItemAsync(TodoItem item)
        {
            await CreateConnectionAsync();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task UpdatedItemAsync(TodoItem item)
        {
            await CreateConnectionAsync();
            await connection.UpdateAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }

        public async Task AddOrUpdate(TodoItem item)
        {
            if (item.Id == 0)
            {
                await AddedItemAsync(item);
            }
            else
            {
                await UpdatedItemAsync(item);
            }
        }

        public async Task DeletedItemAsync(TodoItem item)
        {
            if (item.Id != 0) 
            {
                await CreateConnectionAsync();
                await connection.DeleteAsync(item);
                OnItemUpdated?.Invoke(this, item);
            }
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await CreateConnectionAsync();
            return await connection.Table<TodoItem>().ToListAsync();
        }

        private async Task CreateConnectionAsync()
        {
            if (connection != null) { return; }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databasePath = Path.Combine(documentPath, "TodoList.db");
            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<TodoItem>();
        }

    }
}
