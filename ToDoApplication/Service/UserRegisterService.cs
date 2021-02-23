using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Entities.Repository;
using ToDoApplication.Entity;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IRepository<User> _repository;

        public UserRegisterService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public RawResponseModel<UserRegisterModel> Save(UserRegisterModel model)
        {
            if (model != null)
            {
            }
            else
            {
                model = new UserRegisterModel();
            }

            var entity = new User();

           
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                entity.FirstName = model.FirstName;
            }
            if (!string.IsNullOrEmpty(model.LastName))
            {
                entity.LastName = model.LastName;
            }
            if (!string.IsNullOrEmpty(model.Username))
            {
                entity.Username = model.Username;
            }
            if (!string.IsNullOrEmpty(model.Password))
            {
                entity.Password = model.Password;
            }


            _repository.Create(entity);
            _repository.Save();
            
            return new RawResponseModel<UserRegisterModel>(model);
        }
    }
}
