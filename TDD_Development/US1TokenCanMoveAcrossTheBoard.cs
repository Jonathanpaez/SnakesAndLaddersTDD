using System;
using NUnit.Framework;
using Logic.BL;

namespace TDD_Development
{
    //As a player
    //I want to be able to move my token
    //So that I can get closer to the goal
    public class US1TokenCanMoveAcrossTheBoard
    {
        [Test]
        public void GivenGameStartedWhenTokenPlacedOnBoardThenTokenIsOnSquare1()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Players.ForEach(player =>
            {
                Assert.AreEqual(1, player.TokenPosition);
            });
        }

        [Test]
        public void GivenTokenOnSquare1WhenTokenMoved3SpacesThenTokenIsOnSquare4()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            Assert.AreEqual(1, board.Players[0].TokenPosition);
            gameRules.MovePlayerToken(board, 3,1);
            Assert.AreEqual(4, board.Players[0].TokenPosition);
        }

        [Test]
        public void GivenTokenOnSquare1WhenTokenMoved3SpacesAndThenMoved4SpacesThenTokenIsOnSquare8()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            Assert.AreEqual(1, board.Players[0].TokenPosition);
            gameRules.MovePlayerToken(board, 3, 1);
            Assert.AreEqual(4, board.Players[0].TokenPosition);
            gameRules.MovePlayerToken(board, 4, 1);
            Assert.AreEqual(8, board.Players[0].TokenPosition);
        }
    }
}
