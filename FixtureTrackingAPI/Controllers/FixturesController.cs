using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Concrete;
using FixtureTracking.Entities.Dtos.Fixture;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FixtureTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixturesController : ControllerBase
    {
        private readonly IFixtureService fixtureService;

        public FixturesController(IFixtureService fixtureService)
        {
            this.fixtureService = fixtureService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = fixtureService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = fixtureService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost()]
        public IActionResult Add(FixtureForAddDto fixtureForAddDto)
        {
            var result = fixtureService.Add(fixtureForAddDto);
            if (result.Success)
                return CreatedAtAction("GetById", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Fixture fixture)
        {
            var result = fixtureService.Update(fixture);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = fixtureService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
