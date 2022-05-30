namespace BebraSoftware.TodoList.Context.Task
{
    using Microsoft.EntityFrameworkCore;

    using Models.Task;

    public class TaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; } = null!;

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }
    }
}