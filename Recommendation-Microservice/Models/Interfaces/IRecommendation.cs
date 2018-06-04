using System;
using System.Collections.Generic;

namespace RecommendationMicroservice.Models.Interfaces
{
    /// <summary>
    /// This interface shows what a Recommendation object can do. By using two methods which receive as a parameter a function, we are enhancing code reusability.
    /// </summary>
    public interface IRecommendation
    {

        List<Video> IdenticalComparisonCriterias(Func<Video, Video, bool> identicalFunc, Video vd, List<Video> videos);

        List<Video> SimilarAndMixedComparisonCriterias(Func<Video, Video, int> similarFunc, Video vd, List<Video> videos);

    }
}
