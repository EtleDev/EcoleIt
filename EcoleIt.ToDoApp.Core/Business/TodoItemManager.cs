using EcoleIt.ToDoApp.Core.Inputs;
using EcoleIt.ToDoApp.Core.Models;
using EcoleIt.ToDoApp.Core.Outputs;

namespace EcoleIt.ToDoApp.Core.Business
{
    public class TodoItemManager : ITodoItemManager
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemManager(ITodoItemRepository repository)
        {
            _repository = repository;
        }
        public void Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void ChangeDescription(string description, int id)
        {
            throw new NotImplementedException();
        }

        public void Check(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public TodoItem Get(int id) => _repository.Get(id);

        public IEnumerable<TodoItem> GetAll() => _repository.GetAll();

        public void Rename(string title, int id)
        {
            throw new NotImplementedException();
        }

        public void Uncheck(int id)
        {
            throw new NotImplementedException();
        }
    }
}
