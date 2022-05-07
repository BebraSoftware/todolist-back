using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BebraSoftware.TodoList.Models.Tasks
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Tasks> Items { get; set; } = null!;
    }
}
