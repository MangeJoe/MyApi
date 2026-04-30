
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Domain.Entities;
using MyApi.DTOs;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskDbContext _dbContext;
        public TaskController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult> Create(TodoTask mytask)
        {
            await _dbContext.Tasks.AddAsync(mytask);
            await _dbContext.SaveChangesAsync();

            return Ok(new ApiResponse<TaskIdDTO>
            {
                Success = true,
                Message="Task has beed added succesfully",
                Data=new TaskIdDTO { Id = mytask.Id }
            });
        }

        //get a list of all task
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        //get a Task by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoTask>> GetById(int id)
        {
            var matchedTask = await _dbContext.Tasks
                .SingleOrDefaultAsync(x => x.Id == id);

            if (matchedTask == null)
                return NotFound();

            return matchedTask;
        }
        //this method is used for creating a new Task
      
        
        //We update a task, using its own object
        [HttpPut]
        public async Task<ActionResult<TodoTask>> Update(TodoTask mytask)
        {
            _dbContext.Tasks.Update(mytask);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        // delete a task by first checking if it exits then delete if it does
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var matchedTask = await _dbContext.Tasks
                .SingleOrDefaultAsync(x => x.Id == id);

            if (matchedTask == null)
                return NotFound();

            _dbContext.Tasks.Remove(matchedTask);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
