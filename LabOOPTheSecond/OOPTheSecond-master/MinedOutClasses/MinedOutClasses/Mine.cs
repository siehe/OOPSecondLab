using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class Mine:Cell
    {
        public Mine(int x, int y, ConsoleColor color, string symbol) :base(x, y, color, symbol) {}
    }
}
