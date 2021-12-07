using EduMatApi.DAL.Repositories;

namespace EduMatApi.Authentication
{
    public interface IJwtAuthenticator
    {
        public Task<string?> Authentication(string login, string password, IUserRepository userRepository);
    }
}
