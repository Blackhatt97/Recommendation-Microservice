namespace RecommendationMicroservice.Models.Interfaces
{
    /// <summary>
    /// This interface is showing the capabilities of a stream of videos.
    /// </summary>
    public interface IVideoStream
    {
        bool AddVideo(Video video);

        int RemoveVideo(Video video);

        int SizeOfStream();

        bool ClearStream();
    }
}
