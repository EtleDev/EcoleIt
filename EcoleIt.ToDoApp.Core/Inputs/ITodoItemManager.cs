using EcoleIt.ToDoApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleIt.ToDoApp.Core.Inputs
{
    public interface ITodoItemManager
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Get(int id);
        void Add(TodoItem item);
        void Rename(string title, int id);
        void ChangeDescription(string description, int id);
        void Check(int id);
        void Uncheck(int id);
        void Delete(int id);
        void DeleteAll();

    }
}
