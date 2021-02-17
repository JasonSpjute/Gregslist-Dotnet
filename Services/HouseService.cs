using dngregslist.db;
using System;
using System.Collections.Generic;
using dngregslist.Models;

namespace dngregslist.Services
{
    public class HousesService
    {
        public IEnumerable<House> Get()
        {
            return FAKEDB.Houses;
        }
        public House Get(String id)
        {
            House houseToReturn = FAKEDB.Houses.Find(h => h.Id == id);
            if (houseToReturn == null)
            {
                throw new Exception("Invalid Id");
            }
            return houseToReturn;
        }
        public House Create(House newHouse)
        {
            FAKEDB.Houses.Add(newHouse);
            return newHouse;
        }
        public House Edit(House updated)
        {
            House updatedHouse = FAKEDB.Houses.Find(h => h.Id == updated.Id);
            if (updatedHouse == null)
            {
                throw new Exception("invalid Id");
            }
            FAKEDB.Houses.Remove(updatedHouse);
            FAKEDB.Houses.Add(updated);
            return updated;
        }
        public String Delete(string id)
        {
            House removedHouse = FAKEDB.Houses.Find(h => h.Id == id);
            if (removedHouse == null)
            {
                throw new Exception("Invalid Id");
            }
            FAKEDB.Houses.Remove(removedHouse);
            return "Deleted";
        }
    }
}