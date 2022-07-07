using System;
using NUnit.Framework;
using Logic.BL;

namespace TDD_Development
{
    public class Tests
    {
        [Test]
        public void GivenBoardWhenGameStartWhitNoneSquaresThenBoardThrowException()
        {
            try
            {
                new Game().CreateBoard(0, 0);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.AreEqual("Error al crear el tablero", error.Message);
            }
        }

        [Test]
        public void GivenBoardWhenGameStartThenBoardHasSquares()
        {
            var board = new Game().CreateBoard(100, 2);
            Assert.IsTrue(board.Squares.Count != 0);
        }

        [Test]
        public void GivenBoardWhenGameStartWhitOnePersonThenBoardThrowException()
        {
            try
            {
                new Game().CreateBoard(100, 1);
                Assert.Fail();
            }
            catch (Exception error)
            {
                Assert.AreEqual("Error al crear el tablero", error.Message);
            }
        }

        [Test]
        public void GivenBoardWhenGameStartWhitTwoPlayersThenBoardHasPlayerList()
        {
            var board = new Game().CreateBoard(100, 2);
            Assert.AreEqual(2, board.Players.Count);
        }

        [Test]
        public void GivenGameStartWhenPlayersAreReadyThenPlayersStartSquare1()
        {
            var board = new Game().CreateBoard(100, 2);
            board.Players.ForEach(payer =>
            {
                Assert.AreEqual(1, payer.TokenPosition);
            });
        }

        [Test]
        public void GivenGameStartWhenPlayersAreReadyThenPlayerCanMoveTheirToken()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, 3, board.Squares);
            board.Players[1].TokenPosition = gameRules.MovePlayerToken(board.Players[1].TokenPosition, 6, board.Squares);
            Assert.AreEqual(4, board.Players[0].TokenPosition);
            Assert.AreEqual(7, board.Players[1].TokenPosition);
        }

        [Test]
        public void GivenDiceWhenPlayerThrowDiceThenPlayerTokenMove()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            var diceResult = gameRules.ThrowDice(null);
            var playerPreviousPosition = board.Players[0].TokenPosition;
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.AreEqual(playerPreviousPosition + diceResult, board.Players[0].TokenPosition);
        }

        [Test]
        public void GivenBoardWhenGameStartThenBoardHasNotSnakesAndLadders()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            Assert.IsTrue(board.Squares.FindAll(square => square.Type == "Snake").Count == 0);
            Assert.IsTrue(board.Squares.FindAll(square => square.Type == "Ladder").Count == 0);
        }

        [Test]
        public void GivenBoardWhenAddRulesThenBoardHasSnakesAndLadders()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            Assert.IsTrue(board.Squares.FindAll(square => square.Type == "Snake").Count != 0);
            Assert.IsTrue(board.Squares.FindAll(square => square.Type == "Ladder").Count != 0);
        }

        [Test]
        public void GivenPlayerWhenGoToLadderThenPlayerPositionIsHigherThanOlderPositionPlusDiceResult()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            var diceResult = gameRules.ThrowDice(1);
            var playerPreviousPosition = board.Players[0].TokenPosition;
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.IsTrue(playerPreviousPosition + diceResult < board.Players[0].TokenPosition);
        }

        [Test]
        public void GivenPlayerWhenGoToSnakeThenPlayerPositionIsLowerThanOlderPositionPlusDiceResult()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            var diceResult = gameRules.ThrowDice(15);
            var playerPreviousPosition = board.Players[0].TokenPosition;
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.IsTrue(playerPreviousPosition + diceResult > board.Players[0].TokenPosition);
        }

        [Test]
        public void GivenPlayerWhenGoToLastSquareThenWinGame()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            var diceResult = gameRules.ThrowDice(99);
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.IsTrue(gameRules.HasWinner(board, board.Players[0].TokenPosition));
        }

        [Test]
        public void GivenPlayerWhenGoToAfterLastSquareThenNotWinGame()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            var diceResult = gameRules.ThrowDice(100);
            board.Players[0].TokenPosition = gameRules.MovePlayerToken(board.Players[0].TokenPosition, diceResult, board.Squares);
            Assert.IsFalse(gameRules.HasWinner(board, board.Players[0].TokenPosition));
        }

    }
}