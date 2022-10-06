using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Labirint
{
    class Program
    {
        static void Labirint(int[,] labris)
        {
            var x = 0;
            var y = 0;
            for (int i = 0; i < labris.GetLength(0); i++, ++y)
            {
                for (int j = 0; j < labris.GetLength(1); j++, ++x)
                {
                    Console.SetCursorPosition(x, y);
                    if (labris[i, j] == 1)
                    {
                        Console.Write("█");
                    }
                }
                x = 0;
            }

        }
        static void Shag(int[,] labris, int x, int y, bool shag)
        {
            if (shag)
            {
                Console.Clear();
                Labirint(labris);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(31, 27);
                Labirint(labris);
                Console.SetCursorPosition(37, 6);   
                Console.Write("Управляйте человечком с помощью: ");
                Console.SetCursorPosition(30, 7);
                Console.Write("w - Вверх   s - Вниз   d - Вправо    a - Влево");
                Console.SetCursorPosition(42, 6);
            }
            else
            {
                Console.SetCursorPosition(43, 10);
                Console.Write("Вы уперлись в стену!");
                Console.SetCursorPosition(42, 6);
            }
        }
        static void Exit(int[,] labris, int x, int y, ref bool GameOver)
        {
            Random rand = new Random();
            if (labris[y, x] == 3)
            {
                GameOver = true;
                Console.SetCursorPosition(43, 10);
                Console.Write("Вы вышли из лабиринта!");
                Console.SetCursorPosition(48, 11);
                Console.Write("Поздравляю!");
                Console.SetCursorPosition(0, 20);
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int[,] labris =
            {
             {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
             {1,2,1,1,1,1,1,0,1,1,1,1,0,0,0,1,0,0,0,1},
             {1,0,1,0,0,0,1,0,0,0,0,0,0,1,0,1,0,1,0,1},
             {1,0,0,0,1,0,1,1,1,1,0,1,1,1,0,0,0,1,0,1},
             {1,1,1,1,1,0,1,0,0,1,0,1,0,1,1,1,1,1,0,1},
             {1,0,0,0,0,0,1,1,0,1,0,1,0,0,0,0,0,0,0,1},
             {1,0,1,1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,0,1},
             {1,0,0,0,1,1,0,0,1,1,1,1,0,0,0,0,1,1,0,1},
             {1,1,1,0,0,1,0,1,1,0,0,1,1,1,1,0,1,1,0,1},
             {1,1,1,1,0,0,0,1,1,0,0,0,0,0,0,0,1,1,0,1},
             {1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,1},
             {1,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,1,1},
             {1,0,1,1,1,1,1,0,1,1,1,0,0,0,1,0,1,1,0,1},
             {1,0,1,0,0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,1},
             {1,0,1,0,1,0,1,1,1,0,0,0,0,0,1,1,1,1,0,1},
             {1,0,1,0,1,0,1,1,1,1,1,1,1,0,0,0,0,0,0,1},
             {1,0,0,0,1,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1},
             {1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,1,0,0,0,1},
             {1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,3,1},
             {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}

         };

            Labirint(labris);
            Console.SetCursorPosition(37, 3);
            Console.Write("Добро пожаловать в игру Лабиринт!");
            Console.SetCursorPosition(38, 6);
            Console.Write("Управляйте человечком с помощью: ");
            Console.SetCursorPosition(30, 7);
            Console.Write("w - Вверх   s - Вниз   d - Вправо    a - Влево");
            Console.SetCursorPosition(42, 6);

            var x = 1;
            var y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☻");
            var GameOver = false;
            while (!GameOver)
            {
                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (labris[--y, x] == 1)
                        {
                            ++y;
                            Shag(labris, x, y, false);
                        }
                        else
                        {
                            Shag(labris, x, y, true);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('s'):
                        if (labris[++y, x] == 1)
                        {
                            --y;
                            Shag(labris, x, y, false);
                        }
                        else
                        {
                            Shag(labris, x, y, true);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('a'):
                        if (labris[y, --x] == 1)
                        {
                            ++x;
                            Shag(labris, x, y, false);
                        }
                        else
                        {
                            Shag(labris, x, y, true);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('d'):
                        if (labris[y, ++x] == 1)
                        {
                            --x;
                            Shag(labris, x, y, false);
                        }
                        else
                        {
                            Shag(labris, x, y, true);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;
                    default:
                        Console.Clear();
                        Labirint(labris);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☻");
                        Console.SetCursorPosition(42, 6);

                        break;
                }
            }
            Console.ReadKey();
        }
    }
}


     