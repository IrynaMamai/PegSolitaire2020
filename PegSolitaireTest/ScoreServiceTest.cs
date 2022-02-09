using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaireTest
{
    [TestClass]
    public class ScoreServiceTest
    {
        private IScoreService service = new ScoreServiceList();

        [TestInitialize]
        public void Init()
        {
            service.ClearScores();
        }

        [TestMethod]
        public void TestClearScores()
        {
            service.AddScore(new Score { Name = "Janko", Points = 120 });
            service.AddScore(new Score { Name = "Katka", Points = 100 });

            service.ClearScores();

            Assert.AreEqual<int>(0, service.GetTopScores().Count);
        }

        [TestMethod]
        public void TestAddScore()
        {
            service.AddScore(new Score { Name = "Janko", Points = 120 });

            var scores = service.GetTopScores();
            Assert.AreEqual<int>(1, scores.Count);
            Assert.AreEqual<string>("Janko", scores[0].Name);
            Assert.AreEqual<int>(120, scores[0].Points);
        }

        [TestMethod]
        public void TestTop5Scores()
        {
            service.AddScore(new Score { Name = "Janko", Points = 100 });
            service.AddScore(new Score { Name = "Ferko", Points = 120 });
            service.AddScore(new Score { Name = "Janko", Points = 150 });
            service.AddScore(new Score { Name = "Jozko", Points = 80 });
            service.AddScore(new Score { Name = "Janko", Points = 700 });

            var scores = service.GetTopScores();
            Assert.AreEqual<int>(5, scores.Count);

            Assert.AreEqual<string>("Janko", scores[0].Name);
            Assert.AreEqual<int>(700, scores[0].Points);

            Assert.AreEqual<string>("Janko", scores[1].Name);
            Assert.AreEqual<int>(150, scores[1].Points);

            Assert.AreEqual<string>("Ferko", scores[2].Name);
            Assert.AreEqual<int>(120, scores[2].Points);

            Assert.AreEqual<string>("Janko", scores[3].Name);
            Assert.AreEqual<int>(100, scores[3].Points);

            Assert.AreEqual<string>("Jozko", scores[4].Name);
            Assert.AreEqual<int>(80, scores[4].Points);
        }
    }
}
