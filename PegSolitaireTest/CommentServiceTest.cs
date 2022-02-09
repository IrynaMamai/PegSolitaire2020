using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegSolitaire.Entity;
using PegSolitaire.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaireTest
{
    [TestClass]
    public class CommentServiceTest
    {
        private ICommentService service = new CommentServiceList();


        [TestInitialize]
        public void Init()
        {
            service.ClearComment();
        }

        [TestMethod]
        public void TestClearComments()
        {
            service.AddComment(new Comment { Name = "Janko", Comments = "Hello" });
            service.AddComment(new Comment { Name = "Katka", Comments = "Three" });

            service.ClearComment();

            Assert.AreEqual<int>(0, service.GetComment().Count);
        }

        [TestMethod]
        public void TestAddComment()
        {
            service.AddComment(new Comment { Name = "Janko", Comments = "I'm Janko" });

            var comment = service.GetComment();
            Assert.AreEqual<int>(1, comment.Count);
            Assert.AreEqual<string>("Janko", comment[0].Name);
            Assert.AreEqual<string>("I'm Janko", comment[0].Comments);
        }

        [TestMethod]
        public void Test5Comments()
        {
            service.AddComment(new Comment { Name = "Janko", Comments = "I'm Janko" });
            service.AddComment(new Comment { Name = "Ferko", Comments = "I'm Ferko" });
            service.AddComment(new Comment { Name = "Janko", Comments = "I'm Janko" });
            service.AddComment(new Comment { Name = "Jozko", Comments = "I'm Jozko" });
            service.AddComment(new Comment { Name = "Antonia", Comments = "I'm Antonia" });

            var comment = service.GetComment();
            Assert.AreEqual<int>(5, comment.Count);

            Assert.AreEqual<string>("Janko", comment[1].Name);
            Assert.AreEqual<string>("I'm Janko", comment[1].Comments);

            Assert.AreEqual<string>("Ferko", comment[3].Name);
            Assert.AreEqual<string>("I'm Ferko", comment[3].Comments);

            Assert.AreEqual<string>("Janko", comment[2].Name);
            Assert.AreEqual<string>("I'm Janko", comment[2].Comments);

            Assert.AreEqual<string>("Jozko", comment[0].Name);
            Assert.AreEqual<string>("I'm Jozko", comment[0].Comments);

            Assert.AreEqual<string>("Antonia", comment[4].Name);
            Assert.AreEqual<string>("I'm Antonia", comment[4].Comments);


        }
    }
}
