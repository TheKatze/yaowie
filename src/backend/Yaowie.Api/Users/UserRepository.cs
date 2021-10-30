using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaowie.Api.Users
{
    public interface IUserRepository : IRepository<User, string>
    {
        Task Add(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly List<User> database = new List<User>();

        public IQueryable<User> Entities => database.AsQueryable();

        public Task Add(User user)
        {
            database.Add(user);
            return Task.CompletedTask;
        }
    }
}
