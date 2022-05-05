using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BebraSoftware.TodoList.Models.ToDoListTasks;

namespace BebraSoftware.TodoList.Controllers.ToDoListTasksController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListTasksController : ControllerBase
    {
        private readonly ToDoListContext _context;

        public ToDoListTasksController(ToDoListContext context)
        {
            _context = context;
        }

        // GET: api/ToDoListTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListTasks>>> GetToDoListItems()
        {
            return await _context.ToDoListItems.ToListAsync();
        }

        // GET: api/ToDoListTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListTasks>> GetToDoListTasks(int id)
        {
            var toDoListTasks = await _context.ToDoListItems.FindAsync(id);

            if (toDoListTasks == null)
            {
                return NotFound();
            }

            return toDoListTasks;
        }

        // PUT: api/ToDoListTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoListTasks(int id, ToDoListTasks toDoListTasks)
        {
            if (id != toDoListTasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoListTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListTasksExists(id))
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

        // POST: api/ToDoListTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ToDoListTasks>> PostToDoListTasks(ToDoListTasks toDoListTasks)
        {
            _context.ToDoListItems.Add(toDoListTasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoListTasks", new { id = toDoListTasks.Id }, toDoListTasks);
        }

        // DELETE: api/ToDoListTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoListTasks>> DeleteToDoListTasks(int id)
        {
            var toDoListTasks = await _context.ToDoListItems.FindAsync(id);
            if (toDoListTasks == null)
            {
                return NotFound();
            }

            _context.ToDoListItems.Remove(toDoListTasks);
            await _context.SaveChangesAsync();

            return toDoListTasks;
        }

        private bool ToDoListTasksExists(int id)
        {
            return _context.ToDoListItems.Any(e => e.Id == id);
        }
    }
}
