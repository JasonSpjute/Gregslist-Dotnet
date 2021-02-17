using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using dngregslist.Services;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;
        public CarsController(CarsService cs)
        {
            _cs = cs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(_cs.Get());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(string id)
        {
            try
            {
                Car carToReturn = _cs.Get(id);
                return Ok(carToReturn);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                Car addCar = _cs.Create(newCar);
                return Ok(addCar);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Car> Edit([FromBody] Car updated, string id)
        {
            try
            {
                updated.Id = id;
                Car updatedCar = _cs.Edit(updated);
                return Ok(updatedCar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                _cs.Delete(id);
                return Ok("Deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}