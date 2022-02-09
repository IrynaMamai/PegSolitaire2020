using PegSolitaire.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PegSolitaire.Service
{
    public class RatingServiceList : IRatingService
    {
        private const string FileName = "rating.bin";

        private List<Rating> ratings = new List<Rating>();


        public void AddOrSetRating(Rating rating)
        {
            if (rating == null)
                throw new ScoreException("Score must be not null!");
            if (rating.Name == null)
                throw new ScoreException("Score contains null Name!");


            if (ratings.Exists(x => x.Name == rating.Name))
            {
                ratings.Remove(ratings.Find(x => x.Name.Contains(rating.Name)));
            }

            ratings.Add(rating);
            SaveRating();

        }

        public IList<Rating> GetRatings()
        {
            LoadRating();
            return (from s in ratings select s).ToList();
        }

        public double GetAverageRating()
        {
            var ratings = GetRatings();
            double index = 0;
            double rating_player = 0;
            foreach (var rating in ratings)
            {
                rating_player += rating.Rating_player;
                index++;
            }

            return rating_player / index;
        }

        public void ClearRating()
        {
            ratings.Clear();
            File.Delete(FileName);
        }

        private void SaveRating()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, ratings);
            }
        }

        private void LoadRating()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    ratings = (List<Rating>)bf.Deserialize(fs);
                }
            }
        }

      
    }
}
