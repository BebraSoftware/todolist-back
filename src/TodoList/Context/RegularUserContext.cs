namespace BebraSoftware.TodoList.Context
{
    using Microsoft.EntityFrameworkCore;

    using Models.User;

    public class RegularUserContext : DbContext
    {
        public RegularUserContext(DbContextOptions<RegularUserContext> options) : base(options)
        {
        }

        public DbSet<RegularUser> Items { get; set; } = null!;
    }
}
