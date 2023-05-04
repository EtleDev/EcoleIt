using EcoleIt.ToDoApp.Api.Models;

namespace EcoleIt.ToDoApp.Api
{
    public class FakeDataBase
    {
        private static readonly List<TodoItem> todoList = new List<TodoItem> {
            new TodoItem { Id = 1, Name = "Finir l'API", Description="Faire des trucs avec les élèves", IsDone=false},
            new TodoItem { Id = 2, Name = "Jouer avec l'architecture", Description="Faire d'autres  trucs avec les élèves"},
            new TodoItem { Id = 3, Name = "Voir les notions de bases de l'API", Description="Rien", IsDone=true},
        };

        public List<TodoItem> GetTodoList() => todoList;
    }
}
