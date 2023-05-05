using EcoleIt.ToDoApp.Core.Business;
using EcoleIt.ToDoApp.Core.Inputs;
using EcoleIt.ToDoApp.Core.Models;
using EcoleIt.ToDoApp.FakeDatabase;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcoleIt.ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemManager mgr = new TodoItemManager(new TodoItemRepository());

        // GET: api/<TodoItemController>
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get() => Ok(mgr.GetAll());

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var item = mgr.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost(Name = "Add item")]
        public IActionResult Add([FromBody] TodoItem item)
        {
            mgr.Add(item);
            return Ok();
        }

        //// PUT api/<TodoItemController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] TodoItem changedItem)
        //{
        //    var todoList = _db.GetTodoList();
        //    var item = todoList.FirstOrDefault(x => x.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    item.Name = changedItem.Name;
        //    item.Description = changedItem.Description;
        //    item.IsDone = changedItem.IsDone;
        //    return Ok();
        //}

        //[HttpPatch("{id}")]
        //public IActionResult CheckItem(int id)
        //{
        //    var todoList = _db.GetTodoList();
        //    var item = todoList.FirstOrDefault(x => x.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    item.IsDone = true;
        //    return Ok();
        //}

        //// DELETE api/<TodoItemController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var todoList = _db.GetTodoList();
        //    var item = todoList.FirstOrDefault(x => x.Id == id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    todoList.Remove(item);
        //    return Ok();
        //}
    }
}
