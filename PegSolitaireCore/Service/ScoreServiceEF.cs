using PegSolitaire.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PegSolitaire.Service
{
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new PegSolitaireDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
                //ClearScores();
            }
        }

        public void ClearScores()
        {
            using (var context = new PegSolitaireDbContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Scores");
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new PegSolitaireDbContext())
            {
                return (from s in context.Scores
                        orderby s.Points
                            descending
                        select s).Take(5).ToList();
            }
        }
    }
}
