using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Dtos.Department;
using Microsoft.AspNetCore.Mvc;

namespace FixtureTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = departmentService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = departmentService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}/users")]
        public IActionResult GetUsers(int id)
        {
            var result = departmentService.GetUsers(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost()]
        public IActionResult Add(DepartmentForAddDto departmentForAddDto)
        {
            var result = departmentService.Add(departmentForAddDto);
            if (result.Success)
                return CreatedAtAction("GetById", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(DepartmentForUpdateDto departmentForUpdateDto)
        {
            var result = departmentService.Update(departmentForUpdateDto);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = departmentService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
