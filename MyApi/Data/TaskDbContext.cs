using Microsoft.EntityFrameworkCore;
using MyApi.Domain.Entities;

namespace MyApi.Data
{
    public class TaskDbContext :DbContext
    {
        //passing the options to Dbcontext base class
        public TaskDbContext(DbContextOptions options) : base(options)
        { 
        }
        //this is a property for a list of tasks
        public DbSet<TodoTask> Tasks { get; set; }
    }
}
