namespace BebraSoftware.TodoList.Models.Tasks
{
    using Microsoft.EntityFrameworkCore;

    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
        public DbSet<TaskModel> Items { get; set; } = null!;
    }
}