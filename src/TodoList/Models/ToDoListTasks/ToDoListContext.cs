using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BebraSoftware.TodoList.Models.ToDoListTasks
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoListTasks> ToDoListItems { get; set; } = null!;
    }
}
