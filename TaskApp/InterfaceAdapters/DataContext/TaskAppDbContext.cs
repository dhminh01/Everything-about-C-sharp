using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters.DataContext
{
    public class TaskAppDbContext : DbContext
    {
        public TaskAppDbContext(DbContextOptions<TaskAppDbContext> options)
            : base(options)
        { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
