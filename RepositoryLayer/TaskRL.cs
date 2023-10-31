using CommonLayer;
using CommonLayer.Enum;
using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class TaskRL : ITaskRL
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public TaskRL(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<AddTaskResponse> AddTask(AddTaskRequest request)
        {
            AddTaskResponse response = new AddTaskResponse()
            {
                IsSuccess = true,
                Message = "Add Task Successfully"
            };
            try
            {
                TaskDetails taskDetails = new TaskDetails()
                {
                    UsertId = request.UsertId,
                    TaskName = request.TaskName,
                    TaskDescription = request.TaskDescription,
                    Date = request.Date,
                    Time = request.Time,
                    Sunday = request.Sunday,
                    Monday = request.Monday,
                    Tuesday = request.Tuesday,
                    Wednesday = request.Wednesday,
                    Thurday = request.Thurday,
                    Friday = request.Friday,
                    Saturday = request.Saturday,
                    status = request.status
                };

                await _dbContext.TaskDetails.AddAsync(taskDetails);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<DeletePermanentTaskResponse> DeletePermanentTask(DeletePermanentTaskRequest request)
        {
            DeletePermanentTaskResponse response = new DeletePermanentTaskResponse()
            {
                IsSuccess = true,
                Message = "Cancel Task Successfully"
            };
            try
            {
                var Result = _dbContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                var IsDelete = _dbContext.TaskDetails.Remove(Result);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<DeleteTaskResponse> DeleteTask(DeleteTaskRequest request)
        {
            DeleteTaskResponse response = new DeleteTaskResponse()
            {
                IsSuccess = true,
                Message = "Cancel Task Successfully"
            };
            try
            {
                var Result = _dbContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                Result.status = request.status;

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<GetTaskResponse> GetTask(int? UserID)
        {
            GetTaskResponse response = new GetTaskResponse()
            {
                IsSuccess = true,
                Message = "Fetch Task Successfully"
            };
            try
            {
                response.data = await _dbContext.TaskDetails.Where(x => x.UsertId == UserID).ToListAsync();
                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Task Not Found";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequest request)
        {
            UpdateTaskResponse response = new UpdateTaskResponse()
            {
                IsSuccess = true,
                Message = "Update Task Successfully"
            };
            try
            {

                var Result = _dbContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == request.Id).Result;
                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Not Found";
                    return response;
                }

                Result.TaskName = request.TaskName;
                Result.TaskDescription = request.TaskDescription;
                Result.Date = request.Date;
                Result.Time = request.Time;
                Result.Sunday = request.Sunday;
                Result.Monday = request.Monday;
                Result.Tuesday = request.Tuesday;
                Result.Wednesday = request.Wednesday;
                Result.Thurday = request.Thurday;
                Result.Friday = request.Friday;
                Result.Saturday = request.Saturday;
                Result.status = request.status;

                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;

        }

        private string? TaskRespect(string? Id)
        {
            string response = string.Empty;
            try
            {
                string EncryptionKey = "abc123";
                byte[] clearBytes = Encoding.Unicode.GetBytes(Id);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        response = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
