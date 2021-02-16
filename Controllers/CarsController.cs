using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using dngregslist.db;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FAKEDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(string id)
        {
            try
            {
                Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
                return Ok(carToReturn);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FAKEDB.Cars.Add(newCar);
                return Ok(newCar);
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
                Car carToRemove = FAKEDB.Cars.Find(c => c.Id == id);
                if (FAKEDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car Deleted");
                };
                throw new System.Exception("Car does not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}