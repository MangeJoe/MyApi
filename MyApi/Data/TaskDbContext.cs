using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Data
{
    public class TaskDbContext :DbContext
    {
        public TaskDbContext(DbContextOptions options) : base(options)
        { 
        }
        //this is a list of tasks
        public DbSet<TodoTask> Tasks { get; set; }
    }
}
