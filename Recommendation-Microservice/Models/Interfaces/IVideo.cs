namespace RecommendationMicroservice.Models.Interfaces
{
    
    /// <summary>
    /// This interface simply dictates the capabilities of a video.
    /// </summary>
    public interface IVideo
    {
        bool SameCategory(Video other);

        int SimilarCategory(Video other);

        int MixedCategory(Video other);

        bool SameGenre(Video other);

        int SimilarGenre(Video other);

        int MixedGenre(Video other);

        bool SameActor(Video other);

        int SimilarActor(Video other);

        int MixedActor(Video other);

    }
}
