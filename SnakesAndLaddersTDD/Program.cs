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
            var hasWinner = false;
            board.Squares = gameRules.LoadSquaresRules(board.Squares, gameRules.SquareRules());
            while (!hasWinner)
            {
                foreach (var player in board.Players)
                {
                    Console.WriteLine("Player " + player.Id);
                    Console.WriteLine("Position " + player.TokenPosition);
                    var diceResult = gameRules.ThrowDice(null);
                    Console.WriteLine("Dice result " + diceResult);
                    player.TokenPosition = gameRules.MovePlayerToken(player.TokenPosition, diceResult, board.Squares);
                    Console.WriteLine("Final Position " + player.TokenPosition);
                    hasWinner = gameRules.HasWinner(board, player.TokenPosition);
                    if (!hasWinner)
                    {
                        Console.WriteLine("Winner Player " + player.Id); 
                        break;
                    };
                    
                }
            }
        }
    }
}
