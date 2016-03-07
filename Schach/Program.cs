using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schach
{
    class Program
    {

        public static int züge;
        public static int[] verschiebung = new int[2] { 1, 1 };
        /*
        Weiß:
        Bauern  -> 1
        Türme   -> 2
        Pferd   -> 3
        Läufer  -> 4
        Dame    -> 5
        König   -> 6

        Schwarz:
        Bauern  -> 7
        Türme   -> 8
        Pferd   -> 9
        Läufer  -> 10
        Dame    -> 11
        König   -> 12
        */
        public static int[,] Feld = new int[8, 8]
        {
            {8 ,9 ,10,11,12,10,9 ,8 },
            {7 ,7 ,7 ,7 ,7 ,7 ,7 ,7 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 },
            {1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 },
            {2 ,3 ,4 ,5 ,6 ,4 ,3 ,2 },
        };
        public static char[] symbols = new char[13]
            {' ','B','T','P','L','D','K','B','T','P','L','D','K'};
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            zeichneFeld();
            zeichneSpieler();
            Console.ForegroundColor = ConsoleColor.Black;
            bool z = zug();
            string input = Console.ReadLine();
            a:
            goto a;
        }

        public static void convertToChar(int zahl, out char character)
        {
            if (zahl == 1) character = 'A';
            else if (zahl == 2) character = 'B';
            else if (zahl == 3) character = 'C';
            else if (zahl == 4) character = 'D';
            else if (zahl == 5) character = 'E';
            else if (zahl == 6) character = 'F';
            else if (zahl == 7) character = 'G';
            else character = 'H';
        }

        public static void zeichneFeld()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int u = 0; u < 8; u++)
                {
                    Console.SetCursorPosition(i + verschiebung[0], u + verschiebung[1]);
                    if (u % 2 == 0 && i % 2 != 0 || u % 2 != 0 && i % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
            for (int i = 1; i < 9; i++)
            {
                Console.SetCursorPosition(0, verschiebung[0] + i - 1);
                Console.Write(i);
                Console.SetCursorPosition(verschiebung[1] + i - 1, 0);
                char buch;
                convertToChar(i, out buch);
                Console.Write(buch);
            }
        }

        public static void zeichneSpieler()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int u = 0; u < 8; u++)
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    Console.SetCursorPosition(i + verschiebung[0], u + verschiebung[1]);
                    if (u % 2 == 0 && i % 2 != 0 || u % 2 != 0 && i % 2 == 0) Console.BackgroundColor = ConsoleColor.DarkGray;
                    else Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (Feld[u, i] < 7) Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(symbols[Feld[u, i]]);
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        }

       public  static bool zug()
        {
            züge++;
            Console.SetCursorPosition(1, 10);
            if (züge % 2 == 0)
            {
                Console.Write("Schwarz ist am Zug " + züge + "> ");
                return true;
            }
            else
            {
                Console.Write("Weiß ist am Zug (" + züge + ")> ");
                return false;
            }
        }
    }
}
