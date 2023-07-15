using Microsoft.AspNetCore.Mvc;

namespace lab5test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>();
        private static int nextTaskId = 1;

        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            task.Id = nextTaskId++;
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAllTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = updatedTask.Title;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return NoContent();
        }
    }
}