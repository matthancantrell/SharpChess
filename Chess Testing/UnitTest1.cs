using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpChess;
using SharpChess.Model;

namespace Chess_Testing
{
    using SharpChess;
    using SharpChess.Model;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTest1
    {
/*        FenGenerator fg;

        // This Is How The Board Is Generated.
        [TestInitialize]
        public void TestInitialize()
        {
            fg = new FenGenerator();
        }*/

        [TestMethod]
        public void StandardGameDoesNotEqualChess960()
        {
            FenGenerator fg = new FenGenerator();

            string standard = fg.StandardFen();
            string chess960 = fg.Chess960Fen();

            Assert.AreNotEqual(standard, chess960);
        }

        [TestMethod]
        public void BothSidesAreTheSame()
        {
            FenGenerator fg = new FenGenerator();

            string chess960 = fg.Chess960Fen(); // This string should have TWO instances of the same letters a specific order, the only difference being capitalization
            string checkAgainst = chess960.Substring(0, 8); // Captures the first rank (first 8 pieces) in a string
            chess960 = chess960.Remove(0, 8); // Removes the first rank from the original string

            Assert.IsTrue(chess960.ToLower().Contains(checkAgainst.ToLower())); // By ignoring the case, the system should be able to identify that the first and last rank on the board are equal
        }

        [TestMethod]
        public void Chess960Random()
        {
            FenGenerator fg = new FenGenerator();

            string one = fg.Chess960Fen();
            string two = fg.Chess960Fen();

            Assert.AreNotEqual(one, two);
        }

        [TestMethod]
        public void Chess960Selection()
        {
            frmDifficulty difficulty = new frmDifficulty();
            difficulty.chess960_radioButton.Checked = true;
            difficulty.btnOK_Click(this, new EventArgs());
            Assert.AreEqual(Game.Type, Game.GameType.Chess960);
        }

        [TestMethod]
        public void StandardChessSelection()
        {
            frmDifficulty difficulty = new frmDifficulty();
            difficulty.chessStandard_radioButton.Checked = true;
            difficulty.btnOK_Click(this, new EventArgs());
            Assert.AreEqual(Game.Type, Game.GameType.Standard);
        }

    }
}
