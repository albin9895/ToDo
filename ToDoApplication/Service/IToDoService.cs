using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public interface IToDoService
    {
        DeleteResponseModel Delete(ToDoListModel model);
        RawResponseModel<ToDoListModel> Save(ToDoListModel model);

    }
}
