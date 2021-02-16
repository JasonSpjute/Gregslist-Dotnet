using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using dngregslist.db;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(FAKEDB.Jobs);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(string id)
        {
            try
            {
                Job jobToReturn = FAKEDB.Jobs.Find(j => j.Id == id);
                return Ok(jobToReturn);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                FAKEDB.Jobs.Add(newJob);
                return Ok(newJob);
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
                Job jobToRemove = FAKEDB.Jobs.Find(j => j.Id == id);
                if (FAKEDB.Jobs.Remove(jobToRemove))
                {
                    return Ok("Job Deleted");
                };
                throw new System.Exception("Job does not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}