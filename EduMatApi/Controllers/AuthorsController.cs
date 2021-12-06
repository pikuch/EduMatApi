using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EduMatApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Author> _authorRepository;

        public AuthorsController(ILogger<AuthorsController> logger, IMapper mapper, IRepository<Author> authorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>A collection of authors</returns>
        /// <remarks>GET /authors</remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<AuthorReadDto>>> GetAll()
        {
            var allAuthors = await _authorRepository.GetAllAsync();
            if (allAuthors.Count > 0)
            {
                return Ok(_mapper.Map<ICollection<AuthorReadDto>>(allAuthors));
            }
            else
            {
                return NotFound();
            }
        }
    }
}