using System;
using System.Linq;
using System.Threading.Tasks;
using Yaowie.Api.Transactions;

namespace Yaowie.Api.Users
{
    public interface IUserService
    {
        Task CreateUser(UserCreationDto dto);
        Task<User> GetUser(string publicKey);
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

        public Task<User> GetUser(string publicKey)
        {
            var user = userRepository.Entities.SingleOrDefault(u => u.PublicKey.SequenceEqual(Convert.FromBase64String(publicKey))) ?? throw new NotFoundException();

            return Task.FromResult(user);
        }
    }
}
