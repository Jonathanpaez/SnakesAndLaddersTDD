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
            gameRules.MovePlayerToken(board, 3, 1);
            gameRules.HasWinner(board, board.Players[0].TokenPosition);
            Assert.AreEqual(100, board.Players[0].TokenPosition);
            Assert.IsTrue(board.HasWinner);
        }

        [Test]
        public void GivenTokenOnSquare97WhenTokenMoved4SpacesThenTokenIsOnSquare97AndThePlayerHasNotWonGame()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Players[0].TokenPosition = 97;
            Assert.AreEqual(97, board.Players[0].TokenPosition);
            gameRules.MovePlayerToken(board, 4, 1);
            Assert.AreEqual(97, board.Players[0].TokenPosition);
            gameRules.HasWinner(board, board.Players[0].TokenPosition);
            Assert.IsFalse(board.HasWinner);
        }
    }
}
