using RecommendationMicroservice.Models;
using RecommendationMicroservice.Views;

namespace RecommendationMicroservice.Controllers
{
    public class RecommendationController
    {
        public Recommendation _recommendation = new Recommendation();
        private readonly VideoStream _videoStream = new VideoStream();

        public RecommendationController()
        {
            _recommendation.NumberOfRecommendedVideos = 5;
            FakeVideoRepository.LoadVideos(_videoStream);
        }

        /// <summary>
        /// This method is creating the recommedations stream. First it gathers the videos sorted by category, which is the widest criteria.
        /// If the number of videos is bigger than the wanted number of recommendations then it will do a trim out of the existing recommendations using the Genre criteria. If we still have too many videos then it will do the same thing for the
        /// Actors. However, if there are less videos in the stream after a trimming(By category, By genre or by actor), then the program will take the most relevant videos from the wider category,
        /// So that it actually fills all the missing gaps. 
        /// </summary>
        /// <param name="vd"></param>
        /// <returns></returns>
        public int CreateRecommendation(Video vd)
        {
            var categorySort = _recommendation.ByCategory(vd, _videoStream.Stream);
            if (categorySort.Count > _recommendation.NumberOfRecommendedVideos)
            {
                var genreSort = _recommendation.ByGenre(vd, categorySort);

                if (genreSort.Count > _recommendation.NumberOfRecommendedVideos)
                {
                    var actorSort = _recommendation.ByActors(vd, genreSort);

                    if (actorSort.Count > _recommendation.NumberOfRecommendedVideos)
                    {
                        for (var i = 0; i < _recommendation.NumberOfRecommendedVideos; i++)
                        {
                            _recommendation.AddVideo(actorSort[i]);
                        }

                        RecommendationView.ShowRecommendations(_recommendation);
                        return _recommendation.SizeOfStream();

                    }
                    else
                    {
                        foreach (var t in actorSort)
                        {
                            _recommendation.AddVideo(t);
                        }

                        var x = _recommendation.NumberOfRecommendedVideos - actorSort.Count;

                        for (var i = 0; i < genreSort.Count && x != 0; i++)
                        {
                            var added = _recommendation.AddVideo(genreSort[i]);
                            if (added)
                            {
                                x--;
                            }
                        }

                        if (x != 0)
                        {
                            for (var i = 0; i < categorySort.Count && x != 0; i++)
                            {
                                var added = _recommendation.AddVideo(categorySort[i]);
                                if (added)
                                {
                                    x--;
                                }
                            }
                        }
                        RecommendationView.ShowRecommendations(_recommendation);
                        return _recommendation.SizeOfStream();
                    }
                }
                else
                {
                    var x = _recommendation.NumberOfRecommendedVideos - genreSort.Count;

                    foreach (var t in genreSort)
                    {
                        _recommendation.AddVideo(t);
                    }

                    for (var i = 0; i < categorySort.Count && x != 0; i++)
                    {
                        var added = _recommendation.AddVideo(categorySort[i]);
                        if (added)
                        {
                            x--;
                        }
                    }
                    RecommendationView.ShowRecommendations(_recommendation);
                    return _recommendation.SizeOfStream();

                }
            }
            else
            {
                var x = _recommendation.NumberOfRecommendedVideos - categorySort.Count;

                foreach (var t in categorySort)
                {
                    _recommendation.AddVideo(t);
                }

                var genreSort = _recommendation.ByGenre(vd, _videoStream.Stream);

                for (var i = 0; i < genreSort.Count && x != 0; i++)
                {
                    var added = _recommendation.AddVideo(genreSort[i]);

                    if (added)
                    {
                        x--;
                    }
                }

                if (x == 0)
                {
                    RecommendationView.ShowRecommendations(_recommendation);
                    return _recommendation.SizeOfStream();
                }
                else
                {
                    var actorSort = _recommendation.ByActors(vd, _videoStream.Stream);

                    for (var i = 0; i < actorSort.Count && x != 0; i++)
                    {
                        var added = _recommendation.AddVideo(actorSort[i]);

                        if (added)
                        {
                            x--;
                        }
                    }
                    RecommendationView.ShowRecommendations(_recommendation);
                    return _recommendation.SizeOfStream();
                }
            }
        }
    }
}
