using System;
using ToDoo.Models;

namespace ToDoo.Repositories
{
    public interface ITodoRepository
    {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;

        Task<List<TodoItem>> GetItemsAsync();
        Task AddedItemAsync(TodoItem item);
        Task UpdatedItemAsync(TodoItem item);
        Task AddOrUpdate(TodoItem item);
        Task DeletedItemAsync(TodoItem item);
    }
}
