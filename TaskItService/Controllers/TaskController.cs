using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace TaskItService.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<Task> _logger;

        public TaskController(ILogger<Task> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<Task> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Task
            {
                TaskId=1,
                Description = "Task 1"
            })
            .ToArray();
        }
    }
}
