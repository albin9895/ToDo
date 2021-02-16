using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Entity
{
    public class ToDo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
