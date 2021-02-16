using System;
using System.ComponentModel.DataAnnotations;

namespace dngregslist.Models
{
    public class Job
    {
        public Job(string company, string jobTitle, int hours, decimal rate, string description)
        {
            Company = company;
            JobTitle = jobTitle;
            Hours = hours;
            Rate = rate;
            Description = description;
        }

        [Required]
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public int Hours { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}