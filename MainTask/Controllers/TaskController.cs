using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MainTask.Models;
using MainTask.Services;

namespace MainTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }
        [Authorize]
        [HttpPost("create")]

        public IActionResult Create([FromBody] TaskItem task)
        {
            _taskServices.CreateTask(task);
            return NoContent();
        }
        [Authorize]
        [HttpGet("get-all")]
        public IActionResult GetAllTasks()
        {
            return Ok(_taskServices.GetAllTasks());
        }
        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var t = _taskServices.GetTaskById(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }
        [Authorize]
        [HttpPut("update")]
        public IActionResult UpdateTask(TaskItem task)
        {
            _taskServices.UpdateTask(task);
            return NoContent();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _taskServices.DeleteTask(id);
            return NoContent();
        }
    }
}
