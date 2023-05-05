using EcoleIt.ToDoApp.Core.Models;
using EcoleIt.ToDoApp.Core.Outputs;

namespace EcoleIt.ToDoApp.FakeDatabase
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private static readonly List<TodoItem> todoList = new List<TodoItem> {
            new TodoItem { Id = 1, Title = "Finir l'API", Description="Faire des trucs avec les élèves", IsDone=false},
            new TodoItem { Id = 2, Title = "Jouer avec l'architecture", Description="Faire d'autres  trucs avec les élèves"},
            new TodoItem { Id = 3, Title = "Voir les notions de bases de l'API", Description="Rien", IsDone=true},
        };

        public void Add(TodoItem item)
        {
            todoList.Add(item);
        }

        public TodoItem Get(int id) => todoList.SingleOrDefault(x => x.Id == id);

        public IEnumerable<TodoItem> GetAll() => todoList;
    }
}
