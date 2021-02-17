using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Model;
using ToDoApplication.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _logic;

        public ToDoController(IToDoService logic)
        {
            _logic = logic;
        }

       
        [HttpPost]
        public IActionResult Create([FromBody] ToDoListModel model)
        {
            var row = this.SaveRow(model);
            return this.Ok(row);
        }


        [HttpPut("{id}")]
        public IActionResult Save(int id,[FromBody] ToDoListModel model)
        {
            model.Id = id;
            var row = this.SaveRow(model);
            return this.Ok(row);
        }


        [HttpDelete]
        public IActionResult Remove([FromBody] ToDoListModel model = null)
        {
           
            if (model == null)
            {
                return this.Ok(new DeleteResponseModel("Can't Delete items due to missing some information or invalid data", false));
            }
            var results = _logic.Delete(model);
            return this.Ok(results);
        }
        private RawResponseModel<ToDoListModel> SaveRow(ToDoListModel model)
        {
            if (model == null)
            {
                return new RawResponseModel<ToDoListModel>(null, "model can't be null!", false);
            }
            var results = _logic.Save(model);
            return results;

        }
    }
}
