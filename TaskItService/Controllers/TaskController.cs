using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TaskItService.Models;

namespace TaskItService.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<Models.Task> _logger;

        public TaskController(ILogger<Models.Task> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTasks")]
        public IEnumerable<Models.Task> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Models.Task
            {
                TaskId=1,
                Description = "Task 1"
            })
            .ToArray();
        }
    }
}
