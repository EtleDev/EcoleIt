using EcoleIt.ToDoApp.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcoleIt.ToDoApp.Gui.Services
{
    public class TodoItemApiProxy
    {
        private HttpClient _httpClient;

        public TodoItemApiProxy()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5055");
        }
        public IEnumerable<TodoItem> GetItems()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/TodoItem");
            var response = _httpClient.Send(request);
            if (response != null && !response.IsSuccessStatusCode)
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<TodoItem>>(response.Content.ReadAsStringAsync().Result);
                return items;
            }
            return Enumerable.Empty<TodoItem>();
        }
        //    => new[]
        //{
        //    new TodoItem { Description = "Walk the dog" },
        //    new TodoItem { Description = "Buy some milk" },
        //    new TodoItem { Description = "Learn Avalonia", IsDone = true },

        //};
    }
}
