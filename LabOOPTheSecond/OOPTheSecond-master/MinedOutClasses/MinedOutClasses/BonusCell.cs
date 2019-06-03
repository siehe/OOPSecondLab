using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class BonusCell:Cell
    {
        public BonusCell(int x, int y, ConsoleColor color, string symbol):base(x, y, color, symbol)
        {
        }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }
    }
}
