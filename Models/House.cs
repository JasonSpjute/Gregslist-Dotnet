using System;
using System.ComponentModel.DataAnnotations;

namespace dngregslist.Models
{
    public class House
    {
        public House(int bedrooms, int bathrooms, int levels, string imgUrl, int year, decimal price, string description)
        {
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Levels = levels;
            ImgUrl = imgUrl;
            Year = year;
            Price = price;
            Description = description;
        }
        [Required]
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Levels { get; set; }
        public string ImgUrl { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
// bedrooms bathrooms levels imgurl year price description id