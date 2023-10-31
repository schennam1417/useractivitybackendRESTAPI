using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ITaskSL
    {
        Task<AddTaskResponse> AddTask(AddTaskRequest request);
        Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequest request);
        Task<GetTaskResponse> GetTask(int? UserID);
        Task<DeleteTaskResponse> DeleteTask(DeleteTaskRequest request);
        Task<DeletePermanentTaskResponse> DeletePermanentTask(DeletePermanentTaskRequest request);
    }
}
