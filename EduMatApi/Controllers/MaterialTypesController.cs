using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduMatApi.Controllers
{
    /// <summary>
    /// Controller dealing with material types
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MaterialTypesController : ControllerBase
    {
        private readonly ILogger<MaterialTypesController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<MaterialType> _materialTypeRepository;

        public MaterialTypesController(
            ILogger<MaterialTypesController> logger,
            IMapper mapper,
            IRepository<MaterialType> materialTypeRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _materialTypeRepository = materialTypeRepository;
        }

        /// <summary>
        /// Gets all material types
        /// </summary>
        /// <returns>A collection of material types</returns>
        [HttpGet]
        [SwaggerOperation("Gets all material types", "GET /MaterialTypes")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material types retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No material types found")]
        public async Task<ActionResult<ICollection<MaterialTypeReadDto>>> GetAllMaterialTypes()
        {
            var allMaterialTypes = await _materialTypeRepository.GetAllAsync();
            if (allMaterialTypes.Count > 0)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /MaterialTypes returned {allMaterialTypes.Count} materialTypes.");
                return Ok(_mapper.Map<ICollection<MaterialTypeReadDto>>(allMaterialTypes));
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /MaterialTypes returned 404 after finding no materialTypes.");
                return NotFound();
            }
        }

        /// <summary>
        /// Gets material type with given id
        /// </summary>
        /// <returns>Chosen material type</returns>
        [HttpGet("{id}", Name = "GetMaterialType")]
        [SwaggerOperation("Gets a material type with given id", "GET /MaterialTypes/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material type retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material type not found")]
        public async Task<ActionResult<ICollection<MaterialTypeReadDto>>> GetMaterialType(int id)
        {
            var materialType = await _materialTypeRepository.GetByIdAsync(id);
            if (materialType != null)
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /MaterialTypes/{id} returned requested materialType.");
                return Ok(_mapper.Map<MaterialTypeReadDto>(materialType));
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] GET /MaterialTypes/{id} didn't find the requested materialType.");
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new material type
        /// </summary>
        /// <returns>Created material type</returns>
        [HttpPost]
        [SwaggerOperation("Creates a new material type", "POST /MaterialTypes")]
        [SwaggerResponse(StatusCodes.Status201Created, "Material type created succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specified material type could not be added")]
        public async Task<ActionResult<MaterialTypeReadDto>> CreateMaterialType(MaterialTypeCreateDto materialType)
        {
            var newMaterialType = await _materialTypeRepository.AddAsync(_mapper.Map<MaterialType>(materialType));
            if (newMaterialType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /MaterialTypes returned 400 after it failed to add a materialType.");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation($"[{DateTime.Now}] POST /MaterialTypes added a new materialType with id={newMaterialType.Id}.");

                return CreatedAtRoute(
                    nameof(GetMaterialType),
                    new {id = newMaterialType.Id},
                    _mapper.Map<MaterialTypeReadDto>(newMaterialType));
            }
        }

        /// <summary>
        /// Deletes an existing material type
        /// </summary>
        /// <returns>Only a status code</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("Deletes an existing material type", "DELETE /MaterialTypes/5")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Material type deleted succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material type could not be deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material type not found")]
        public async Task<ActionResult<MaterialTypeReadDto>> DeleteMaterialType(int id)
        {
            var foundMaterialType = await _materialTypeRepository.GetByIdAsync(id);
            if (foundMaterialType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] DELETE /MaterialTypes/{id} didn't find the requested materialType.");
                return NotFound();
            }

            bool result = await _materialTypeRepository.DeleteAsync(id);
            _logger.LogInformation($"[{DateTime.Now}] DELETE /MaterialTypes/{id} deleted the requested materialType.");

            return result ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing material type
        /// </summary>
        /// <returns>Updated material type</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Updates an existing material type", "PUT /MaterialTypes/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material type updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material type could not be updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material type not found")]
        public async Task<ActionResult<MaterialTypeReadDto>> UpdateMaterialType(int id, MaterialTypeUpdateDto materialType)
        {
            var foundMaterialType = await _materialTypeRepository.GetByIdAsync(id);
            if (foundMaterialType == null)
            {
                _logger.LogInformation($"[{DateTime.Now}] PUT /MaterialTypes/{id} didn't find the requested materialType.");
                return NotFound();
            }

            _mapper.Map(materialType, foundMaterialType);

            bool result = await _materialTypeRepository.UpdateAsync(foundMaterialType);
            _logger.LogInformation($"[{DateTime.Now}] PUT /MaterialTypes/{id} updated the requested materialType.");

            return result ? Ok(_mapper.Map<MaterialTypeReadDto>(foundMaterialType)) : BadRequest();
        }
    }
}