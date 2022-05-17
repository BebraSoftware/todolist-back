namespace BebraSoftware.TodoList.Controllers.TasksController
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using BebraSoftware.TodoList.Models.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly Context _context;

        public TasksController(Context context)
        {
            _context = context;
        }

        // GET: api/TaskModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/TaskModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTasks(int id)
        {
            var Tasks = await _context.Items.FindAsync(id);

            if (Tasks == null)
            {
                return NotFound();
            }

            return Tasks;
        }

        // PUT: api/TaskModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, TaskModel Tasks)
        {
            if (id != Tasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(Tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskModel
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTasks(TaskModel Tasks)
        {
            _context.Items.Add(Tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = Tasks.Id }, Tasks);
        }

        // DELETE: api/TaskModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTasks(int id)
        {
            var Tasks = await _context.Items.FindAsync(id);
            if (Tasks == null)
            {
                return NotFound();
            }

            _context.Items.Remove(Tasks);
            await _context.SaveChangesAsync();

            return Tasks;
        }

        private bool TasksExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}