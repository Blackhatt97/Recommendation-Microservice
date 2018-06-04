using System.Collections.Generic;
using System.Linq;
using RecommendationMicroservice.Models.Interfaces;

namespace RecommendationMicroservice.Models
{
    public class Video : IVideo
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        public List<string> Genre { get; set; } = new List<string>();
        public List<string> Actors { get; set; } = new List<string>();


        // Those are the methods implemented from the IVideo interface. They are quite similar given that at the moment we are having 3 criterias after whhich we are sorting and in actuality they are identical.
        // To overcome this issue, I have created some static methods so that I can pass them as parameters to other methods from the recommedation class.


        public bool SameCategory(Video other)
        {
            return Category.SequenceEqual(other.Category);
        }

        public int SimilarCategory(Video other)
        {
            var length = this.Category.Count < other.Category.Count ? this.Category.Count : other.Category.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (this.Category[i] != other.Category[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public int MixedCategory(Video other)
        {

            return this.Category.Intersect(other.Category).Count();

        }

        public bool SameGenre(Video other)
        {
            return this.Genre.SequenceEqual(other.Genre);
        }

        public int SimilarGenre(Video other)
        {
            var length = this.Genre.Count < other.Genre.Count ? this.Genre.Count : other.Genre.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (this.Genre[i] != other.Genre[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public int MixedGenre(Video other)
        {
            return this.Genre.Intersect(other.Genre).Count();
        }

        public bool SameActor(Video other)
        {
            return this.Actors.SequenceEqual(other.Actors);
        }

        public int SimilarActor(Video other)
        {
            var length = this.Actors.Count < other.Actors.Count ? this.Actors.Count : other.Actors.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (this.Actors[i] != other.Actors[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public int MixedActor(Video other)
        {
            return this.Actors.Intersect(other.Actors).Count();
        }

        // Static methods for code reusability enhancing

        public static bool SameCategory(Video one, Video other)
        {
            return one.Category.SequenceEqual(other.Category);
        }

        public static int SimilarCategory(Video one, Video other)
        {
            var length = one.Category.Count < other.Category.Count ? one.Category.Count : other.Category.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (one.Category[i] != other.Category[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public static int MixedCategory(Video one, Video other)
        {
            return one.Category.Intersect(other.Category).Count();
        }

        public static bool SameGenre(Video one, Video other)
        {
            return one.Genre.SequenceEqual(other.Category);
        }

        public static int SimilarGenre(Video one, Video other)
        {
            var length = one.Genre.Count < other.Genre.Count ? one.Genre.Count : other.Genre.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (one.Genre[i] != other.Genre[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public static int MixedGenre(Video one, Video other)
        {
            return one.Genre.Intersect(other.Category).Count();
        }

        public static bool SameActors(Video one, Video other)
        {
            return one.Actors.SequenceEqual(other.Category);
        }

        public static int SimilarActors(Video one, Video other)
        {
            var length = one.Actors.Count < other.Actors.Count ? one.Actors.Count : other.Actors.Count;
            var similarVideos = 0;

            for (var i = 0; i < length; i++)
            {
                if (one.Actors[i] != other.Actors[i]) break;
                similarVideos++;
            }

            return similarVideos;
        }

        public static int MixedActors(Video one, Video other)
        {
            return one.Actors.Intersect(other.Category).Count();
        }
    }
}
