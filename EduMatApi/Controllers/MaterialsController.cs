using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduMatApi.Controllers
{
    /// <summary>
    /// Controller dealing with materials
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly ILogger<MaterialsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<MaterialType> _materialTypeRepository;
        private readonly IRepository<Material> _materialRepository;

        public MaterialsController(
            ILogger<MaterialsController> logger,
            IMapper mapper,
            IRepository<Author> authorRepository,
            IRepository<MaterialType> materialTypeRepository,
            IRepository<Material> materialRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _materialTypeRepository = materialTypeRepository;
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Gets all materials
        /// </summary>
        /// <returns>A collection of materials</returns>
        [HttpGet]
        [SwaggerOperation("Gets all materials", "GET /Materials")]
        [SwaggerResponse(StatusCodes.Status200OK, "Materials retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No materials found")]
        public async Task<ActionResult<ICollection<MaterialReadDto>>> GetAllMaterials()
        {
            var allMaterials = await _materialRepository.GetAllAsync();
            if (allMaterials.Count > 0)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials returned a {allMaterials.Count} long list of materials.");
                return Ok(_mapper.Map<ICollection<MaterialReadDto>>(allMaterials));
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials returned 404 because it found no materials.");
                return NotFound();
            }
        }

        /// <summary>
        /// Gets material with given id
        /// </summary>
        /// <returns>Chosen material</returns>
        [HttpGet("{id}", Name = "GetMaterial")]
        [SwaggerOperation("Gets a material with given id", "GET /Materials/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material not found")]
        public async Task<ActionResult<ICollection<MaterialReadDto>>> GetMaterial(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material != null)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials/{id} returned requested material.");
                return Ok(_mapper.Map<MaterialReadDto>(material));
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials/{id} returned 404 because the requested material wasn't found.");
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new material
        /// </summary>
        /// <returns>Created material</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Creates a new material", "POST /Materials")]
        [SwaggerResponse(StatusCodes.Status201Created, "Material created succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specified material could not be added")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User isn't authorized to access this endpoint")]
        public async Task<ActionResult<MaterialReadDto>> CreateMaterial(MaterialCreateDto material)
        {
            var referencedAuthor = await _authorRepository.GetByIdAsync(material.AuthorId);
            if (referencedAuthor == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /Materials returned 400 because of invalid authorId.");
                return BadRequest();
            }
            var referencedMaterialType = await _materialTypeRepository.GetByIdAsync(material.MaterialTypeId);
            if (referencedMaterialType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /Materials returned 400 because of invalid materialTypeId.");
                return BadRequest();
            }

            var newMaterial = await _materialRepository.AddAsync(_mapper.Map<Material>(material));
            if (newMaterial == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /Materials returned 400 because it failed to add the material.");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /Materials added a new material with id={newMaterial.Id}.");

                return CreatedAtRoute(
                    nameof(GetMaterial),
                    new {id = newMaterial.Id},
                    _mapper.Map<MaterialReadDto>(newMaterial));
            }
        }

        /// <summary>
        /// Deletes an existing material
        /// </summary>
        /// <returns>Only a status code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Deletes an existing material", "DELETE /Materials/5")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Material deleted succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material could not be deleted")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User isn't authorized to access this endpoint")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material not found")]
        public async Task<ActionResult<MaterialReadDto>> DeleteMaterial(int id)
        {
            var foundMaterial = await _materialRepository.GetByIdAsync(id);
            if (foundMaterial == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] DELETE /Materials/{id} returned 404 because it failed to find the requested material.");
                return NotFound();
            }

            bool result = await _materialRepository.DeleteAsync(id);
            _logger.LogInformation($"[{DateTime.Now}] DELETE /Materials/{id} deleted the requested material.");

            return result ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing material
        /// </summary>
        /// <returns>Updated material</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation("Updates an existing material", "PUT /Materials/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material could not be updated")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "User isn't authorized to access this endpoint")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material not found")]
        public async Task<ActionResult<MaterialReadDto>> UpdateMaterial(int id, MaterialUpdateDto material)
        {
            var referencedAuthor = await _authorRepository.GetByIdAsync(material.AuthorId);
            if (referencedAuthor == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] PUT /Materials/{id} returned 400 because authorId wasn't valid.");
                return BadRequest();
            }
            var referencedMaterialType = await _materialTypeRepository.GetByIdAsync(material.MaterialTypeId);
            if (referencedMaterialType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] PUT /Materials/{id} returned 400 because materialTypeId wasn't valid.");
                return BadRequest();
            }

            var foundMaterial = await _materialRepository.GetByIdAsync(id);
            if (foundMaterial == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] PUT /Materials/{id} returned 404 because the requested material wasn't found.");
                return NotFound();
            }

            _mapper.Map(material, foundMaterial);

            bool result = await _materialRepository.UpdateAsync(foundMaterial);
            _logger.LogInformation($"[{DateTime.Now}] PUT /Materials/{id} updated the requested material.");

            return result ? Ok(_mapper.Map<MaterialReadDto>(foundMaterial)) : BadRequest();
        }

        /// <summary>
        /// Gets filtered materials
        /// </summary>
        /// <returns>A collection of filtered materials</returns>
        [HttpGet("filter/{filterQuery}")]
        [SwaggerOperation("Gets filtered and sorted materials", "GET /Materials/filter/filterQuery?typeId=5&sort=true")]
        [SwaggerResponse(StatusCodes.Status200OK, "Materials retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid filter query")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No materials matching the query found")]
        public async Task<ActionResult<ICollection<MaterialReadDto>>> GetFilteredMaterials([FromQuery] MaterialFilterQuery filterQuery)
        {
            var referencedType = await _materialTypeRepository.GetByIdAsync(filterQuery.typeId);
            if (referencedType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials/filter/filterQuery with typeId={filterQuery.typeId} returned 400 because the requested typeId wasn't found.");
                return BadRequest();
            }

            var allMaterials = await _materialRepository.GetAllAsync();
            var filteredMaterials = allMaterials.Where(material => material.MaterialTypeId == filterQuery.typeId).ToList();
            var sortedMaterials = filterQuery.sort ? filteredMaterials.OrderBy(material => material.PublishDate).ToList() : filteredMaterials;

            if (sortedMaterials.Count > 0)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials/filter/filterQuery with typeId={filterQuery.typeId} returned the filtered material list.");
                return Ok(_mapper.Map<ICollection<MaterialReadDto>>(sortedMaterials));
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /Materials/filter/filterQuery with typeId={filterQuery.typeId} returned 404 because the filtered material list was empty.");
                return NotFound();
            }
        }
    }
}