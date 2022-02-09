using Microsoft.EntityFrameworkCore.Metadata;
using PegSolitaire.Core;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PegSolitaireWeb.Models
{
    public class PegSolitaireModel
    {
        public Field Field { get; set; }

        public string Message { get; set; }


        public IList<Score> Scores { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<Rating> Ratings { get; set; }

        public double AverageRatin { get; set; }


        public PegSolitaireModel(){
            IRatingService _ratingService = new RatingServiceEF();
            AverageRatin = _ratingService.GetAverageRating();
        }
    }
}