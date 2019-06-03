using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinedOutClasses
{
    class Generator
    {
        public Field Area;
        public Character Hero { get; set; }
        public int NumberOfMines { get; set; }
        public int NumberHearts { get; set; }
        public int NumberCoins { get; set; }
        public Generator(Field field, int mines, int hearts, int coins)
        {
            Area = field;
            NumberOfMines = mines;
            NumberHearts = hearts;
            NumberCoins = coins;
        }

        public void GenerateField(Field Field)
        {
            for (int i = 0; i < Field.Height; i++)
            {
                Field.Cells[i] = new Cell[Field.Width];
                for (int j = 0; j < Field.Width; j++)
                {
                    if (i == 0 || j == 0 || i == Field.Height - 1 || j == Field.Width - 1)
                    {
                        Field.Cells[i][j] = new Wall(j, i, ConsoleColor.Red, "#");
                    }
                    else
                    {
                        Field.Cells[i][j] = new EmptyCell(j, i, ConsoleColor.DarkGray, " ");
                    }
                }
            }
            Hero = new Character(2, 2, ConsoleColor.Green, 1, 0, "0");
            Field.Cells[2][2] = Hero;
            Field.Cells[Field.Height - 2][Field.Width - 2] = new Escape(Field.Width - 2, Field.Height - 2, ConsoleColor.DarkMagenta, "O");
            DropHearts(Field);
            DropCoins(Field);
            SetMines(Field);
            SetPortal(Field);
            Field.Cells[Field.Height / 2][Field.Width / 2] = new Trap(Field.Width / 2, Field.Height / 2, ConsoleColor.Gray, "3");
        }

        public void CreateSavedField(string[][] Markup, Field Field)
        {
            for (int i = 0; i < Markup.Length; i++)
            {
                Field.Cells[i] = new Cell[Markup[i].Length];
                for (int j = 0; j < Markup[i].Length; j++)
                {
                    if (Markup[i][j] == "X") Field.Cells[i][j] = new Mine(j, i, ConsoleColor.DarkGray, "X");
                    else if (Markup[i][j] == "#") Field.Cells[i][j] = new Wall(j, i, ConsoleColor.Red, "#");
                    else if (Markup[i][j] == "x") Field.Cells[i][j] = new ExplodedMine(j, i, ConsoleColor.DarkGray, "x");
                    else if (Markup[i][j] == "p") Field.Cells[i][j] = new Portal(j, i, ConsoleColor.Cyan, "p");
                    else if (Markup[i][j] == "v") Field.Cells[i][j] = new Heart(j, i, ConsoleColor.Cyan, "v");
                    else if (Markup[i][j] == " ") Field.Cells[i][j] = new EmptyCell(j, i, ConsoleColor.DarkGray, " ");
                    else if (Markup[i][j] == "o") Field.Cells[i][j] = new Coin(j, i, ConsoleColor.Yellow, "o");
                    else if (Markup[i][j] == "O") Field.Cells[i][j] = new Escape(j, i, ConsoleColor.DarkMagenta, "O");
                    else if (Markup[i][j] == "0" || Markup[i][j] == "1"
                        || Markup[i][j] == "2" || Markup[i][j] == "3" || Markup[i][j] == "4")
                    {
                        Field.Cells[i][j] = new Character(j, i, ConsoleColor.White, 1, 0, "0");
                    }
                }
            }
        }

        public void SetPortal(Field Field)
        {
            int num = 2;
            Random a = new Random();
            while (num != 0)
            {
                int x = a.Next(1, Field.Width - 1);
                int y = a.Next(1, Field.Height - 1);
                if (Field.Cells[y][x] is EmptyCell)
                {
                    Field.Cells[y][x] = new Portal(x, y, ConsoleColor.DarkCyan, "p");
                    num--;
                }
            }
        }

        public void SetMines(Field Field)
        {
            Random a = new Random();
            while (NumberOfMines != 0)
            {
                int x = a.Next(1, Field.Width - 1);
                int y = a.Next(1, Field.Height - 1);
                if (Field.Cells[y][x] is EmptyCell && Field.Cells[y][x - 1] is Character == false
                    && Field.Cells[y][x + 1] is Character == false && Field.Cells[y - 1][x] is Character == false
                    && Field.Cells[y + 1][x] is Character == false)
                {
                    Field.Cells[y][x] = new Mine(x, y, ConsoleColor.Black, "X");
                    NumberOfMines--;
                }
            }
        }

        public void DropHearts(Field Field)
        {
            Random a = new Random();
            while (NumberHearts != 0)
            {
                int x = a.Next(1, Field.Width - 1);
                int y = a.Next(1, Field.Height - 1);
                if (Field.Cells[y][x] is EmptyCell)
                {
                    Field.Cells[y][x] = new Heart(x, y, ConsoleColor.Cyan, "v");
                }
                NumberHearts--;
            }
        }

        public void DropCoins(Field Field)
        {
            Random a = new Random();
            while (NumberCoins != 0)
            {
                int x = a.Next(1, Field.Width - 1);
                int y = a.Next(1, Field.Height - 1);
                if (Field.Cells[y][x] is EmptyCell)
                {
                    Field.Cells[y][x] = new Coin(x, y, ConsoleColor.Yellow, "o");
                }
                NumberCoins--;
            }
        }
    }
}
