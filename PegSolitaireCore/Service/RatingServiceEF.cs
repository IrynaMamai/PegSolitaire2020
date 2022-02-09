using PegSolitaire.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PegSolitaire.Service;

namespace PegSolitaire.Service
{
    public class RatingServiceEF : IRatingService
    {
        public void AddOrSetRating(Rating rating)
        {
            using (var context = new PegSolitaireDbContext())
            {
                var ratings = GetRatings();
                foreach (var search in ratings)
                {
                    if (rating.Name == search.Name)     
                        context.Ratings.Remove(search);
                }

               //if(context.Ratings.Find(rating.Name) != null)
               //     context.Ratings.Remove(rating.Name);



                context.Ratings.Add(rating);
                context.SaveChanges();
                //ClearRating();
            }
        }

        public void ClearRating()
        {
            using (var context = new PegSolitaireDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Ratings");
            }
        }

        public double GetAverageRating()
        {
            using (var context = new PegSolitaireDbContext())
            {
                var ratings = GetRatings();
                double index = 0;
                double rating_player = 0;
                foreach (var rating in ratings)
                {
                    rating_player += rating.Rating_player;
                    index++;
                }

                if (index == 0)
                    return 0;
                    
                return rating_player / index;
            }
        }

        public IList<Rating> GetRatings()
        {
            using (var context = new PegSolitaireDbContext())
            {
                return (from r in context.Ratings
                        select r).ToList();
            }
        }
    }
}
