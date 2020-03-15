using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Application.Interface.Repository;
using Web.API.Domain.Entity.User;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository _repository;
        
        public UsersController(IGenericRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAll<User>();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _repository.GetById<User>(id);
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] User value)
        {
            if (value == null)
                throw new ArgumentNullException(paramName: nameof(value));

            _repository.Create<User>(value);
            _repository.Save();
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var user = _repository.GetById<User>(id);

            if (value == null)
                throw new ArgumentNullException(paramName: nameof(value));

            user.FirstName = value.FirstName;
            user.LastName = value.LastName;
            user.MiddleName = value.MiddleName;
            user.Username = value.Username;
            user.Password = value.Password;

            _repository.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete<User>(id);
            _repository.Save();
        }
    }
}
