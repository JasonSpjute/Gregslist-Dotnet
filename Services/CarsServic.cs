using dngregslist.db;
using System;
using System.Collections.Generic;
using dngregslist.Models;

namespace dngregslist.Services
{
    public class CarsService
    {
        public IEnumerable<Car> Get()
        {
            return FAKEDB.Cars;
        }
        public Car Get(String id)
        {
            Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
            if (carToReturn == null)
            {
                throw new Exception("Invalid Id");
            }
            return carToReturn;
        }
        public Car Create(Car newCar)
        {
            FAKEDB.Cars.Add(newCar);
            return newCar;
        }
        public Car Edit(Car updated)
        {
            Car updatedCar = FAKEDB.Cars.Find(c => c.Id == updated.Id);
            if (updatedCar == null)
            {
                throw new Exception("invalid Id");
            }
            FAKEDB.Cars.Remove(updatedCar);
            FAKEDB.Cars.Add(updated);
            return updated;
        }
        public String Delete(string id)
        {
            Car removedCar = FAKEDB.Cars.Find(c => c.Id == id);
            if (removedCar == null)
            {
                throw new Exception("Invalid Id");
            }
            FAKEDB.Cars.Remove(removedCar);
            return "Deleted";
        }
    }
}