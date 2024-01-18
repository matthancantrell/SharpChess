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
        FenGenerator fg;
        string chess960Fen;
        string standardFen;

        // This Is How The Board Is Generated.
        [TestInitialize]
        public void TestInitialize()
        {
            fg = new FenGenerator();
            chess960Fen = fg.Chess960Fen();
            standardFen = fg.StandardFen();
        }

        [TestMethod]
        public void StandardGameDoesNotEqualChess960()
        {
            Assert.AreNotEqual(standardFen, chess960Fen);
        }

        [TestMethod]
        public void BothSidesAreTheSame()
        {
            string checkAgainst = chess960Fen.Substring(0, 8); // Captures the first rank (first 8 pieces) in a string
            chess960Fen = chess960Fen.Remove(0, 8); // Removes the first rank from the original string

            Assert.IsTrue(chess960Fen.ToLower().Contains(checkAgainst.ToLower())); // By ignoring the case, the system should be able to identify that the first and last rank on the board are equal
        }

        [TestMethod]
        public void Chess960Random()
        {
            string test = fg.Chess960Fen();

            Assert.AreNotEqual(chess960Fen, test);
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
