using PegSolitaire.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Service
{
    
        public interface IScoreService
        {
            void AddScore(Score score);

            IList<Score> GetTopScores();

            void ClearScores();

        }
    
}
