using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Model;
using ToDoApplication.Service;

namespace ToDoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private IUserRegisterService _logic;

        public UserRegisterController(IUserRegisterService logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRegisterModel model)
        {
            var row = this.SaveRow(model);
            return this.Ok(row);
        }
        private RawResponseModel<UserRegisterModel> SaveRow(UserRegisterModel model)
        {
            if (model == null)
            {
                return new RawResponseModel<UserRegisterModel>(null, "model can't be null!", false);
            }
            var results = _logic.Save(model);
            return results;

        }


    }
}
