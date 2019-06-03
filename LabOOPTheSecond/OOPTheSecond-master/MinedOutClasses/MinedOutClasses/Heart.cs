using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class Heart : BonusCell
    {
        public Heart(int x, int y, ConsoleColor color, string symbol) : base(x, y, color, symbol) { }
    }
}
