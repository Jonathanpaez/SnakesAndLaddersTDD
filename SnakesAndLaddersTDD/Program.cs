using System;
using Logic.BL;

namespace SnakesAndLaddersTDD
{
    internal class Program
    {
        private static void Main()
        {
            var gameRules = new Game();
            var board = gameRules.CreateBoard(100, 2);
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.GetSquareRules());
            while (!board.HasWinner)
            {
                foreach (var player in board.Players)
                {
                    Console.WriteLine("Player " + player.Id);
                    Console.WriteLine("Position " + player.TokenPosition);
                    var diceResult = gameRules.ThrowDice(null);
                    Console.WriteLine("Dice result " + diceResult);
                    gameRules.MovePlayerToken(board, diceResult, player.Id);
                    Console.WriteLine("Final Position " + player.TokenPosition);
                    gameRules.HasWinner(board, player.TokenPosition);
                    if (board.HasWinner)
                    {
                        Console.WriteLine("Winner Player " + player.Id); 
                        break;
                    };
                }
            }
        }
    }
}
