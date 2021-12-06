using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

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
        /// <remarks>
        /// GET /Authors
        /// </remarks>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <remarks>
        /// GET /Authors/5
        /// </remarks>
        [HttpGet("{id}", Name = "GetAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        /// <remarks>
        /// POST /Authors
        /// {
        ///     "Name": "AuthorsName",
        ///     "Description": "AuthorsDescription"
        /// }
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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