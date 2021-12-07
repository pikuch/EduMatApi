using EduMatApi.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduMatApi.Authentication
{
    public class JwtAuthenticator : IJwtAuthenticator
    {
        private readonly string _key;
        private readonly int _expirationPeriod = 1;
        public JwtAuthenticator(string key)
        {
            _key = key;
        }

        public async Task<string?> Authentication(string login, string password, IUserRepository userRepository)
        {
            var foundUser = await userRepository.GetByLoginAsync(login);
            if (foundUser == null || foundUser.Password != password)
            {
                return null;
            }

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, foundUser.Login),
                        new Claim(ClaimTypes.Role, foundUser.Role)
                    }),
                Expires = DateTime.UtcNow.AddHours(_expirationPeriod),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
