
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Entities.Repository;
using ToDoApplication.Entity;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public class ToDoListService : IToDoListService
    {
        private readonly IRepository<ToDo> _repository;

        public ToDoListService(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public IEnumerable<ToDoListModel> Get(ToDoListModel model)
        {
            var predicate = PredicateBuilder.New<ToDo>(true);            
            var rows = _repository.Find(predicate);
            var results = rows.Select(x => new ToDoListModel()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                CreatedAt = x.CreatedAt
            });
            return results;
        }
        public IEnumerable<ToDoListModel> GetById(ToDoListModel model)
        {
            var predicate = PredicateBuilder.New<ToDo>(true);
            if(model.Id >0)
            {
                predicate.And(x => x.Id==model.Id);
            }
            var rows = _repository.Find(predicate);
            var results = rows.Select(x => new ToDoListModel()
            {
                Id = x.Id,
                TaskName = x.TaskName,
                CreatedAt = x.CreatedAt
            });
            return results;
        }
    }
}
