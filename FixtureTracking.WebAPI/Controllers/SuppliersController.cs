﻿using FixtureTracking.Business.Abstract;
using FixtureTracking.Entities.Dtos.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace FixtureTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = supplierService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet()]
        public IActionResult GetList()
        {
            var result = supplierService.GetList();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpGet("{id}/fixtures")]
        public IActionResult GetFixtures(int id)
        {
            var result = supplierService.GetFixtures(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost()]
        public IActionResult Add(SupplierForAddDto supplierForAddDto)
        {
            var result = supplierService.Add(supplierForAddDto);
            if (result.Success)
                return CreatedAtAction("GetById", new { id = result.Data }, result.Message);
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(SupplierForUpdateDto supplierForUpdateDto)
        {
            var result = supplierService.Update(supplierForUpdateDto);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = supplierService.Delete(id);
            if (result.Success)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
