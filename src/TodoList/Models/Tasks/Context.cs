namespace BebraSoftware.TodoList.Models.Tasks
{
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics.CodeAnalysis;
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Tasks> Items { get; set; } = null!;
    }
}
