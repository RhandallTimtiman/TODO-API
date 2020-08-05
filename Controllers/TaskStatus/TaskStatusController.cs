using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tda.core.Models.TaskStatus;
using tda.core.Services;

namespace TodoAPI.Controllers.TaskStatus
{
    [ApiController]
    [Route("tda/api/v1/[controller]")]

    public class TaskStatusController : Controller
    {
        private readonly ITaskStatusService taskStatusService;

        public TaskStatusController(ITaskStatusService taskStatusService)
        {
            this.taskStatusService = taskStatusService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTaskStatusModel model)
        {
            var response = await taskStatusService.CreateTaskStatus(model);

            return Ok(response);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get([FromRoute]string guid)
        {
            var response = await taskStatusService.ShowTaskStatus(Guid.Parse(guid));

            return Ok(response);
        }
    }
}
