using RecommendationMicroservice.Models;
using Xunit;

namespace RecommendationMicroserviceTests
{
    public class RecommendationTest
    {

        [Fact]
        public void CanAssertIdenticalComparisonCriteria()
        {
            
            // Arrange

            var vid = new Video
            {
                Id = "004",
                Name = "sth",
                Category = {"action", "drama"}
            };

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
                Category = {"action", "drama"}
            });

            stream.AddVideo(new Video
            {
                Id = "005",
                Name = "One",
                Category = { "action", "comedy" }
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
                Category = {"action", "something", "drama"}
            });

            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "One",
                Category = {"drama"}
            });

            // Act

            var recc = new Recommendation();
            var result = recc.IdenticalComparisonCriterias(Video.SameCategory, vid, stream.Stream);

            // Assert

            Assert.Equal("001", result[0].Id);
            Assert.Single(result);
        }


        [Fact]
        public void CanAssertSimilarComparisonCriteria()
        {

            // Arrange

            var vid = new Video
            {
                Id = "004",
                Name = "sth",
                Category = { "action", "drama" }
            };

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
                Category = { "action", "drama", "blues" }
            });

            stream.AddVideo(new Video
            {
                Id = "005",
                Name = "One",
                Category = { "action", "comedy" }
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
                Category = { "action", "something", "drama" }
            });

            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "One",
                Category = { "drama" }
            });

            // Act

            var recc = new Recommendation();
            var result = recc.SimilarAndMixedComparisonCriterias(Video.SimilarCategory, vid, stream.Stream);

            // Assert

            Assert.Equal("001", result[0].Id);
            Assert.Equal("005", result[1].Id);
            Assert.Equal("002", result[2].Id);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void CanAssertMixedComparisonCriteria()
        {

            // Arrange

            var vid = new Video
            {
                Id = "004",
                Name = "sth",
                Category = { "action", "drama" }
            };

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
                Category = { "action","something", "drama", "blues" }
            });

            stream.AddVideo(new Video
            {
                Id = "005",
                Name = "One",
                Category = { "action", "else" }
            });
 
            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "One",
                Category = { "drama" }
            });

            // Act

            var recc = new Recommendation();
            var result = recc.SimilarAndMixedComparisonCriterias(Video.MixedCategory, vid, stream.Stream);

            // Assert

            Assert.Equal("001", result[0].Id);
            Assert.Equal("005", result[1].Id);
            Assert.Equal("003", result[2].Id);
            Assert.Equal(3, result.Count);
        }

    }
}
