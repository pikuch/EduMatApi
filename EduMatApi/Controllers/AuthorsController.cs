using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduMatApi.Controllers
{
    /// <summary>
    /// Controller dealing with authors
    /// </summary>
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
        [HttpGet]
        [SwaggerOperation("Gets all authors", "GET /Authors")]
        [SwaggerResponse(StatusCodes.Status200OK, "Authors retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No authors found")]
        public async Task<ActionResult<ICollection<AuthorReadDto>>> GetAllAuthors()
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

        /// <summary>
        /// Gets author with given id
        /// </summary>
        /// <returns>Chosen author</returns>
        [HttpGet("{id}", Name = "GetAuthor")]
        [SwaggerOperation("Gets an author with given id", "GET /Authors/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Author retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Author not found")]
        public async Task<ActionResult<ICollection<AuthorReadDto>>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author != null)
            {
                return Ok(_mapper.Map<AuthorReadDto>(author));
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new author
        /// </summary>
        /// <returns>Created author</returns>
        [HttpPost]
        [SwaggerOperation("Creates a new author", "POST /Authors")]
        [SwaggerResponse(StatusCodes.Status201Created, "Author created succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specified author could not be added")]
        public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreateDto author)
        {
            var newAuthor = await _authorRepository.AddAsync(_mapper.Map<Author>(author));
            if (newAuthor == null)
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtRoute(
                    nameof(GetAuthor),
                    new {id = newAuthor.Id},
                    _mapper.Map<AuthorReadDto>(newAuthor));
            }
        }

    }
}