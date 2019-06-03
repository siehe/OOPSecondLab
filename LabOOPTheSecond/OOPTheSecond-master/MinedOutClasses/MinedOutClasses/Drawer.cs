using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class Drawer
    {
        public void DrawField(Field Field)
        {
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    Field.Cells[i][j].Draw();
                }
            }
        }

        public void WriteIntro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello! Sorry, what is your name?");
        }

        public void WriteGreeting(string name)
        {
            Console.WriteLine("Hello, {0}, nice to meet you! Welcome to Mined-Out. Press any key to continue.", name);
        }

        public void WriteLoading()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Loading...");
        }

        public void FinalScore(bool Win, int Steps)
        {
            if(Win)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("It took you {0} steps to win!", Steps);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("It took you {0} steps to blow up :(", Steps);
            }
        }

        public void BlowUpMines(Field Field)
        {
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    if (Field.Cells[i][j] is Mine)
                    {
                        Field.Cells[i][j] = new ExplodedMine(j, i, ConsoleColor.DarkYellow, "x");
                        Field.Cells[i][j].Draw();
                    }
                }
            }
        }

        public void WriteStats(Field Field)
        {
            Console.SetCursorPosition(Field.Width + 4, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Health: {0}", Field.Hero.Health);


            Console.SetCursorPosition(Field.Width + 4, 1);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Bonus points: {0}", Field.Hero.BonusPoints);


            Console.SetCursorPosition(Field.Width + 4, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Number of steps: {0}", Field.Hero.NumberOfMoves);
        }

        public void DrawVictory(Field Field)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            for (int i = Field.Hero.Y; i > 0; i--)
            {
                for (int j = Field.Hero.X; j > 0; j--)
                {
                    if (i == Field.Hero.Y || j == Field.Hero.X)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                        System.Threading.Thread.Sleep(50);
                    }
                }
            }
            for (int i = Field.Hero.Y; i < Field.Height - 1; i++)
            {
                for (int j = Field.Hero.X; j < Field.Width - 1; j++)
                {
                    if (i == Field.Hero.Y || j == Field.Hero.X)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(" ");
                        System.Threading.Thread.Sleep(50);
                    }
                }
            }

            System.Threading.Thread.Sleep(100);
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    System.Threading.Thread.Sleep(10);
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
        }
    }
}
