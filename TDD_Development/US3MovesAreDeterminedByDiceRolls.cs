using System;
using NUnit.Framework;
using Logic.BL;

namespace TDD_Development
{
    //As a player
    //I want to move my token based on the roll of a die
    //So that there is an element of chance in the game
    public class US3MovesAreDeterminedByDiceRolls
    {
        [Test]
        public void GivenGameStartedWhenPlayerRollsDieThenResultShouldBeBetween1To6Inclusive()
        {
            var gameRules = new Game();
            var acceptedDiceResults = 1;
            while (acceptedDiceResults < 7)
            {
                var diceResult = gameRules.ThrowDice(null);
                Assert.IsTrue(1 <= diceResult && diceResult <=6);
                if (acceptedDiceResults == diceResult)
                {
                    Assert.AreEqual(acceptedDiceResults, diceResult);
                    acceptedDiceResults += 1;
                }
            }
        }

        [Test]
        public void GivenPlayerRolls4WhenTheyMoveTheirTokenThenTokenShouldMove4Spaces()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            var diceResult = gameRules.ThrowDice(4);
            var previousPosition = board.Players[0].TokenPosition;
            board.Players[0].TokenPosition =
                gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.AreEqual(previousPosition + diceResult, board.Players[0].TokenPosition);
        }
    }
}
