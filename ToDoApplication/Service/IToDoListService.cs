using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public interface IToDoListService
    {
        IEnumerable<ToDoListModel> Get(ToDoListModel model);
        IEnumerable<ToDoListModel> GetById(ToDoListModel model);
    }
}
