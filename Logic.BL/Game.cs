using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.BE;

namespace Logic.BL
{
    public class Game: IDice, ISquareRules
    {
        public static string ErrorCreateBoard = "Error al crear el tablero";
        public static string ErrorLoadRules = "Error al cargar reglas";
        public static string DefaultSquare = "Default";
        public static string SnakeSquare = "Snake";
        public static string LadderSquare = "Ladder";
        public Board CreateBoard(int squareNumber, int playersNumber)
        {
            if (squareNumber < 10 || playersNumber < 2)
            {
                throw new Exception(ErrorCreateBoard);
            }
            var board = new Board
            {
                Squares = InitSquaresBoard(squareNumber),
                Players = InitPlayers(playersNumber)
            };
            return board;
        }

        private static List<Square> InitSquaresBoard(int squareNumber)
        {
            var squares = new List<Square>();
            for (var index = 0; index < squareNumber; index++)
            {
                squares.Add(new Square()
                {
                    NumberId = index + 1,
                    Type = DefaultSquare
                });
            }
            return squares;
        }

        private static List<Player> InitPlayers(int playersNumber)
        {
            var players = new List<Player>();
            for (var index = 0; index < playersNumber; index++)
            {
                players.Add(new Player()
                {
                    Id = index + 1,
                    TokenPosition = 1
                });
            }
            return players;
        }

        public void MovePlayerToken(Board board, int steps, int playerId)
        {
            var player = board.Players.Find(player => player.Id == playerId);
            var newTokenPosition = player.TokenPosition + steps;
            if (newTokenPosition > board.Squares.Last().NumberId) return;
            var possibleSpecialSquare = board.Squares.Find(square => square.NumberId == newTokenPosition);
            if (possibleSpecialSquare != null && !possibleSpecialSquare.Type.Equals(DefaultSquare))
            {
                player.TokenPosition = GetSquareRules().Find(rule => rule.InitialPosition == newTokenPosition)!.FinalPosition;
                return;
            }
            player.TokenPosition = newTokenPosition;
        }


        public int ThrowDice(int? customValue)
        {
            return customValue ?? new Random().Next(1, 7);
        }

        public List<Rule> GetSquareRules()
        {
            return new List<Rule>()
            {
                new Rule() { Type = LadderSquare, InitialPosition = 2, FinalPosition = 38 },
                new Rule() { Type = LadderSquare, InitialPosition = 7, FinalPosition = 14 },
                new Rule() { Type = LadderSquare, InitialPosition = 8, FinalPosition = 31 },
                new Rule() { Type = LadderSquare, InitialPosition = 15, FinalPosition = 26 },
                new Rule() { Type = LadderSquare, InitialPosition = 21, FinalPosition = 42 },
                new Rule() { Type = LadderSquare, InitialPosition = 28, FinalPosition = 84 },
                new Rule() { Type = LadderSquare, InitialPosition = 36, FinalPosition = 44 },
                new Rule() { Type = LadderSquare, InitialPosition = 51, FinalPosition = 68 },
                new Rule() { Type = LadderSquare, InitialPosition = 71, FinalPosition = 91 },
                new Rule() { Type = LadderSquare, InitialPosition = 78, FinalPosition = 98 },
                new Rule() { Type = LadderSquare, InitialPosition = 87, FinalPosition = 94 },
                new Rule() { Type = SnakeSquare, InitialPosition = 16, FinalPosition = 6 },
                new Rule() { Type = SnakeSquare, InitialPosition = 46, FinalPosition = 25 },
                new Rule() { Type = SnakeSquare, InitialPosition = 49, FinalPosition = 11 },
                new Rule() { Type = SnakeSquare, InitialPosition = 62, FinalPosition = 19 },
                new Rule() { Type = SnakeSquare, InitialPosition = 64, FinalPosition = 60 },
                new Rule() { Type = SnakeSquare, InitialPosition = 74, FinalPosition = 53 },
                new Rule() { Type = SnakeSquare, InitialPosition = 92, FinalPosition = 88 },
                new Rule() { Type = SnakeSquare, InitialPosition = 95, FinalPosition = 75 },
                new Rule() { Type = SnakeSquare, InitialPosition = 99, FinalPosition = 80 },
            };
        }

        public List<Square> LoadSquaresRules(List<Square> squares, List<Rule> rules)
        {
            rules.ForEach(rule =>
            {
                var specialSquare = squares.Find(square => square.NumberId == rule.InitialPosition);
                if (specialSquare == null) throw new ArgumentNullException(ErrorLoadRules);
                specialSquare.Type = rule.Type;
            });
            return squares;
        }

        public bool HasWinner(Board board, int playerPosition)
        {
            return board.Squares.Last().NumberId == playerPosition;
        }
    }
}
