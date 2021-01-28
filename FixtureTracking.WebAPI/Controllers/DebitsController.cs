using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Dtos.Debit;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FixtureTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitsController : ControllerBase
    {
        private readonly IDebitService debitService;

        public DebitsController(IDebitService debitService)
        {
            this.debitService = debitService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = debitService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = debitService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost()]
        public IActionResult Add(DebitForAddDto debitForAddDto)
        {
            var result = debitService.Add(debitForAddDto);
            if (result.Success)
                return CreatedAtAction("GetById", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(DebitForUpdateDto debitForUpdateDto)
        {
            var result = debitService.Update(debitForUpdateDto);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = debitService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
