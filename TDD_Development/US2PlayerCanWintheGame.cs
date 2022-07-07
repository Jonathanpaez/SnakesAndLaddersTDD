using System;
using NUnit.Framework;
using Logic.BL;

namespace TDD_Development
{
    //As a player
    //I want to be able to win the game
    //So that I can gloat to everyone around
    public class US2PlayerCanWintheGame
    {
        [Test]
        public void GivenTokenOnSquare97WhenTokenMoved3SpacesThenTokenIsOnSquare100AndThePlayerHasWonGame()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Players[0].TokenPosition = 97;
            Assert.AreEqual(97, board.Players[0].TokenPosition);
            board.Players[0].TokenPosition =
                gameRules.MovePlayerToken(board.Players[0].TokenPosition, 3, board.Squares);
            Assert.AreEqual(100, board.Players[0].TokenPosition);
            Assert.IsTrue(gameRules.HasWinner(board, board.Players[0].TokenPosition));
        }

        [Test]
        public void GivenTokenOnSquare97WhenTokenMoved4SpacesThenTokenIsOnSquare97AndThePlayerHasNotWonGame()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Players[0].TokenPosition = 97;
            Assert.AreEqual(97, board.Players[0].TokenPosition);
            board.Players[0].TokenPosition =
                gameRules.MovePlayerToken(board.Players[0].TokenPosition, 4, board.Squares);
            Assert.AreEqual(97, board.Players[0].TokenPosition);
            Assert.IsFalse(gameRules.HasWinner(board, board.Players[0].TokenPosition));
        }
    }
}
