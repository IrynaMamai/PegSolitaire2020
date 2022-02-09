using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegSolitaire.Core;

namespace PegSolitaireTest
{
    [TestClass]
    public class FieldTest
    {
        

        [TestMethod]
        public void TestRowAndColumnCountFor1Map()
        {
            var field = new Field(1);
            Assert.AreEqual<int>(1, field.RowCount);
            Assert.AreEqual<int>(4, field.ColumnCount);
        }


        [TestMethod]
        public void TestRowAndColumnCountFor2Map()
        {
            var field = new Field(2);
            Assert.AreEqual<int>(4, field.RowCount);
            Assert.AreEqual<int>(4, field.ColumnCount);
        }


        [TestMethod]
        public void TestRowAndColumnCountFor3Map()
        {
            var field = new Field(3);
            Assert.AreEqual<int>(5, field.RowCount);
            Assert.AreEqual<int>(5, field.ColumnCount);
        }


        [TestMethod]
        public void TestRowAndColumnCountFor4Map()
        {
            var field = new Field(4);
            Assert.AreEqual<int>(5, field.RowCount);
            Assert.AreEqual<int>(6, field.ColumnCount);
        }


        [TestMethod]
        public void TestRowAndColumnCountFor5Map()
        {
            var field = new Field(5);
            Assert.AreEqual<int>(7, field.RowCount);
            Assert.AreEqual<int>(7, field.ColumnCount);
        }


        [TestMethod]
        public void TestRowAndColumnCountFor6Map()
        {
            var field = new Field(6);
            Assert.AreEqual<int>(7, field.RowCount);
            Assert.AreEqual<int>(7, field.ColumnCount);
        }
    }
}
