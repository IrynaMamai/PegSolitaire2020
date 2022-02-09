using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaireTest
{
    [TestClass]
    public class RatingServiceTest
    {
        private IRatingService service = new RatingServiceList();

        [TestInitialize]
        public void Init()
        {
            service.ClearRating();
        }

        [TestMethod]
        public void TestClearRating()
        {
            service.AddOrSetRating(new Rating { Name = "Janko", Rating_player = 1 });
            service.AddOrSetRating(new Rating { Name = "Katka", Rating_player = 5 });

            service.ClearRating();

            Assert.AreEqual<int>(0, service.GetRatings().Count);
        }


        [TestMethod]
        public void TestAddRating()
        {
            service.AddOrSetRating(new Rating { Name = "Janko", Rating_player = 4 });

            var rating = service.GetRatings();
            Assert.AreEqual<int>(1, rating.Count);
            Assert.AreEqual<string>("Janko", rating[0].Name);
            Assert.AreEqual<int>(4, rating[0].Rating_player);
        }

        [TestMethod]
        public void TestSetRating()
        {
            service.AddOrSetRating(new Rating { Name = "Janko", Rating_player = 4 });
            service.AddOrSetRating(new Rating { Name = "Janko", Rating_player = 1 });

            var rating = service.GetRatings();
            Assert.AreEqual<int>(1, rating.Count);
            Assert.AreEqual<string>("Janko", rating[0].Name);
            Assert.AreEqual<int>(1, rating[0].Rating_player);
        }

        [TestMethod]
        public void TestGetAverageRating()
        {
            service.AddOrSetRating(new Rating { Name = "Janko", Rating_player = 4 });
            service.AddOrSetRating(new Rating { Name = "Ferko", Rating_player = 1 });
            service.AddOrSetRating(new Rating { Name = "Jozko", Rating_player = 4 });

            var rating = service.GetAverageRating();
            Assert.AreEqual<int>(3, Convert.ToInt32(rating));
        }

      
    }
}
