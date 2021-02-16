using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using dngregslist.db;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
        {
            try
            {
                return Ok(FAKEDB.Houses);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<House> GetHouseById(string id)
        {
            try
            {
                House houseToReturn = FAKEDB.Houses.Find(h => h.Id == id);
                return Ok(houseToReturn);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                FAKEDB.Houses.Add(newHouse);
                return Ok(newHouse);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(string id)
        {
            try
            {
                House houseToRemove = FAKEDB.Houses.Find(h => h.Id == id);
                if (FAKEDB.Houses.Remove(houseToRemove))
                {
                    return Ok("House Deleted");
                };
                throw new System.Exception("House does not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}