// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerBlack.cs" company="SharpChess.com">
//   SharpChess.com
// </copyright>
// <summary>
//   The player black.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region License

// SharpChess
// Copyright (C) 2012 SharpChess.com
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
#endregion

using System;
using System.Collections.Generic;

namespace SharpChess.Model
{
    /// <summary>
    /// The player black.
    /// </summary>
    public class PlayerBlack : Player
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerBlack"/> class.
        /// </summary>
        public PlayerBlack()
        {
            this.Colour = PlayerColourNames.Black;
            this.Intellegence = PlayerIntellegenceNames.Computer;

            this.SetPiecesAtStartingPositions();
        }

        public PlayerBlack(GameType gameType)
        {
            this.Colour = PlayerColourNames.Black;
            this.Intellegence = PlayerIntellegenceNames.Computer;

            if (gameType == GameType.Standard)
            {
                Console.WriteLine("Black: Standard Start");
                this.SetPiecesAtStartingPositions();
            }
            else
            {
                Console.WriteLine("Black: Chess960 Start");
                Chess960Start();
                //this.SetPiecesAtStartingPositions();
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets PawnAttackLeftOffset.
        /// </summary>
        public override int PawnAttackLeftOffset
        {
            get
            {
                return -17;
            }
        }

        /// <summary>
        /// Gets PawnAttackRightOffset.
        /// </summary>
        public override int PawnAttackRightOffset
        {
            get
            {
                return -15;
            }
        }

        /// <summary>
        /// Gets PawnForwardOffset.
        /// </summary>
        public override int PawnForwardOffset
        {
            get
            {
                return -16;
            }
        }

        #endregion

        #region Methods

        public bool isAnEvenSpace(int space)
        {
            if ((space % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// The set pieces at starting positions.
        /// </summary>
        protected override sealed void SetPiecesAtStartingPositions()
        {
            this.Pieces.Add(this.King = new Piece(Piece.PieceNames.King, this, 4, 7, Piece.PieceIdentifierCodes.BlackKing));

            this.Pieces.Add(new Piece(Piece.PieceNames.Queen, this, 3, 7, Piece.PieceIdentifierCodes.BlackQueen));

            this.Pieces.Add(new Piece(Piece.PieceNames.Rook, this, 0, 7, Piece.PieceIdentifierCodes.BlackQueensRook));
            this.Pieces.Add(new Piece(Piece.PieceNames.Rook, this, 7, 7, Piece.PieceIdentifierCodes.BlackKingsRook));

            this.Pieces.Add(new Piece(Piece.PieceNames.Bishop, this, 2, 7, Piece.PieceIdentifierCodes.BlackQueensBishop));
            this.Pieces.Add(new Piece(Piece.PieceNames.Bishop, this, 5, 7, Piece.PieceIdentifierCodes.BlackKingsBishop));

            this.Pieces.Add(new Piece(Piece.PieceNames.Knight, this, 1, 7, Piece.PieceIdentifierCodes.BlackQueensKnight));
            this.Pieces.Add(new Piece(Piece.PieceNames.Knight, this, 6, 7, Piece.PieceIdentifierCodes.BlackKingsKnight));

            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 0, 6, Piece.PieceIdentifierCodes.BlackPawn1));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 1, 6, Piece.PieceIdentifierCodes.BlackPawn2));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 2, 6, Piece.PieceIdentifierCodes.BlackPawn3));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 3, 6, Piece.PieceIdentifierCodes.BlackPawn4));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 4, 6, Piece.PieceIdentifierCodes.BlackPawn5));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 5, 6, Piece.PieceIdentifierCodes.BlackPawn6));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 6, 6, Piece.PieceIdentifierCodes.BlackPawn7));
            this.Pieces.Add(new Piece(Piece.PieceNames.Pawn, this, 7, 6, Piece.PieceIdentifierCodes.BlackPawn8));
        }

        protected void Chess960Start()
        {
            Random random = new Random();
            List<int> list = new List<int>();
            bool BishopOnEvenSquare = false;
            int number;

            #region Placing The Bishops
            // Bishop One
            number = random.Next(8); // Generates Random Number For Location On Board
            list.Add(number); // Adds Numbers To List
            this.Pieces.Add(new Piece(Piece.PieceNames.Bishop, this, number, 7, Piece.PieceIdentifierCodes.BlackQueensBishop)); // Places Piece In Pieces Container
            BishopOnEvenSquare = isAnEvenSpace(number); // Determines If Bishop Is On An Even Square

            // Bishop Two
            while (list.Contains(number) ||  BishopOnEvenSquare == isAnEvenSpace(number)) // While The Number Generated Is In The List OR Is Also On The Same Type Of Space As The First Bishop
            {
                number = random.Next(8); // Regenerate Number
            }
            list.Add(number); // Add Number To List
            this.Pieces.Add(new Piece(Piece.PieceNames.Bishop, this, number, 7, Piece.PieceIdentifierCodes.BlackKingsBishop)); // Place Piece In Pieces Container
            #endregion

            #region Placing Rooks
            int rookOne = random.Next(8);
            int rookTwo = random.Next(8);

            while (list.Contains(rookOne) || list.Contains(rookTwo) || Math.Abs(rookOne - rookTwo) < 1)
            {
                rookOne = random.Next(8);
                rookTwo = random.Next(8);
            }

            list.Add(rookOne);
            list.Add(rookTwo);

            Console.WriteLine("Rook One: " + rookOne);
            Console.WriteLine("Rook Two: " + rookTwo);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            #endregion

        }

        #endregion
    }
}