using System;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //JsonSerializer sr = new JsonSerializer();
            //sr.NullValueHandling = NullValueHandling.Ignore;



            Console.CursorVisible = false;

            Drawer Drawer = new Drawer();
            Drawer.WriteIntro();

            MainMenu Menu = new MainMenu();
            string name = Console.ReadLine();
            Console.Clear();
            Drawer.WriteGreeting(name);
            Console.ReadKey();
            Menu.WriteOptions();
            string size = "";
            while(true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                size = Menu.MoveOptions(keyInfo);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
            Console.Clear();
            Drawer.WriteLoading();
            int height;
            if (size == "Small")
            {
                height = 15;
            }
            else if(size == "Medium")
            {
                height = 20;
            }
            else
            {
                height = 30;
            }





            int width = height * 2;
            int mines = (width * height) / 5;
            int hearts = (width * height) / 60;
            int coins = (width * height) / 15;
            Field Field = new Field(height, width);
            Generator FieldGenerator = new Generator(Field, mines, hearts, coins);
            Console.Clear();
            FieldGenerator.GenerateField(Field);
            Field.Hero = FieldGenerator.Hero;

            Console.Clear();


            Drawer.DrawField(Field);
            bool win = false;

            while (true)
            {
                Drawer.WriteStats(Field);
                if (Field.Hero.AbleToMove)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    Field.Hero.NumberOfMoves++;
                    Field.Hero.Move(keyInfo, Field);
                    int CurrX = Field.Hero.X;
                    int CurrY = Field.Hero.Y;
                    if (Field.Cells[CurrY][CurrX] is Mine)
                    {
                        if (Field.Hero.Health == 0)
                        {
                            Field.Hero.AbleToMove = false;
                            Field.Hero.Explode();
                            Drawer.BlowUpMines(Field);
                            break;
                        }
                        else
                        {
                            Field.Cells[CurrY][CurrX] = new EmptyCell(CurrX, CurrY, ConsoleColor.Gray, " ");
                            Field.Hero.Health--;
                        }
                    }
                    else if (Field.Cells[CurrY][CurrX] is Coin)
                    {
                        Field.Hero.BonusPoints++;
                    }
                    else if (Field.Cells[CurrY][CurrX] is Heart)
                    {
                        Field.Hero.Health++;
                    }
                    else if (Field.Cells[CurrY][CurrX] is Escape)
                    {
                        Field.Hero.AbleToMove = false;
                        Drawer.DrawVictory(Field);
                        win = true;
                        break;
                    }
                    else if(Field.Cells[CurrY][CurrX] is Portal)
                    {
                        Field.Hero.Teleport(Field);
                    }
                    else if(Field.Cells[CurrY][CurrX] is Trap)
                    {
                        int k = 0;
                        while(k != 10)
                        {
                            Console.ReadKey(true);
                            Field.Hero.NumberOfMoves++;
                            Drawer.WriteStats(Field);
                            k++;
                        }
                        Field.Cells[CurrY][CurrX] = new EmptyCell(CurrX, CurrY, ConsoleColor.Gray, ".");
                    }
                }
            }

            Drawer.FinalScore(win, Field.Hero.NumberOfMoves);

            Console.ReadKey();
        }
    }
}
