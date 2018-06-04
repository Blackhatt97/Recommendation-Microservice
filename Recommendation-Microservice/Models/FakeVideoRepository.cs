namespace RecommendationMicroservice.Models
{
    /// <summary>
    /// This is a fake repository that will mimic the information received form the CMS
    /// </summary>
    public class FakeVideoRepository
    {
        public static void LoadVideos(VideoStream stream)
        {

            stream.AddVideo(new Video
            {
                Id = "001",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "002",
                Name = "whatever2",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "comedy" },
                Actors = { "brad", "johnny", "deep", "mother" }
            });
            stream.AddVideo(new Video
            {
                Id = "003",
                Name = "whatever4",
                Category = { "friends", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "004",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "005",
                Name = "whatever55",
                Category = { "some" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "006",
                Name = "whatever9",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "blah" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "007",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
            stream.AddVideo(new Video
            {
                Id = "008",
                Name = "whatever",
                Category = { "friends", "chill", "sunday", "enthralling" },
                Genre = { "action", "drama", "police" },
                Actors = { "brad", "pitt", "johnny", "deep" }
            });
        }
    }
}
