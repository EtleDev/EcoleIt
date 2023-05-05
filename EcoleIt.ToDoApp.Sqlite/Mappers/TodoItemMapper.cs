using EcoleIt.ToDoApp.Core.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleIt.ToDoApp.Sqlite.Mappers
{
    public class TodoItemMapper
    {
        public TodoItem Map(SqliteDataReader reader) => new TodoItem
        {
            Id = Convert.ToInt32(reader["Id"]),
            Title = Convert.ToString(reader["Title"]),
            Description = Convert.ToString(reader["Description"]),
            IsDone = Convert.ToBoolean(reader["IsDone"]),
        };
    }
}
