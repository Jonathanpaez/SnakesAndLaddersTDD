using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BE
{
    public class Player
    {
        private int _id { get; set; }
        private int _tokenPosition { get; set; }
        public int Id { get { return _id; } set { _id = value; } }
        public int TokenPosition { get { return _tokenPosition; } set { _tokenPosition = value; } }
        public void MoveToken(int position)
        {
            _tokenPosition = position;
        }
    }
}
