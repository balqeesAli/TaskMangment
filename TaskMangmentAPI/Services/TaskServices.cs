using TaskMangmentAPI.Infrastructure.DTOs;
using TaskMangmentAPI.Infrastructure.Repo.IRepo;
using TaskMangmentAPI.Services.IServices;
using TaskMangmentModel.Models;

namespace TaskMangmentAPI.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly IDbRepo _dbRepo;

        public TaskServices(IDbRepo dbRepo)
        {
            this._dbRepo = dbRepo;
        }

        public async Task<ResponseModel<object>> AddNewTaskToDB(NewTaskDto model)
        {
            var account = await _dbRepo.AccountRepo.GetAccountByIdAsync(model.AccountId);

            if (account == null)
            {
                return ResponseModel<object>.Fail(403, "Account not found");
            }


            var newTask = new UsersTask()
            {
                Id = Guid.NewGuid(),
                title = model.Title,
                Summary = model.Summary,
                status = model.Status,
                AccountId = model.AccountId.ToLower() 
            };

            try
            {
                if (!await _dbRepo.TaskRepo.Post(newTask))
                {
                    return ResponseModel<object>.Fail(500, "Error while adding to Db");
                }

                if (!await _dbRepo.SaveDbAsync())
                {
                    return ResponseModel<object>.Fail(500, "Db Error");
                }

                return ResponseModel<object>.Success(default);
            }
            catch (Exception)
            {
                return ResponseModel<object>.Fail(500, "DB Error");
            }
        }
        public async Task<ResponseModel<object>> UpdateTaskToDB(UpdateTaskDto model)
        {
            
            var task = await _dbRepo.TaskRepo.GetTaskByTaskId(model.Id);

            if (task == null)
            {
                return ResponseModel<object>.Fail(403, "Task not found");
            } 
             
            task.title = model.Title;
            task.Summary = model.Summary;
            task.status = model.Status; 

            try
            {
                if (!_dbRepo.TaskRepo.Put(task))
                {
                    return ResponseModel<object>.Fail(500, "Error while updating to Db");
                }

                if (!await _dbRepo.SaveDbAsync())
                {
                    return ResponseModel<object>.Fail(500, "Db Error");
                }

                return ResponseModel<object>.Success(default);
            }
            catch (Exception)
            {
                return ResponseModel<object>.Fail(500, "DB Error");
            }
        }
        public async Task<ResponseModel<object>> DeleteTaskToDB(string taskId)
        {
            var task = await _dbRepo.TaskRepo.GetTaskByTaskId(taskId);

            if (task == null)
            {
                return ResponseModel<object>.Fail(403, "Task not found");
            }  

            try
            {
                if (! await _dbRepo.TaskRepo.Delete(task))
                {
                    return ResponseModel<object>.Fail(500, "Error while deleting");
                }

                if (!await _dbRepo.SaveDbAsync())
                {
                    return ResponseModel<object>.Fail(500, "Db Error");
                }

                return ResponseModel<object>.Success(default);
            }
            catch (Exception)
            {
                return ResponseModel<object>.Fail(500, "DB Error");
            }
        }
        public async Task<ResponseModel<IList<TaskDto>>> GetTaskListByAccountId(string accountId)
        { 
            IList<TaskDto> taskList = await _dbRepo.TaskRepo.GetTaskListByAccountId(accountId);
            List<TaskDto> orderedTaskList = new List<TaskDto>();
            var taskNo = 1;
            foreach (TaskDto task in taskList)
            {
                orderedTaskList.Add(new TaskDto(taskNo, task));
                taskNo++;
            }

            return ResponseModel<IList<TaskDto>>.Success(orderedTaskList); 
        }
    }
}
