using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaowie.Api.Users
{
    public interface IUserService
    {
        Task CreateUser(UserCreationDto dto);
    }

    public record UserCreationDto(string Name, string PublicKey);

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task CreateUser(UserCreationDto dto)
        {
            User user = User.Create(dto.Name, Convert.FromBase64String(dto.PublicKey));
            userRepository.Add(user);

            return Task.CompletedTask;
        }
    }
}
