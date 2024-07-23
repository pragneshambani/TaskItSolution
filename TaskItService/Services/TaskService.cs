using TaskItService.Models;

namespace TaskItService.Services
{
    public class TaskService
    {
        private readonly ILogger<Models.Task> _logger;
        private readonly TaskItDBContext context;
        public TaskService(TaskItDBContext taskItDBContext, ILogger<Models.Task> logger)
        {
            context = taskItDBContext;
            _logger = logger;
        }
        public bool AddTask(string description)
        {
            try
            {
                Models.Task task = new Models.Task()
                {
                    Description = description
                };
                context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public bool UpdateTask(int taskId, string description)
        {
            try
            {
                Models.Task task = new Models.Task()
                {
                    Description = description,
                    TaskId = taskId
                };
                context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                _logger.LogError(ex.Message, ex);
                return false;
            }
            
        }

        public bool DeleteTask(int taskId)
        {
            try
            {
                Models.Task task = new Models.Task()
                {
                    TaskId = taskId
                };
                context.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return false;
            }
        }

        public List<Models.Task> GetAllTasks()
        {
            return context.Task.ToList();
        }
    }
}
