using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ToDoApplication.Hubs;
using ToDoApplication.Model;
using ToDoApplication.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        private IToDoListService _logic;
        private readonly IHubContext<NotificationHub> _hubContext;

        public ToDoListController(IToDoListService logic, IHubContext<NotificationHub> hubContext)
        {
            _logic = logic;
            _hubContext = hubContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] ToDoListModel model = null)
        {
            if (model == null)
            {
                model = new ToDoListModel();
            }
            var results = _logic.GetById(model);
            return this.Ok(results);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ToDoListModel model = null)
        {

            if (model == null)
            {
                model = new ToDoListModel();
            }
            var results = _logic.Get(model);
            return this.Ok(results);
        }


    }
}
