using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.ComponentModel.DataAnnotations;

namespace User_Activity_Application_.Net.Controllers
{
    [Route("api/[controller]/[Action]")]
    [Authorize]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskSL _taskSL;
        public TaskController(ITaskSL taskSL)
        {
            _taskSL = taskSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskRequest request)
        {
            AddTaskResponse? response = new AddTaskResponse();
            try
            {
                response = await _taskSL.AddTask(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetTask([FromQuery, Required] int? UserId)
        {
            GetTaskResponse? response = new GetTaskResponse();
            try
            {
                response = await _taskSL.GetTask(UserId);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateTaskRequest request)
        {
            UpdateTaskResponse? response = new UpdateTaskResponse();
            try
            {
                response = await _taskSL.UpdateTask(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(DeleteTaskRequest request)
        {
            DeleteTaskResponse? response = new DeleteTaskResponse();
            try
            {
                response = await _taskSL.DeleteTask(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePermanentTask([FromQuery]DeletePermanentTaskRequest request)
        {
            DeletePermanentTaskResponse? response = new DeletePermanentTaskResponse();
            try
            {
                response = await _taskSL.DeletePermanentTask(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;
            }

            return Ok(response);
        }

    }
}
