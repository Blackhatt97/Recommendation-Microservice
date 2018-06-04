using System.Collections.Generic;
using System.Linq;
using RecommendationMicroservice.Models.Interfaces;

namespace RecommendationMicroservice.Models
{
    public class VideoStream : IVideoStream
    {
        public List<Video> Stream { get; set; } = new List<Video>();

        public bool AddVideo(Video video)
        {
            if (Stream.Any(v => v.Id == video.Id)) return false;

            Stream.Add(video);
            return true;
        }

        public int RemoveVideo(Video video)
        {
            return Stream.RemoveAll(v => v.Id == video.Id);
        }

        public int SizeOfStream()
        {
            return Stream.Count;
        }

        public bool ClearStream()
        {
            if (Stream.Count == 0) return false;

            Stream.Clear();
            return true;
        }
    }
}
