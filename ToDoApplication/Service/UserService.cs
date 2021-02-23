using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApplication.Entities.Repository;
using ToDoApplication.Entity;
using ToDoApplication.Helper;
using ToDoApplication.Model;

namespace ToDoApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var predicate = PredicateBuilder.New<User>(true);
            var rows = _repository.Find(predicate);
            var user = await Task.Run(() => rows.SingleOrDefault(x => x.Username == username && x.Password == password));
            
            if (user == null)
                return null;

            
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var predicate = PredicateBuilder.New<User>(true);
            var rows = _repository.Find(predicate);
            return await Task.Run(() => rows.WithoutPasswords());
        }
        public List<User> Get()
        {
            var rows = new List<User>();
            rows = _repository.GetAll().ToList();
            return rows;
            //var results = rows.Select(x => new UserRegisterModel()
            //{
            //   Username=x.Username,
            //   FirstName=x.FirstName,
            //   LastName=x.LastName
            //});
            //return results.ToList();
        }
    }
}
