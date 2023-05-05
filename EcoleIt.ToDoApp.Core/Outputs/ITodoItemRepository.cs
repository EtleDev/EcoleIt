using EcoleIt.ToDoApp.Core.Models;

namespace EcoleIt.ToDoApp.Core.Outputs
{
    public interface ITodoItemRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        void Add(TodoItem item);
    }
}
