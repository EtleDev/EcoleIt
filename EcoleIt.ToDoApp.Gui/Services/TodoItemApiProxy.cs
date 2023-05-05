using EcoleIt.ToDoApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

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
            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var items = JsonSerializer.Deserialize<IEnumerable<TodoItem>>(content, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return items;
            }
            return Enumerable.Empty<TodoItem>();
        }

        public void AddItem(TodoItem item)
        {
            if (item != null)
            {
                //var test = JsonSerializer.Serialize<TodoItem>(item);
                //var resp = _httpClient.PostAsync("api/TodoItem", new StringContent(test, Encoding.UTF8, "application/json")).Result;
                var response = _httpClient.PostAsJsonAsync("api/TodoItem", item).Result;
                var req = response.RequestMessage.Content.ReadAsStringAsync().Result;
                //response.EnsureSuccessStatusCode();
            }
        }
    }
}
