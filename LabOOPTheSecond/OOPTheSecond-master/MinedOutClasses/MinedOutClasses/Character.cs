using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MinedOutClasses
{
    class Character : Cell
    {
        public int Health { get; set; }
        public string Symbol { get; set; }
        public int BonusPoints { get; set; }
        public bool AbleToMove { get; set; }
        public string Name { get; set; }
        public int NumberOfMoves { get; set; }
        public Character(int x, int y, ConsoleColor color, int health, int bonus, string symbol) :base(x, y, color, symbol)
        {
            Health = health;
            BonusPoints = bonus;
            Symbol = "0";
            AbleToMove = true;
        }

        public override void Draw()
        {
            Console.BackgroundColor = Color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void DrawStep(int DeltaX, int DeltaY, Field Field)
        {
            Field.Cells[Y][X] = new EmptyCell(X, Y, ConsoleColor.Gray, " ");
            Field.Cells[Y][X].Draw();
            Console.SetCursorPosition(X + DeltaX, Y + DeltaY);
            Console.BackgroundColor = Color;
            Console.ForegroundColor = ConsoleColor.White;
            X += DeltaX;
            Y += DeltaY;
            Console.Write(CountMines(Field));
        }

        public string CountMines(Field Field)
        {
            int res = 0;
            if (Field.Cells[Y + 1][X] is Mine) res++;
            if (Field.Cells[Y - 1][X] is Mine) res++;
            if (Field.Cells[Y][X + 1] is Mine) res++;
            if (Field.Cells[Y][X - 1] is Mine) res++;
            return res.ToString();
        }

        public void Move(ConsoleKeyInfo KeyInfo, Field Field)
        {
            switch(KeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if(Y - 1 > 0)
                    {
                        DrawStep(0, - 1, Field);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(Y + 1 < Field.Height - 1)
                    {
                        DrawStep(0, 1, Field);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(X + 1 < Field.Width - 1)
                    {
                        DrawStep(1, 0, Field);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(X - 1 > 0)
                    {
                        DrawStep(-1, 0, Field);
                    }
                    break;
            }
        }

        public void Teleport(Field Field)
        {
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    if (Field.Cells[i][j] is Portal && i != Y && j != X && Y < i)
                    {
                        DrawStep(j - X, i - Y, Field);
                        Field.Cells[Y][X] = new EmptyCell(X, Y, ConsoleColor.Gray, " ");
                        X = j;
                        Y = i;
                        Field.Cells[Y][X] = new EmptyCell(X, Y, ConsoleColor.Gray, " ");
                    }
                }
            }
        }

        public void Explode()
        {
            Console.SetCursorPosition(X, Y);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" ");
        }
    }
}
