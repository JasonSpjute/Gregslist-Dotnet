using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dngregslist.Models;
using System;
using dngregslist.Services;

namespace dngregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly JobsService _js;
        public JobsController(JobsService js)
        {
            _js = js;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(_js.Get());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(string id)
        {
            try
            {
                Job jobToReturn = _js.Get(id);
                return Ok(jobToReturn);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                Job addJob = _js.Create(newJob);
                return Ok(addJob);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Job> Edit([FromBody] Job updated, string id)
        {
            try
            {
                updated.Id = id;
                Job updatedJob = _js.Edit(updated);
                return Ok(updatedJob);
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
                _js.Delete(id);
                return Ok("Deleted");
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}