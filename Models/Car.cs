using System;
using System.ComponentModel.DataAnnotations;

namespace dngregslist.Models
{
    public class Car
    {
        public Car(string make, string model, int year, decimal price, string description, string imgUrl)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            Description = description;
            ImgUrl = imgUrl;

        }

        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }

}
// make model year price description imgurl