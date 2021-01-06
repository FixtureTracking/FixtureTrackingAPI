using FixtureTracking.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FixtureTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = userService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = userService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}/debits")]
        public IActionResult GetDebits(Guid id)
        {
            var result = userService.GetDebits(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = userService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
