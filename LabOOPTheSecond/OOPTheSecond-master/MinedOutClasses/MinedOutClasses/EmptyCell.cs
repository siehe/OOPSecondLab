using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MinedOutClasses
{
    class EmptyCell:Cell
    {
        public EmptyCell(int x, int y, ConsoleColor color, string symbol) : base(x, y, color, symbol) {}
    }
}
