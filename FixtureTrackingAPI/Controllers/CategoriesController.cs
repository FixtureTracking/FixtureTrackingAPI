using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Dtos.Category;
using Microsoft.AspNetCore.Mvc;

namespace FixtureTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(short id)
        {
            var result = categoryService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = categoryService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}/fixtures")]
        public IActionResult GetFixtures(short id)
        {
            var result = categoryService.GetFixtures(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost()]
        public IActionResult Add(CategoryForAddDto categoryForAddDto)
        {
            var result = categoryService.Add(categoryForAddDto);
            if (result.Success)
                return CreatedAtAction("GetById", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(CategoryForUpdateDto categoryForUpdateDto)
        {
            var result = categoryService.Update(categoryForUpdateDto);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var result = categoryService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
