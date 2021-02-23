using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public interface IUserRegisterService
    {
        RawResponseModel<UserRegisterModel> Save(UserRegisterModel model);
    }
}
