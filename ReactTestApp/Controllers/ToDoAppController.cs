using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReactTestApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoAppController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<ToDo> Todos()
        {
            ToDo One = new ToDo();
            One.TaskName = "Get Some";
            One.TaskDescription = "Go get some, yo";

            return Enumerable.Range(1, 1).Select(t => new ToDo
            {
                TaskName = "Get Some",
                TaskDescription = "Go get some, yo"
            });
        }

        public class ToDo
        {
            public string TaskName { get; set; }
            public string TaskDescription { get; set; }
            public bool IsDone { get; set; }
        }
    }
}