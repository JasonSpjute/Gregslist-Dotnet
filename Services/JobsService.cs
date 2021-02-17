using dngregslist.db;
using System;
using System.Collections.Generic;
using dngregslist.Models;

namespace dngregslist.Services
{
    public class JobsService
    {
        public IEnumerable<Job> Get()
        {
            return FAKEDB.Jobs;
        }
        public Job Get(String id)
        {
            Job jobToReturn = FAKEDB.Jobs.Find(j => j.Id == id);
            if (jobToReturn == null)
            {
                throw new Exception("Invalid Id");
            }
            return jobToReturn;
        }
        public Job Create(Job newJob)
        {
            FAKEDB.Jobs.Add(newJob);
            return newJob;
        }
        public Job Edit(Job updated)
        {
            Job updatedJob = FAKEDB.Jobs.Find(j => j.Id == updated.Id);
            if (updatedJob == null)
            {
                throw new Exception("invalid Id");
            }
            FAKEDB.Jobs.Remove(updatedJob);
            FAKEDB.Jobs.Add(updated);
            return updated;
        }
        public String Delete(string id)
        {
            Job removedJob = FAKEDB.Jobs.Find(j => j.Id == id);
            if (removedJob == null)
            {
                throw new Exception("Invalid Id");
            }
            FAKEDB.Jobs.Remove(removedJob);
            return "Deleted";
        }
    }
}