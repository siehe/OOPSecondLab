using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MinedOutClasses
{
    abstract class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }

        public Cell(int x, int y, ConsoleColor color, string symbol)
        {
            X = x;
            Y = y;
            Color = color;
            Symbol = symbol;
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = Color;
            Console.BackgroundColor = Color;
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
