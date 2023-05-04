﻿using EcoleIt.ToDoApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcoleIt.ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly FakeDataBase _db = new FakeDataBase();

        // GET: api/<TodoItemController>
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _db.GetTodoList();
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoList = _db.GetTodoList();
            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<TodoItemController>
        [HttpPost(Name = "Add item")]
        public void Add([FromBody] TodoItem item)
        {
            _db.GetTodoList().Add(item);
        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItem changedItem)
        {
            var todoList = _db.GetTodoList();
            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = changedItem.Name;
            item.Description = changedItem.Description;
            item.IsDone = changedItem.IsDone;
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult CheckItem(int id)
        {
            var todoList = _db.GetTodoList();
            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.IsDone = true;
            return Ok();
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoList = _db.GetTodoList();
            var item = todoList.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            todoList.Remove(item);
            return Ok();
        }
    }
}