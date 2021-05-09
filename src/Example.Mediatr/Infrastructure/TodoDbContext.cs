using Example.Mediatr.Endpoints.Todos;
using Microsoft.EntityFrameworkCore;

namespace Example.Mediatr.Infrastructure
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todo>()
                .HasKey(t => t.Id);
        }
    }
}
