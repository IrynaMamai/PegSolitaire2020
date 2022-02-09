using PegSolitaire.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    public interface IRatingService
    {
        void AddOrSetRating(Rating rating);

        IList<Rating> GetRatings();

        double GetAverageRating();

        void ClearRating();
    }
}
