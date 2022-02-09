using PegSolitaire.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace PegSolitaire.Service
{
    public class ScoreServiceList : IScoreService
    {
        private const string FileName = "score.bin";

        private List<Score> scores = new List<Score>();

        public void AddScore(Score score)
        {
            if (score == null)
                throw new ScoreException("Score must be not null!");
            if (score.Name == null)
                throw new ScoreException("Score contains null Name!");
            scores.Add(score);
            SaveScore();
        }

        public IList<Score> GetTopScores()
        {
            LoadScore();
            return (from s in scores orderby s.Points descending select s).Take(5).ToList();
            //return scores.OrderByDescending(s => s.Points).Take(3).ToList();
        }

        public void ClearScores()
        {
            scores.Clear();
            File.Delete(FileName);
        }


        private void SaveScore()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, scores);
            }
        }

        private void LoadScore()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    scores = (List<Score>)bf.Deserialize(fs);
                }
            }
        }

    }
}
