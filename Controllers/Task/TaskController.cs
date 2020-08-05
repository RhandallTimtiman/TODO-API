using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tda.core.Models.Task;
using tda.core.Services;

namespace TodoAPI.Controllers.Task
{
    [ApiController]
    [Route("tda/api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTaskModel model)
        {
            var response = await taskService.CreateTask(model);

            return Ok(response);
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get([FromRoute]string guid)
        {
            var response = await taskService.ShowTask(Guid.Parse(guid));

            return Ok(response);
        }
    }
}
