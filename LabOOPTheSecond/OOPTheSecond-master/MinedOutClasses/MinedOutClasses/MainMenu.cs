using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class MainMenu
    {
        public string SelectedOption { get; set; }
        public int CurrentOption { get; set; }
        public string[] Options;

        public MainMenu()
        {
            CurrentOption = 1;
            Options = new string[3];
            Options[0] = "Small";
            Options[1] = "Medium";
            Options[2] = "Large";
        }

        public void WriteOptions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Select size of game field:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Options[0]);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(10, 1); Console.WriteLine("<---");
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Options[1]);
            Console.WriteLine(Options[2]);
        }

        public string MoveOptions(ConsoleKeyInfo KeyInfo)
        {
            string res = "";
            Console.ForegroundColor = ConsoleColor.Magenta;
            switch (KeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CurrentOption - 1 > 0)
                    {
                        Console.SetCursorPosition(10, CurrentOption);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(10, CurrentOption - 1);
                        Console.WriteLine("<---");
                        CurrentOption--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(CurrentOption + 1 < 4)
                    {
                        Console.SetCursorPosition(10, CurrentOption);
                        Console.WriteLine("    ");
                        Console.SetCursorPosition(10, CurrentOption + 1);
                        Console.WriteLine("<---");
                        CurrentOption++;
                    }
                    break;
                case ConsoleKey.Enter:
                    res = Options[CurrentOption - 1];
                    break;
            }
            return res;
        }
    }
}
