﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BE
{
    public class Board
    {
        private bool _hasWinner { get; set; }
        public List<Square> Squares { get; set; }
        public List<Player> Players { get; set; }
        public bool HasWinner { get { return _hasWinner; } }
        public void SetWinner()
        {
            _hasWinner = true;
        }
    }

    public class Square
    {
        public int NumberId { get; set; }
        public string Type { get; set; }
    }

    public interface ISquareRules
    {
        public List<Rule> GetSquareRules();
    }

    public class Rule
    {
        public string Type { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
    }


}
