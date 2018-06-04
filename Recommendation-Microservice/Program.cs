using System;
using RecommendationMicroservice.Controllers;
using RecommendationMicroservice.Models;

namespace RecommendationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var video = new Video
            {
                Id = "001",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            };
            var rc = new RecommendationController();

            Console.WriteLine(rc.CreateRecommendation(video));
            
        }
    }
}
