namespace BebraSoftware.TodoList.Models.Tasks
{
    using Microsoft.EntityFrameworkCore;
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<TaskModel> Items { get; set; } = null!;
    }
}