using Assignment_ToDoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_ToDoApi.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> todos = new List<TodoItem>();
        private static int nextId = 1;

        // GET: api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll() => todos;

        // GET: api/todo/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var item = todos.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            return item;
        }

        // POST: api/todo
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem newItem)
        {
            newItem.Id = nextId++;
            todos.Add(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem updatedItem)
        {
            var item = todos.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            item.Title = updatedItem.Title;
            item.IsCompleted = updatedItem.IsCompleted;
            return NoContent();
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = todos.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            todos.Remove(item);
            return NoContent();
        }
    }
}
