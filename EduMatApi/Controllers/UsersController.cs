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
        /// <param name="userLoginDto">Login and password</param>
        [HttpPost("Login")]
        [SwaggerOperation("Authenticates the user", "POST /Users/Login")]
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

        /// <summary>
        /// Registers a new admin
        /// </summary>
        /// <param name="userRegisterDto">Login, email and password of the new admin</param>
        [HttpPost("Register")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Registers a new admin", "POST /Users/Register")]
        [SwaggerResponse(StatusCodes.Status200OK, "Admin registered")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "User data is invalid")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User not authorized")]
        public async Task<IActionResult> Registration([FromBody] UserRegisterDto userRegisterDto)
        {
            // login already taken
            var existingUser = await _userRepository.GetByLoginAsync(userRegisterDto.Login);
            if (existingUser != null)
            {
                _logger.LogInformation($"[{DateTime.Now}] Failed to register new user because {userRegisterDto.Login} already exists.");
                return BadRequest();
            }

            // email already taken
            var allUsers = await _userRepository.GetAllAsync();
            if (allUsers.Any(u => u.Email == userRegisterDto.Email))
            {
                _logger.LogInformation($"[{DateTime.Now}] Failed to register new user because user with email {userRegisterDto.Email} already exists.");
                return BadRequest();
            }

            var newUser = _mapper.Map<User>(userRegisterDto);
            newUser.Role = "Admin";

            var addedUser = await _userRepository.AddAsync(newUser);

            if (addedUser != null)
            {
                _logger.LogInformation($"[{DateTime.Now}] Successfully registered new user {addedUser.Login}.");
                return Ok();
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] Failed to register new user for unknown reason.");
                return BadRequest();
            }
        }
    }
}
