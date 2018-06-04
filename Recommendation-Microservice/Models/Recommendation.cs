using System;
using System.Collections.Generic;
using System.Linq;
using RecommendationMicroservice.Models.Interfaces;

namespace RecommendationMicroservice.Models
{
    public class Recommendation : IRecommendation, IVideoStream
    {

        public List<Video> Recommendations { get; set; } = new List<Video>();

        public int NumberOfRecommendedVideos { get; set; } = 0;

        public List<Video> IdenticalComparisonCriterias(Func<Video, Video, bool> identicalFunc, Video vd, List<Video> videos)
        {
            return videos.Where(v => identicalFunc(v, vd)).ToList();
        }

        public List<Video> SimilarAndMixedComparisonCriterias(Func<Video, Video, int> similarFunc, Video vd, List<Video> videos)
        {
            var dict = new Dictionary<int, List<Video>>();
            var result = new List<Video>();

            foreach (var vid in videos)
            {
                var count = similarFunc(vid, vd);

                if (count == 0) continue;
                if (dict.ContainsKey(count)) dict[count].Add(vid);
                else dict[count] = new List<Video> { vid };
            }

            foreach (var k in dict.OrderByDescending(x => x.Key))
            {
                result.AddRange(k.Value);
            }

            return result;
        }

        // The ByCategory, ByGenre and ByActor methods are gathering the videos from the stream sorted by a given criteria (Category, Actors, Genre)

        public List<Video> ByCategory(Video vd, List<Video> videos)
        {
            var recommendations = new VideoStream();
            foreach(var video in IdenticalComparisonCriterias(Video.SameCategory, vd, videos))
            {
                recommendations.AddVideo(video);
            }  

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.SimilarCategory, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.MixedCategory, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            return recommendations.Stream;
        }

        public List<Video> ByGenre(Video vd, List<Video> videos)
        {
            var recommendations = new VideoStream();
            foreach (var video in IdenticalComparisonCriterias(Video.SameGenre, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.SimilarGenre, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.MixedGenre, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            return recommendations.Stream;
        }

        public List<Video> ByActors(Video vd, List<Video> videos)
        {
            var recommendations = new VideoStream();
            foreach (var video in IdenticalComparisonCriterias(Video.SameActors, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.SimilarActors, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            foreach (var video in SimilarAndMixedComparisonCriterias(Video.MixedActors, vd, videos))
            {
                recommendations.AddVideo(video);
            }

            return recommendations.Stream;
        }

        public bool AddVideo(Video video)
        {
            if (Recommendations.Any(v => v.Id == video.Id)) return false;

            Recommendations.Add(video);
            return true;
        }

        public int RemoveVideo(Video video)
        {
            return Recommendations.RemoveAll(v => v.Id == video.Id);
        }

        public int SizeOfStream()
        {
            return Recommendations.Count;
        }

        public bool ClearStream()
        {
            if (Recommendations.Count == 0) return false;

            Recommendations.Clear();
            return true;
        }

        public int DiCtionarySorting(Video vid, List<Video> stream)
        {
            var dict = new Dictionary<int, List<Video>>
            {
                [1] = new List<Video>(),
                [2] = new List<Video>(),
                [3] = new List<Video>(),
                [4] = new List<Video>()
            };
            foreach (var video in stream)
            {
                if(video.Id == vid.Id) continue;
                if (video.SameCategory(vid) && video.SameGenre(vid) && video.SameActor(vid))
                {
                    dict[1].Add(video);
                }
            }


            return 0;
        }

    }
}
