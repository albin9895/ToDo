using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    public class GetResponseModel<T>
    {
        public int TotalItems { get; set; }       
        public List<T> Data { get; set; }
    }
}
