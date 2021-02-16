using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Model
{
    public class RawResponseModel<T>
    {
        public RawResponseModel(T Data, string message = "", bool success = true)
        {
            this.Data = Data;
            this.Message = message;
            this.Success = success;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
