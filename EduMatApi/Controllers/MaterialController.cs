using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
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
                return Ok(_mapper.Map<ICollection<MaterialReadDto>>(allMaterials));
            }
            else
            {
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
                return Ok(_mapper.Map<MaterialReadDto>(material));
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new material
        /// </summary>
        /// <returns>Created material</returns>
        [HttpPost]
        [SwaggerOperation("Creates a new material", "POST /Materials")]
        [SwaggerResponse(StatusCodes.Status201Created, "Material created succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specified material could not be added")]
        public async Task<ActionResult<MaterialReadDto>> CreateMaterial(MaterialCreateDto material)
        {
            var referencedAuthor = await _authorRepository.GetByIdAsync(material.AuthorId);
            if (referencedAuthor == null)
            {
                return BadRequest();
            }
            var referencedMaterialType = await _materialTypeRepository.GetByIdAsync(material.MaterialTypeId);
            if (referencedMaterialType == null)
            {
                return BadRequest();
            }

            var newMaterial = await _materialRepository.AddAsync(_mapper.Map<Material>(material));
            if (newMaterial == null)
            {
                return BadRequest();
            }
            else
            {
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
        [SwaggerOperation("Deletes an existing material", "DELETE /Materials/5")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Material deleted succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material could not be deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material not found")]
        public async Task<ActionResult<MaterialReadDto>> DeleteMaterial(int id)
        {
            var foundMaterial = await _materialRepository.GetByIdAsync(id);
            if (foundMaterial == null)
            {
                return NotFound();
            }

            bool result = await _materialRepository.DeleteAsync(id);
            
            return result ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing material
        /// </summary>
        /// <returns>Updated material</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Updates an existing material", "PUT /Materials/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Material updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Material could not be updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Material not found")]
        public async Task<ActionResult<MaterialReadDto>> UpdateMaterial(int id, MaterialUpdateDto material)
        {
            var referencedAuthor = await _authorRepository.GetByIdAsync(material.AuthorId);
            if (referencedAuthor == null)
            {
                return BadRequest();
            }
            var referencedMaterialType = await _materialTypeRepository.GetByIdAsync(material.MaterialTypeId);
            if (referencedMaterialType == null)
            {
                return BadRequest();
            }

            var foundMaterial = await _materialRepository.GetByIdAsync(id);
            if (foundMaterial == null)
            {
                return NotFound();
            }

            _mapper.Map(material, foundMaterial);

            bool result = await _materialRepository.UpdateAsync(foundMaterial);
            
            return result ? Ok(_mapper.Map<MaterialReadDto>(foundMaterial)) : BadRequest();
        }
    }
}