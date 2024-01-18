using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpChess;
using SharpChess.Model;

namespace Chess_Testing
{
    using SharpChess;
    using SharpChess.Model;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreNotEqual(Game.StandardFen(), Game.StandardFen());
        }
    }
}
