using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TaskItService.Models;
using TaskItService.Services;

namespace TaskItService.Controllers
{
    [Authorize(policy:"api")]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<Models.Task> _logger;
        private readonly TaskItDBContext _taskItDBContext;
        public TaskController(ILogger<Models.Task> logger, TaskItDBContext taskItDBContext)
        {
            _logger = logger;
            _taskItDBContext = taskItDBContext;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<Models.Task> Get()
        {
            return new TaskService(_taskItDBContext, _logger).GetAllTasks()
            .ToArray();
        }

        [HttpPut(Name = "AddTask")]
        public bool Add(string description)
        {
            return new TaskService(_taskItDBContext, _logger).AddTask(description);
        }

        [HttpPatch(Name = "UpdateTask")]
        public bool Update(int taskId, string description)
        {
            bool updateResult = new TaskService(_taskItDBContext, _logger).UpdateTask(taskId, description);
            return updateResult;
        }

        [HttpPost(Name = "DeleteTask")]
        public bool Delete(int taskId)
        {
            bool deleteResult = new TaskService(_taskItDBContext, _logger).DeleteTask(taskId);
            return deleteResult;
        }
    }
}
