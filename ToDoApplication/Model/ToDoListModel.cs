using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    public class ToDoListModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
