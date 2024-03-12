using Microsoft.AspNetCore.Mvc;
using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentAPI.Services.IServices;

namespace TaskMangmentAPI.Controllers
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
         
        [HttpGet("getList/{id}")]
        public async Task<IActionResult> GetTaskById(string id)
        {
            try
            {
                var response = await _taskServices.GetTaskListByAccountId(id);
                return StatusCode(response.result, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                var response = await _taskServices.DeleteTaskToDB(id);
                return StatusCode(response.result, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Register([FromBody] NewTaskDto newTask)
        {
            try
            {
                var response = await _taskServices.AddNewTaskToDB(newTask);
                return StatusCode(response.result, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBusinessDetails([FromBody] UpdateTaskDto updateTaskDto)
        {
            try
            {
                var response = await _taskServices.UpdateTaskToDB(updateTaskDto);
                return StatusCode(response.result, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        } 
    }
}
