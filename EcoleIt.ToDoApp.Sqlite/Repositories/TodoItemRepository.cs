using EcoleIt.ToDoApp.Core.Models;
using EcoleIt.ToDoApp.Core.Outputs;
using EcoleIt.ToDoApp.Sqlite.Mappers;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoleIt.ToDoApp.Sqlite.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly string connectionString = "Data Source=todoApp.db";
        private readonly TodoItemMapper mapper = new TodoItemMapper();
        public void Add(TodoItem item)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO TodoItems (Id, Title, Description, IsDone)
                                        VALUES (@id, @title, @description, @isDone)";
                command.Parameters.AddWithValue("@id", item.Id);
                command.Parameters.AddWithValue("@title", item.Title);
                command.Parameters.AddWithValue("@description", item.Description);
                command.Parameters.AddWithValue("@isDone", item.IsDone);

                var result = command.ExecuteScalar();
            }
        }

        public TodoItem Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            var todoItems = new List<TodoItem>();
            using (var connection = new SqliteConnection(connectionString))
            {                
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM TodoItems  ORDER BY Id";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        todoItems.Add(mapper.Map(reader));
                    }
                }
            }
            return todoItems;
        }
    }
}
