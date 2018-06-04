using RecommendationMicroservice.Models;
using Xunit;

namespace RecommendationMicroserviceTests
{
    public class VideoTest
    {
        [Fact]
        public void HasSameCategory()
        {
            // Arange

            var vid1 = new Video
            {
                Name = "one",
                Id = "001",
                Category = {"action", "comedy", "drama", "thriller"}
            };

            var vid2 = new Video
            {
                Name = "two",
                Id = "002",
                Category = { "action", "comedy"}
            };

            var vid3 = new Video
            {
                Name = "three",
                Id = "003",
                Category = { "action", "comedy", "drama", "thriller" },
            };

            // Act

            var comp1 = vid1.SameCategory(vid2);
            var comp2 = vid1.SameCategory(vid3);

            // Assert

            Assert.False(comp1);
            Assert.True(comp2);
        }

        [Fact]
        public void HasSimilarCategory()
        {
            // Arange

            var vid1 = new Video
            {
                Name = "one",
                Id = "001",
                Category = { "action", "comedy", "drama", "thriller" }
            };

            var vid2 = new Video
            {
                Name = "two",
                Id = "002",
                Category = { "action", "comedy" }
            };

            var vid3 = new Video
            {
                Name = "three",
                Id = "003",
                Category = { "something else", "thriller" },
            };

            var vid4 = new Video
            {
                Name = "four",
                Id = "004",
                Category = {"action", "something else", "thriller" },
            };

            // Act

            var comp1 = vid1.SimilarCategory(vid2);
            var comp2 = vid1.SimilarCategory(vid3);
            var comp3 = vid1.SimilarCategory(vid4);

            // Assert

            Assert.Equal(2, comp1);
            Assert.Equal(0, comp2);
            Assert.Equal(1, comp3);
        }

        [Fact]
        public void HasMixedCategories()
        {
            // Arange

            var vid1 = new Video
            {
                Name = "one",
                Id = "001",
                Category = { "action", "comedy", "drama", "thriller" }
            };

            var vid2 = new Video
            {
                Name = "two",
                Id = "002",
                Category = {"thriller", "action", "something" }
            };

            var vid3 = new Video
            {
                Name = "three",
                Id = "003",
                Category = { "something else" }
            };

            var vid4 = new Video
            {
                Name = "four",
                Id = "004",
                Category = { "action",  "thriller", "comedy", "drama",  }
            };

            // Act

            var comp1 = vid1.MixedCategory(vid2); // 2
            var comp2 = vid1.MixedCategory(vid3); // 0
            var comp3 = vid1.MixedCategory(vid4); // 4

            // Assert

            Assert.Equal(2, comp1);
            Assert.Equal(0, comp2);
            Assert.Equal(4, comp3);


        }
    }
}
