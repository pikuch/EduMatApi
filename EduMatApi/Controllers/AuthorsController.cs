using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.JsonPatch;
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

        public AuthorsController(
            ILogger<AuthorsController> logger,
            IMapper mapper,
            IRepository<Author> authorRepository)
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

        /// <summary>
        /// Deletes an existing author
        /// </summary>
        /// <returns>Only a status code</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("Deletes an existing author", "DELETE /Authors/5")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Author deleted succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Author could not be deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Author not found")]
        public async Task<ActionResult<AuthorReadDto>> DeleteAuthor(int id)
        {
            var foundAuthor = await _authorRepository.GetByIdAsync(id);
            if (foundAuthor == null)
            {
                return NotFound();
            }

            bool result = await _authorRepository.DeleteAsync(id);
            
            return result ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing author
        /// </summary>
        /// <returns>Updated author</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Updates an existing author", "PUT /Authors/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Author updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Author could not be updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Author not found")]
        public async Task<ActionResult<AuthorReadDto>> UpdateAuthor(int id, AuthorUpdateDto author)
        {
            var foundAuthor = await _authorRepository.GetByIdAsync(id);
            if (foundAuthor == null)
            {
                return NotFound();
            }

            _mapper.Map(author, foundAuthor);

            bool result = await _authorRepository.UpdateAsync(foundAuthor);
            
            return result ? Ok(_mapper.Map<AuthorReadDto>(foundAuthor)) : BadRequest();
        }

        /// <summary>
        /// Partially updates an existing author
        /// </summary>
        /// <returns>Updated author</returns>
        [HttpPatch("{id}")]
        [SwaggerOperation("Partially updates an existing author", "PATCH /Authors/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Author updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Author could not be updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Author not found")]
        public async Task<ActionResult<AuthorReadDto>> PartiallyUpdateAuthor(int id, [FromBody] JsonPatchDocument<AuthorUpdateDto> authorUpdate)
        {
            var foundAuthor = await _authorRepository.GetByIdAsync(id);
            if (foundAuthor == null)
            {
                return NotFound();
            }

            var existingAuthorDto = _mapper.Map<AuthorUpdateDto>(foundAuthor);

            authorUpdate.ApplyTo(existingAuthorDto);

            ModelState.ClearValidationState(nameof(existingAuthorDto));
            if (!TryValidateModel(existingAuthorDto, nameof(existingAuthorDto)))
            {
                return BadRequest();
            }

            _mapper.Map(existingAuthorDto, foundAuthor);

            bool result = await _authorRepository.UpdateAsync(foundAuthor);

            return result ? Ok(_mapper.Map<AuthorReadDto>(foundAuthor)) : BadRequest();
        }
    }
}