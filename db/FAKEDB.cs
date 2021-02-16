using System.Collections.Generic;
using dngregslist.Models;

namespace dngregslist.db
{
    public class FAKEDB
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
        public static List<House> Houses { get; set; } = new List<House>();
        public static List<Job> Jobs { get; set; } = new List<Job>();
    }
}