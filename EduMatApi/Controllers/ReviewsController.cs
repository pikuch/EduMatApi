using AutoMapper;
using EduMatApi.DAL.Repositories;
using EduMatApi.Models.DTOs;
using EduMatApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduMatApi.Controllers
{
    /// <summary>
    /// Controller dealing with reviews
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Material> _materialRepository;

        public ReviewsController(
            ILogger<ReviewsController> logger,
            IMapper mapper,
            IRepository<Review> reviewRepository,
            IRepository<Material> materialRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Gets all reviews
        /// </summary>
        /// <returns>A collection of reviews</returns>
        [HttpGet]
        [SwaggerOperation("Gets all reviews", "GET /Reviews")]
        [SwaggerResponse(StatusCodes.Status200OK, "Reviews retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews found")]
        public async Task<ActionResult<ICollection<ReviewReadDto>>> GetAllReviews()
        {
            var allReviews = await _reviewRepository.GetAllAsync();
            if (allReviews.Count > 0)
            {
                return Ok(_mapper.Map<ICollection<ReviewReadDto>>(allReviews));
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets review with given id
        /// </summary>
        /// <returns>Chosen review</returns>
        [HttpGet("{id}", Name = "GetReview")]
        [SwaggerOperation("Gets a review with given id", "GET /Reviews/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review retrived succesfully")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<ActionResult<ICollection<ReviewReadDto>>> GetReview(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review != null)
            {
                return Ok(_mapper.Map<ReviewReadDto>(review));
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a new review
        /// </summary>
        /// <returns>Created review</returns>
        [HttpPost]
        [SwaggerOperation("Creates a new review", "POST /Reviews")]
        [SwaggerResponse(StatusCodes.Status201Created, "Review created succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specified review could not be added")]
        public async Task<ActionResult<ReviewReadDto>> CreateReview(ReviewCreateDto review)
        {
            var referencedMaterial = await _materialRepository.GetByIdAsync(review.MaterialId);
            if (referencedMaterial == null)
            {
                return BadRequest();
            }

            var newReview = await _reviewRepository.AddAsync(_mapper.Map<Review>(review));
            if (newReview == null)
            {
                return BadRequest();
            }
            else
            {
                return CreatedAtRoute(
                    nameof(GetReview),
                    new {id = newReview.Id},
                    _mapper.Map<ReviewReadDto>(newReview));
            }
        }

        /// <summary>
        /// Deletes an existing review
        /// </summary>
        /// <returns>Only a status code</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation("Deletes an existing review", "DELETE /Reviews/5")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Review deleted succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Review could not be deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<ActionResult<ReviewReadDto>> DeleteReview(int id)
        {
            var foundReview = await _reviewRepository.GetByIdAsync(id);
            if (foundReview == null)
            {
                return NotFound();
            }

            bool result = await _reviewRepository.DeleteAsync(id);
            
            return result ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Updates an existing review
        /// </summary>
        /// <returns>Updated review</returns>
        [HttpPut("{id}")]
        [SwaggerOperation("Updates an existing review", "PUT /Reviews/5")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review updated succesfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Review could not be updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<ActionResult<ReviewReadDto>> UpdateReview(int id, ReviewUpdateDto review)
        {
            var referencedMaterial = await _materialRepository.GetByIdAsync(review.MaterialId);
            if (referencedMaterial == null)
            {
                return BadRequest();
            }

            var foundReview = await _reviewRepository.GetByIdAsync(id);
            if (foundReview == null)
            {
                return NotFound();
            }

            _mapper.Map(review, foundReview);

            bool result = await _reviewRepository.UpdateAsync(foundReview);
            
            return result ? Ok(_mapper.Map<ReviewReadDto>(foundReview)) : BadRequest();
        }
    }
}