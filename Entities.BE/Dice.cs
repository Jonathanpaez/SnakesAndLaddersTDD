using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.BE
{
    public interface IDice
    {
        public int ThrowDice(int? customValue);
    }
}
