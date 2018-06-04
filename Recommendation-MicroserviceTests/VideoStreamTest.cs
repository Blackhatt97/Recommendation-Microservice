using RecommendationMicroservice.Models;
using Xunit;

namespace RecommendationMicroserviceTests
{
    public class VideoStreamTest
    {

        [Fact]
        public void CanInsertVideo()
        {
            // Arrange

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
            });

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            // Act

            var video1 = stream.Stream[0];
            var video2 = stream.Stream[1];
            var video3 = stream.Stream.Count;

            // Assert

            Assert.Equal("001", video1.Id);
            Assert.Equal("002", video2.Id);
            Assert.Equal(2, video3);

        }

        [Fact]
        public void CanRemoveVideo()
        {
            // Arrange

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
            });

            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "One",
            });

            // Act

            var video1 = stream.RemoveVideo(new Video {Id = "001"});
            var video2 = stream.RemoveVideo(new Video {Id = "001"});
            var video3 = stream.Stream.Count;

            // Assert

            Assert.Equal(1, video1);
            Assert.Equal(0, video2);
        }

        [Fact]
        public void CanMeasureSize()
        {
            // Arrange

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
            });

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            // Act

            var video1 = stream.SizeOfStream();

            // Assert

            Assert.Equal(2, video1);

        }

        [Fact]
        public void CanClearStream()
        {
            // Arrange

            var stream = new VideoStream();

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "One",
            });

            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "Two",
            });

            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "One",
            });

            // Act

            var video1 = stream.ClearStream();
            var video2 = stream.SizeOfStream();

            // Assert

            Assert.True(video1);
            Assert.Equal(0, video2);
        }

        [Fact]
        public void CanPopulate()
        {
            var stream = new VideoStream();

            FakeVideoRepository.LoadVideos(stream);

            Assert.Equal(8, stream.SizeOfStream());
        }

    }
}
