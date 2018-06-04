using System;
using System.Collections.Generic;
using System.Text;
using RecommendationMicroservice.Models;

namespace RecommendationMicroservice.Views
{
    public class RecommendationView
    {
        public static void ShowRecommendations(Recommendation recommend)
        {
            foreach (var video in recommend.Recommendations)
            {
                Console.WriteLine(video.Id + " with the name: " + video.Name);
                
            }
        }
    }
}
