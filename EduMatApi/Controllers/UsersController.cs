using AutoMapper;
using EduMatApi.Authentication;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.Authentification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduMatApi.Controllers
{
    /// <summary>
    /// Controller dealing with user authentification
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticator _jwtAuthenticator;
        private readonly IUserRepository _userRepository;

        public UsersController(
            ILogger<UsersController> logger,
            IMapper mapper,
            IJwtAuthenticator jwtAuthenticator,
            IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _jwtAuthenticator = jwtAuthenticator;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Authenticates user
        /// </summary>
        /// <param name="userLoginDto">login and password</param>
        [HttpPost("Login")]
        [SwaggerOperation("Authenticates the user", "POST /User/Login")]
        [SwaggerResponse(StatusCodes.Status200OK, "User authorized")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User data is invalid")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User not authorized")]
        public async Task<IActionResult> Authentication([FromBody] UserLoginDto userLoginDto)
        {
            var token = await _jwtAuthenticator.Authentication(userLoginDto.Login, userLoginDto.Password, _userRepository);
            if (token == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] Failed login attempt using login {userLoginDto.Login}");
                return Unauthorized();
            }
            _logger.LogInformation($"[{DateTime.Now}] Successful login by {userLoginDto.Login}");
            return Ok(token);
        }
    }
}
