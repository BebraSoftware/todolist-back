using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BebraSoftware.TodoList.Models.Tasks;

namespace BebraSoftware.TodoList.Controllers.TasksController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly Context _context;

        public TasksController(Context context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
            var Tasks = await _context.Items.FindAsync(id);

            if (Tasks == null)
            {
                return NotFound();
            }

            return Tasks;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks(int id, Tasks Tasks)
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

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tasks>> PostTasks(Tasks Tasks)
        {
            _context.Items.Add(Tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = Tasks.Id }, Tasks);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tasks>> DeleteTasks(int id)
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
