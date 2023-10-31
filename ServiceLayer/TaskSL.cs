using CommonLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TaskSL : ITaskSL
    {
        private readonly ITaskRL _taskRL;
        public TaskSL(ITaskRL taskRL)
        {
            _taskRL = taskRL;
        }
        public async Task<AddTaskResponse> AddTask(AddTaskRequest request)
        {
            return await _taskRL.AddTask(request);
        }

        public async Task<DeletePermanentTaskResponse> DeletePermanentTask(DeletePermanentTaskRequest request)
        {
            return await _taskRL.DeletePermanentTask(request);
        }

        public async Task<DeleteTaskResponse> DeleteTask(DeleteTaskRequest request)
        {
            return await _taskRL.DeleteTask(request);
        }

        public async Task<GetTaskResponse> GetTask(int? UserID)
        {
            return await _taskRL.GetTask(UserID);
        }

        public async Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequest request)
        {
            return await _taskRL.UpdateTask(request);
        }
    }
}
