using RecommendationMicroservice.Controllers;
using RecommendationMicroservice.Models;
using Xunit;

namespace RecommendationMicroserviceTests
{
    public class RecommendationControllerTest
    {
        [Fact]
        public void CanCreateRecommendations()
        {
            var rc = new RecommendationController();
            var video = new Video
            {
                Id = "001",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            };

            var checker = rc.CreateRecommendation(video);

            Assert.Equal(3, checker);
        }
    }
}
