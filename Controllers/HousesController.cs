using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using System;
using dngregslist.Services;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        private readonly HousesService _hs;
        public HousesController(HousesService hs)
        {
            _hs = hs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
        {
            try
            {
                return Ok(_hs.Get());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<House> GetHouseById(string id)
        {
            try
            {
                House houseToReturn = _hs.Get(id);
                return Ok(houseToReturn);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                House addHouse = _hs.Create(newHouse);
                return Ok(addHouse);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<House> Edit([FromBody] House updated, string id)
        {
            try
            {
                updated.Id = id;
                House updatedHouse = _hs.Edit(updated);
                return Ok(updatedHouse);
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
                _hs.Delete(id);
                return Ok("deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}