
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
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _repository;

        public ToDoService(IRepository<ToDo> repository)
        {
            _repository = repository;
        }

        public RawResponseModel<ToDoListModel> Save(ToDoListModel model)
        {
            if (model != null)
            {
            }
            else
            {
                model = new ToDoListModel();
            }

            var entity = new ToDo();

            if (model.Id > 0)
            {
                entity.Id = model.Id;
            }
            if(!string.IsNullOrEmpty(model.TaskName ))
            {
                entity.TaskName = model.TaskName;
            }           
            entity.CreatedAt = DateTime.UtcNow;

            if (model.Id == 0)
            {
                _repository.Create(entity);
            }
            else
            {
                _repository.Update(entity);
            }

            _repository.Save();
            model.Id = entity.Id;
            return new RawResponseModel<ToDoListModel>(model);

        }

        public DeleteResponseModel Delete(ToDoListModel model)
        {
            var entity = new ToDo();
            if (model.Id <= 0)
            {
                return new DeleteResponseModel("Can't delete items due to missing some information or invalid data", false);
            }
            else
            {
                entity.Id = model.Id;
            }

            _repository.DeleteBy(x => x.Id == model.Id);
            _repository.Save();
            return new DeleteResponseModel("Deleted", true);
        }
    }
}
